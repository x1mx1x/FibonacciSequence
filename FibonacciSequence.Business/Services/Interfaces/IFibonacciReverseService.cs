using FibonacciSequence.Data.Models;
using FibonacciSequence.Data.Models.DTO;
using System.Collections.Generic;

namespace FibonacciSequence.Business.Services.Interfaces
{
    public interface IFibonacciReverseService
    {
        List<FibonacciNumberSequenceReverse> ReverseNumberSequences(List<CreateFibonacciSequenceDto> sets);

        FibonacciNumberSequenceReverse ReverseNumberSequence(CreateFibonacciSequenceDto set);
    }
}
