using FibonacciSequence.Data.Models;
using FibonacciSequence.Data.Models.DTO;
using FibonacciSequence.Data.Models.ResultModel;
using System.Threading.Tasks;

namespace FibonacciSequence.Business.Services.Interfaces
{
    public interface IFibonacciNumberSetService
    {
        public Task<Result<FibonacciNumberSequenceReverse>> CreateAsync(CreateFibonacciSequenceDto set);
    }
}
