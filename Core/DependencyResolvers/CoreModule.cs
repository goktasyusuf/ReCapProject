using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.CrossCuttingConcerns.Caching.Redis;
using Core.CrossCuttingConcerns.Caching.Redis.RedisServer;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace Core.DependencyResolvers
{
    public class CoreModule : IDependencyInjectionModule 
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();
            serviceCollection.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
            serviceCollection.AddSingleton<Stopwatch>();
            serviceCollection.AddSingleton<RedisServerConnection>();
            //serviceCollection.AddSingleton<ICacheManager,RedisCacheManager>();
        }
    }
}
