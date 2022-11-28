using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace FibonacciSequence.Data.Models
{
    public class FibonacciNumberSequence
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public List<int> NumberSequence { get; set; }

    }
    public class FibonacciNumberSequenceReverse
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public List<int> NumberSequence { get; set; }

    }
}
