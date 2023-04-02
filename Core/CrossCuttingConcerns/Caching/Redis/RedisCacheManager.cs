using Core.CrossCuttingConcerns.Caching.Redis.RedisServer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StackExchange.Redis;

namespace Core.CrossCuttingConcerns.Caching.Redis
{
    public class RedisCacheManager : ICacheManager
    {
        private RedisServerConnection serverConnection;

        public RedisCacheManager(RedisServerConnection serverConnection)
        {
            this.serverConnection = serverConnection;
        }

        public void Add(string key, object value, int duration)
        {
            string jsonData = JsonConvert.SerializeObject(value);
            serverConnection.Database.StringSet(key,jsonData);
        }

        public T Get<T>(string key)
        {
            if(IsAdd(key))
            {
                string jsonData = serverConnection.Database.StringGet(key);
                return JsonConvert.DeserializeObject<T>(jsonData);
            }
            return default;
        }

        public object Get(string key)
        {
            var data = serverConnection.Database.StringGet(key);
            return JsonConvert.DeserializeObject(data);
            
        }

        public bool IsAdd(string key)
        {
            return serverConnection.Database.KeyExists(key);
        }

        public void Remove(string key)
        {
            serverConnection.Database.KeyDelete(key);
        }

        public void RemoveByPattern(string pattern)
        {
            throw new NotImplementedException();
        }
    }
}
