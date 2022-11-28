namespace FibonacciSequence.Data.Models
{
    public class FibonacciDatabaseSettings //: IFibonacciDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string FibonacciCollection { get; set; } = null!;

        public string FibonacciReverseCollection { get; set; } = null!;
    }/*
    public interface IFibonacciDatabaseSettings
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }

        public string FibonacciCollection { get; set; }

        public string FibonacciReverseCollection { get; set; }
    }*/
}