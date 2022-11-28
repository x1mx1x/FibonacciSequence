using FibonacciSequence.Business.Services.Interfaces;
using MongoDB.Driver;
using FibonacciSequence.Data.Models;
using System.Collections.Generic;
using FibonacciSequence.Data.Models.ResultModel;
using FibonacciSequence.Data.Models.DTO;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace FibonacciSequence.Business.Services
{
    public class FibonacciNumberSetService : IFibonacciNumberSetService
    {
        private readonly IFibonacciReverseService _fibonacciReverseService;
        private readonly IMongoDBService _mongoDBService;
        private readonly IFileRecordService _fileRecordService;


        public FibonacciNumberSetService(IFibonacciReverseService fibonacciReverseService, IFileRecordService fileRecordService, IMongoDBService mongoDBService)
        {
            _fibonacciReverseService = fibonacciReverseService;
            _fileRecordService = fileRecordService;
            _mongoDBService = mongoDBService;
        }

        public async Task<Result<FibonacciNumberSequenceReverse>> CreateAsync(CreateFibonacciSequenceDto set)
        {
            var reversedSet = _fibonacciReverseService.ReverseNumberSequence(set);
            if (reversedSet == null) 
            {
                return Result<FibonacciNumberSequenceReverse>.GetError(ErrorCode.ValidationError, "Sequence is not Fibonacci numbers.");
            }

            var fibonacciSequence = new FibonacciNumberSequence
                {
                    NumberSequence = set.NumberSequence
                };
            await _mongoDBService.CreateAsync(fibonacciSequence);


            _fileRecordService.RecordSequenceToFile(reversedSet);

            await _mongoDBService.CreateReverseAsync(reversedSet);
            return Result<FibonacciNumberSequenceReverse>.GetSuccess(reversedSet);
        }
    }
}
