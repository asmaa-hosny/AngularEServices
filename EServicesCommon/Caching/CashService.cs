using CommonLibrary.Caching;
using CommonLibrary.Configuaration;
using EServicesCommon.Configuaration;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EServicesCommon.Caching
{
    public class CashService : ICachService
    {
        private ICoreConfigurations _configuaration;
        private IMemoryCache _cache;

        public CashService(ICoreConfigurations config, IMemoryCache cache)
        {
            _configuaration = config;
            this._cache = cache;
        }
        public bool IsCacheEnabled => _configuaration.EnableCaching;

        public bool Exists(string key, out object value)
        {
           var result= _cache.TryGetValue(key, out value);
            return result;
        }

        public object Get<T>(string key)
        {
            return _cache.Get(key);
        }

        public void Remove<T>(string key)
        {
            _cache.Remove(key);
        }

        public void Remove<T>(List<string> key)
        {
            throw new NotImplementedException();
        }

        public T GetOrCreate<T>(string key, Func<ICacheEntry, T> factory)
        {
            return _cache.GetOrCreate<T>(key, factory);
        }

        public void SetCache(string key, object value, DateTimeOffset expireAt)
        {
            _cache.Set(key, value, expireAt);
        }

        public void SetCache(string key, object value, TimeSpan validFor)
        {
            _cache.Set(key, value, validFor);
        }

     
    }
}
