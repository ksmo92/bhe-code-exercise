using System.Collections.Concurrent;

namespace Sieve_Service.Repository
{
    public class PrimeCache
    {
        private readonly ConcurrentDictionary<int, int> _cache;

        public PrimeCache()
        {
            _cache = new ConcurrentDictionary<int, int>();
        }

        public bool TryGetValue(int key, out int value)
        {
            return _cache.TryGetValue(key, out value);
        }

        public void SetValue(int key, int value)
        {
            _cache[key] = value;
        }
    }
}