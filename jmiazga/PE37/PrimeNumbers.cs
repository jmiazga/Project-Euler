using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE37
{
    public class PrimeNumbers
    {
        private delegate int RemoveDigit(int n);

        public bool[] Generate(int n)
        {
            bool[] a = new bool[1];

            if (n > 1)
            {
                a = GetInitializedArray(n);

                for (int i = 2; i <= Math.Sqrt(n); i++)
                {
                    if (a[i])
                    {
                        for (int j = i * i; j <= n; j += i)
                        {
                            a[j] = false;
                        }
                    }
                }
            }

            return a;
        }

        private bool[] GetInitializedArray(int n)
        {
            bool[] a = new bool[n + 1];

            for (int i = 2; i < a.Length; i++)
                a[i] = true;

            return a;
        }

        public List<int> GetTruncatable(bool[] a)
        {
            List<int> truncatablePrimes = new List<int>();

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] && IsTruncatable(i, a, RemoveFirstDigit) && IsTruncatable(i, a, RemoveLastDigit))
                    truncatablePrimes.Add(i);
            }

            return truncatablePrimes;
        }

        private bool IsTruncatable(int prime, bool[] primeArray, RemoveDigit removeDigit)
        {
            if (prime < 10)
                return false;

            int n = removeDigit(prime);

            do
            {
                if (primeArray[n])
                    n = removeDigit(n);
                else
                    return false;
            }
            while (n > 0);

            return true;
        }

        private int RemoveFirstDigit(int n)
        {
            if (n < 10)
                return -1;

            return Convert.ToInt32(n.ToString().Substring(1));
        }

        private int RemoveLastDigit(int n)
        {
            return n / 10;
        }
    }
}
