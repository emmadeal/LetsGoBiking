using System;
using System.Runtime.Caching;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    internal class Cache<T> where T : class
    {
        ObjectCache cache = MemoryCache.Default;
        DateTimeOffset dt_default = ObjectCache.InfiniteAbsoluteExpiration;
        public T Get(string CacheItem)
        {
            T obj = (T)cache.Get(CacheItem);
            if (obj != null)
                return obj;
            T newObj = (T)Activator.CreateInstance(typeof(T), CacheItem);
            cache.Add(CacheItem, newObj, dt_default);
            return newObj;
        }
        public T Get(string CacheItem, double dt_seconds)
        {
            T obj = (T)cache.Get(CacheItem);
            if (obj != null)
                return obj;
            T newObj = (T)Activator.CreateInstance(typeof(T), CacheItem);
            DateTimeOffset seconds = new DateTimeOffset();
            seconds.AddSeconds(dt_seconds);
            cache.Add(CacheItem, newObj, seconds);
            return newObj;
        }
        public T Get(string CacheItem, DateTimeOffset dt)
        {
            T obj = (T)cache.Get(CacheItem);
            if (obj != null)
                return obj;
            T newObj = (T)Activator.CreateInstance(typeof(T), CacheItem);
            cache.Add(CacheItem, newObj, dt);
            return newObj;
        }

        public ObjectCache getCache()
        {
            return this.cache;
        }
    }
}
