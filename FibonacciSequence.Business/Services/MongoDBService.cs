using FibonacciSequence.Business.Services.Interfaces;
using FibonacciSequence.Data.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FibonacciSequence.Business.Services
{
    public class MongoDBService : IMongoDBService
    {
        private readonly IMongoCollection<FibonacciNumberSequence> _fibonacciNumberSets;
        private readonly IMongoCollection<FibonacciNumberSequenceReverse> _fibonacciReverseNumberSets;

        public MongoDBService(IOptions<FibonacciDatabaseSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            IMongoDatabase db = client.GetDatabase(settings.Value.DatabaseName);

            _fibonacciNumberSets = db.GetCollection<FibonacciNumberSequence>(settings.Value.FibonacciCollection);
            _fibonacciReverseNumberSets = db.GetCollection<FibonacciNumberSequenceReverse>(settings.Value.FibonacciCollection);
        }

        public async Task CreateAsync(FibonacciNumberSequence fibonacciSequence)
        {
            await _fibonacciNumberSets.InsertOneAsync(fibonacciSequence);
        }

        public async Task CreateReverseAsync(FibonacciNumberSequenceReverse fibonacciSequence)
        {
            await _fibonacciReverseNumberSets.InsertOneAsync(fibonacciSequence);
        }

        public List<FibonacciNumberSequence> Get() =>
            _fibonacciNumberSets.Find(set => true).ToList();


        public FibonacciNumberSequence Get(string id) =>
            _fibonacciNumberSets.Find(set => set.Id == id).FirstOrDefault();

        public List<FibonacciNumberSequenceReverse> GetReverse() =>
            _fibonacciReverseNumberSets.Find(set => true).ToList();


        public FibonacciNumberSequenceReverse GetReverse(string id) =>
            _fibonacciReverseNumberSets.Find(set => set.Id == id).FirstOrDefault();

    }
}
