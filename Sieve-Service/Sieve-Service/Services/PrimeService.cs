using System.IO.Pipelines;
using Sieve_Service.Helpers;
using Sieve_Service.Repository;

namespace Sieve_Service.Services
{
    public interface IPrimeService
    {
        Task<int> GetNthPrime(int n);
        Task<bool> GetTwinPrime(int n);
    }
    public class PrimeService : IPrimeService
    {
        private readonly PrimeCache _cache = new PrimeCache();
        public async Task<int> GetNthPrime(int n)
        {
            if (n < 1)
                throw new ArgumentOutOfRangeException();

            if (_cache.TryGetValue(n, out int cachedPrime))
            {
                return cachedPrime;
            }
            // Calculate the nth prime
            var prime = SieveHelper.NthPrime(n);

            // Store the calculated prime in the cache
            _cache.SetValue(n, prime[n-1]);

            return prime[n-1];
        }

        public async Task<bool> GetTwinPrime(int n)
        {
            if (n < 1)
                throw new ArgumentOutOfRangeException();

            // Calculate the nth prime
            var prime = SieveHelper.NthPrime(n);

            if (prime[n-1] - 2 == prime[n - 2] || prime[n-1] + 2 == prime[n])
            {
               return true;
            }


            return false;
        }
    }
}
