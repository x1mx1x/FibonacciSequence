using FibonacciSequence.Business.Services.Interfaces;
using FibonacciSequence.Data.Models;
using FibonacciSequence.Data.Models.DTO;
using FibonacciSequence.Data.Models.ResultModel;
using System.Collections.Generic;

namespace FibonacciSequence.Business.Services
{
    public class FibonacciReverseService : IFibonacciReverseService
    {
        public FibonacciNumberSequenceReverse ReverseNumberSequence(CreateFibonacciSequenceDto set)
        {
            if (IsFibonacci(set))
            {
                int temp = 0;
                int length = set.NumberSequence.Count / 2;
                for (int i = 0; i < length; i++)
                {
                    temp = set.NumberSequence[i];
                    set.NumberSequence[i] = set.NumberSequence[length - i - 1];
                    set.NumberSequence[length - i - 1] = temp;
                }
                return new FibonacciNumberSequenceReverse
                {
                    NumberSequence = set.NumberSequence
                };
            }
            else return new FibonacciNumberSequenceReverse();
        }

        public List<FibonacciNumberSequenceReverse> ReverseNumberSequences(List<CreateFibonacciSequenceDto> sets)
        {
            var reverseSets = new List<FibonacciNumberSequenceReverse>();
            foreach (var set in sets)
            {
                reverseSets.Add(ReverseNumberSequence(set));
            }
            return reverseSets;
        }

        public bool IsFibonacci(CreateFibonacciSequenceDto set)
        {
            SortSequence(ref set);
            var length = set.NumberSequence.Count;

            for (int i = length - 1; i >= 0; i--)
            {
                if (set.NumberSequence[i] != Fibonacci(i)) return false;
            }
            return true;
        }
        public int Fibonacci(int n)
        {
            if (n == 0 || n == 1) return n;

            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        public void SortSequence(ref CreateFibonacciSequenceDto set)
        {
            var length = set.NumberSequence.Count;
            int temp = 0;
            for (int i = 0; i < length; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    if (set.NumberSequence[i] > set.NumberSequence[j])
                    {
                        temp = set.NumberSequence[i];
                        set.NumberSequence[i] = set.NumberSequence[j];
                        set.NumberSequence[j] = temp;
                    }
                }
            }
        }
    }
}
