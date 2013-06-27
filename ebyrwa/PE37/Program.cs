using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE37
{
    class Program
    {
        private static readonly List<int> _truncatablePrimes = new List<int>();
        static void Main(string[] args)
        {
            var primes = new Dictionary<int, bool>();
            primes.Add(2, true);
            for (int i = 3; i < 1000000; i++)
            {
                bool isPrime = true;
                int l = (int)Math.Sqrt(i);
                foreach (int primeNum in primes.Keys)
                {
                    if (primeNum > l)
                    {
                        break;
                    }
                    if (Math.IEEERemainder(i, primeNum) == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                    primes.Add(i, true);
            }
            var truncatables = primes.Keys.Where(n => IsTruncatablePrime(n, true, primes));
            Console.WriteLine(string.Join(Environment.NewLine, truncatables));
            Console.ReadLine();
        }

        public static bool IsTruncatablePrime(int value, bool ignore, Dictionary<int, bool> primes)
        {
            var number = value.ToString();
            char first = number.First();
            char last = number.Last();
            bool ret = (first == '2' || first == '3' || first == '5' || first == '7') && (last == '2' || last == '3' || last == '5' || last == '7') && primes[value] && IsLeftTruncatablePrime(value, false, primes) && IsRightTruncatablePrime(value, false, primes);
            return ret;
        }

        private static bool IsRightTruncatablePrime(int value, bool ignore, Dictionary<int, bool> primes)
        {
            bool ret = false;
            if (!ignore && value < 8)
            {
                // Not valid.
            }
            else
            {
                value = TruncateRight(value);
                ret = primes[value];
                if (ret && value.ToString().Length > 1)
                    ret = IsRightTruncatablePrime(value, true, primes);
            }
            return ret;
        }

        public static bool IsLeftTruncatablePrime(int value, bool ignore, Dictionary<int, bool> primes)
        {
            bool ret = false;
            if (!ignore && value < 8)
            {
                // Not valid.
            }
            else
            {
                value = TruncateLeft(value);
                ret = primes[value];
                if (ret && value.ToString().Length > 1)
                    ret = IsLeftTruncatablePrime(value, true, primes);
            }
            return ret;
        }

        public static int TruncateRight(int value)
        {
            int ret = (int)(value / 10);
            return ret;
        }

        public static int TruncateLeft(int value)
        {
            string num = new string(value.ToString().Skip(1).ToArray());
            int ret = Convert.ToInt32(num);
            return ret;
        }
    }
}
