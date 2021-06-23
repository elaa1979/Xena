using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Xena.Application.Utils
{
    public class CacheHelper
    {
        private readonly IConfiguration _config;
        public CacheHelper(IConfiguration config)
        {
            _config = config;
        }
        public int GetCacheTime(string key)
        {
            int cacheTime;

            string keyValue = _config.GetSection(string.Format("Caching:{0}", key)).Value;

            if (string.IsNullOrWhiteSpace(keyValue))
                keyValue = _config.GetSection(string.Format("Caching:DefaultCacheExpiryInSec", key)).Value;

            if (int.TryParse(keyValue, out cacheTime))
                return cacheTime;

            return 0;
        }
    }
}
