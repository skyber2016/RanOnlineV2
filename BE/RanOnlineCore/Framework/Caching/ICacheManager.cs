
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);

        void Set(string key, object data, int cacheTimeByMinute);

        bool IsSet(string key);

        void Remove(string key);

        void RemoveByPattern(string Pattern);

        void Clear();
    }
}
