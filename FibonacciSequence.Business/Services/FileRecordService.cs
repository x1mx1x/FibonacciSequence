using FibonacciSequence.Business.Services.Interfaces;
using FibonacciSequence.Data.Models;
using System.IO;

namespace FibonacciSequence.Business.Services
{
    public class FileRecordService : IFileRecordService
    {
        public void RecordSequenceToFile(FibonacciNumberSequenceReverse set) 
        {
            using (StreamWriter sw = new StreamWriter("test.txt"))
            {
                foreach (var num in set.NumberSequence) 
                {
                    sw.Write(num + ' ');
                }
            }
        }
    }
}
