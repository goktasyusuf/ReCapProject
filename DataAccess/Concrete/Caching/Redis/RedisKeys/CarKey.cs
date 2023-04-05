using Core.CrossCuttingConcerns.Caching.Redis.RedisServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Caching.Redis.Context
{
    public class CarKey : IRedisKey
    {
        public string KeyName { get; set; }
        public CarKey()
        {
            KeyName = "1:Car";
        }
    }
}
