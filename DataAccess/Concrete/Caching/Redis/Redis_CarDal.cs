using Core.CrossCuttingConcerns.Caching.Redis;
using Core.CrossCuttingConcerns.Caching.Redis.RedisServer;
using DataAccess.Concrete.Caching.Abstract;
using DataAccess.Concrete.Caching.Redis.Context;
using Entities.Concrete;

namespace DataAccess.Concrete.Caching.Redis
{
    public class Redis_CarDal : RedisCacheManager<CarKey, RedisServerConnection, Car>, IRedis_CarDal
    {
    }
}
