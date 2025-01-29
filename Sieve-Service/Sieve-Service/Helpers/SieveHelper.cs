namespace Sieve_Service.Helpers
{
    public class SieveHelper
    {
        public static List<int> NthPrime(int n)
        {

            int limit = EstimateUpperBound(n+1);
            var primes = SieveOfEratosthenes(limit);

            if (n > primes.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            return primes;
        }

        private static List<int> SieveOfEratosthenes(int limit)
        {
            bool[] isPrime = new bool[limit + 1];
            for (int i = 2; i <= limit; i++)
            {
                isPrime[i] = true;
            }

            for (int i = 2; i * i <= limit; i++)
            {
                if (isPrime[i])
                {
                    for (int j = i * i; j <= limit; j += i)
                    {
                        isPrime[j] = false;
                    }
                }
            }

            var primes = new List<int>();
            for (int i = 2; i <= limit; i++)
            {
                if (isPrime[i])
                {
                    primes.Add(i);
                }
            }

            return primes;
        }

        private static int EstimateUpperBound(int n)
        {
            if (n < 6)
            {
                return 15;
            }

            return (int)(n * (Math.Log(n) + Math.Log(Math.Log(n))));
        }
    }
}
