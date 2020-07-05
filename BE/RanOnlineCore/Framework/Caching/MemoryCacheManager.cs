using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using System.Text.RegularExpressions;

namespace PA.Caching
{
    /// <summary>
    /// Represents a manager for caching between HTTP requests (long term caching)
    /// </summary>
    public partial class MemoryCacheManager : ICacheManager
    {
        static ICacheManager _instance;
        public static ICacheManager Instance
        {
            get
            {
                if(_instance == null)
                    _instance = new MemoryCacheManager();
                return _instance;
            }
        }
        /// <summary>
        /// Cache object
        /// </summary>
        protected ObjectCache Cache
        {
            get
            {
                return MemoryCache.Default;
            }
        }
        
        /// <summary>
        /// Gets or sets the value associated with the specified key.
        /// </summary>
        /// <typePAram name="T">Type</typePAram>
        /// <PAram name="key">The key of the value to get.</PAram>
        /// <returns>The value associated with the specified key.</returns>
        public virtual T Get<T>(string key)
        {
            return (T)Cache[key];
        }

        /// <summary>
        /// Adds the specified key and object to the cache.
        /// </summary>
        /// <PAram name="key">key</PAram>
        /// <PAram name="data">Data</PAram>
        /// <PAram name="cacheTimeByMinute">Cache time</PAram>
        public virtual void Set(string key, object data, int cacheTimeByMinute)
        {
            if (data == null)
                return;

            var policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTimeByMinute);
            Cache.Add(new CacheItem(key, data), policy);
        }

        /// <summary>
        /// Gets a value indicating whether the value associated with the specified key is cached
        /// </summary>
        /// <PAram name="key">key</PAram>
        /// <returns>Result</returns>
        public virtual bool IsSet(string key)
        {
            return (Cache.Contains(key));
        }

        /// <summary>
        /// Removes the value with the specified key from the cache
        /// </summary>
        /// <PAram name="key">/key</PAram>
        public virtual void Remove(string key)
        {
            Cache.Remove(key);
        }

        /// <summary>
        /// Removes items by PAttern
        /// </summary>
        /// <PAram name="PAttern">PAttern</PAram>
        public virtual void RemoveByPattern(string Pattern)
        {
            var regex = new Regex(Pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = new List<String>();

            foreach (var item in Cache)
                if (regex.IsMatch(item.Key))
                    keysToRemove.Add(item.Key);

            foreach (string key in keysToRemove)
            {
                Remove(key);
            }
        }

        /// <summary>
        /// Clear all cache data
        /// </summary>
        public virtual void Clear()
        {
            foreach (var item in Cache)
                Remove(item.Key);
        }
    }
}