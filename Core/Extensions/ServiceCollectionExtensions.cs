using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependecyResolvers(this IServiceCollection serviceCollection, IDependencyInjectionModule[] modules)
        {
            foreach (var item in modules)
            {
                item.Load(serviceCollection);

            }
            return ServiceTool.Create(serviceCollection);
        }
    }
}
