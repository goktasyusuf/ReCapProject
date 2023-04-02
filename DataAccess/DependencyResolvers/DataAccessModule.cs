using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DependencyResolvers
{
    public class DataAccessModule : IDependencyInjectionModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
        }
    }
}
