using Core.Utilities.IoC;
using DataAccess.Concrete.Caching.Abstract;
using DataAccess.Concrete.Caching.Redis;
using Microsoft.Extensions.DependencyInjection;

namespace Business.DependencyResolvers
{
    public class BusinessModule : IDependencyInjectionModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IRedis_CarDal, Redis_CarDal>();
        }
    }
}
