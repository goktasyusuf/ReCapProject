using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching.Redis.RedisServer
{
    public interface IRedisServerConnection
    {
        IDatabase Database { get; set; }
    }
}
