using FibonacciSequence.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FibonacciSequence.Business.Services.Interfaces
{
    public interface IMongoDBService
    {
        List<FibonacciNumberSequence> Get();

        FibonacciNumberSequence Get(string id);

        List<FibonacciNumberSequenceReverse> GetReverse();

        FibonacciNumberSequenceReverse GetReverse(string id);

        Task CreateAsync(FibonacciNumberSequence fibonacciSequence);

        Task CreateReverseAsync(FibonacciNumberSequenceReverse fibonacciSequence);
    }
}
