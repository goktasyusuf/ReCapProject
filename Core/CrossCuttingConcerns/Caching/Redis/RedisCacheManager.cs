using Core.CrossCuttingConcerns.Caching.Redis.RedisServer;
using Core.Entities.Abstract;
using Newtonsoft.Json;

namespace Core.CrossCuttingConcerns.Caching.Redis
{
    public class RedisCacheManager<RedisContext, ServerConnection, TEntity> : ICacheManager<TEntity>
        where TEntity : class, IEntity, new()
        where RedisContext : class, IRedisKey, new()
        where ServerConnection : class, IRedisServerConnection, new()
    {
        private IRedisServerConnection serverConnection;
        RedisContext redisContext;
        public RedisCacheManager()
        {
            redisContext = new RedisContext();
            this.serverConnection = new ServerConnection();
        }

        public void Add(object value, int duration)
        {
            string jsonData = JsonConvert.SerializeObject(value);
            serverConnection.Database.StringSet(redisContext.KeyName, jsonData);
        }

        public TEntity Get()
        {
            if (IsAdd())
            {
                string jsonData = serverConnection.Database.StringGet(redisContext.KeyName);
                var a = JsonConvert.DeserializeObject<TEntity>(jsonData);
                return a;
            }
            return default;
        }
        public bool IsAdd()
        {
            return serverConnection.Database.KeyExists(redisContext.KeyName);
        }

        public void Remove()
        {
            serverConnection.Database.KeyDelete(redisContext.KeyName);
        }

        public void RemoveByPattern(string pattern)
        {
            throw new NotImplementedException();
        }
    }
}
