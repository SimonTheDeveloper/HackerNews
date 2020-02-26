using System;
using System.Runtime.Caching;

namespace HackerNews
{
    public class MemoryCacheProvider
    {

        public static object GetValue(string key)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            return memoryCache.Get(key);
        }


        public static bool Add(string key, object value, DateTimeOffset absExpiration)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            return memoryCache.Add(key, value, absExpiration);
        }
    }
}
