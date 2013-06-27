using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE37
{
    class Program
    {
        static void Main(string[] args)
        {
            PrimeNumbers primeNumbers = new PrimeNumbers();
            DateTime start = DateTime.Now;
            bool[] primes = primeNumbers.Generate(750000);
            List<int> truncatablePrimes = primeNumbers.GetTruncatable(primes);
            int sum = truncatablePrimes.Sum();
            DateTime end = DateTime.Now;
            TimeSpan span = end - start;
            Console.WriteLine(string.Join(Environment.NewLine, truncatablePrimes));
            Console.WriteLine(string.Format("Sum {0}", sum));
            Console.WriteLine(string.Format("Elapsed Milliseconds {0}", span.TotalMilliseconds));
            Console.ReadLine();
        }
    }
}
