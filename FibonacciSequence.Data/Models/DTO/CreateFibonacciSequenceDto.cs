using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciSequence.Data.Models.DTO
{
    public class CreateFibonacciSequenceDto
    {
        public List<int> NumberSequence { get; set; }
    }
}
