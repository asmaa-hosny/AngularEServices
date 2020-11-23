using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;


namespace CommonLibrary.Caching
{
    public interface ICachService
    {
        void SetCache(string key, object value, TimeSpan validFor);

        void SetCache(string key, object value, DateTimeOffset expireAt);

        T GetOrCreate<T>(string key, Func<ICacheEntry, T> factory);

        void Remove<T>(List<string> key);

        void Remove<T>(string key);

        object Get<T>(string key);

        bool Exists(string key, out object value);

        bool IsCacheEnabled { get; }


    }
}
