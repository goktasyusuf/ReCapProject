using Core.Utilities.IoC;
using Core.Utilities.Results;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching.Redis
{
    public class RedisCacheManager : ICacheManager
    {

        IDistributedCache _distributedCache;

        public RedisCacheManager()
        {
            _distributedCache = ServiceTool.ServiceProvider.GetService<IDistributedCache>();
        }

        public void Add(string key, object value, int duration)
        {
            var x = JsonConvert.SerializeObject(value);
            _distributedCache.SetString(key,x, new DistributedCacheEntryOptions()
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(duration)
            });
        }

        public T Get<T>(string key)
        {
            throw new NotImplementedException();
        }

        public object Get(string key)
        {
            var x = _distributedCache.GetString(key);
            return _distributedCache.GetString(key);
        }

        public bool IsAdd(string key)
        {
            if(_distributedCache.GetString(key)==null)
            {
                return false;
            }
            return true;
        }

        public void Remove(string key)
        {
            _distributedCache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            throw new NotImplementedException();
        }
    }
}
