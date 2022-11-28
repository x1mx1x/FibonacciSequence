using FibonacciSequence.Data.Models;

namespace FibonacciSequence.Business.Services.Interfaces
{
    public interface IFileRecordService
    {
        void RecordSequenceToFile(FibonacciNumberSequenceReverse set);
    }
}
