using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Core.Utilities.Results;
using DataAccess.Concrete.Caching.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Business.BusinessAspects.Autofac
{
    public class CarCaching : MethodInterception
    {
        private IRedis_CarDal _redisCarDal;

        public CarCaching()
        {
            _redisCarDal = ServiceTool.ServiceProvider.GetService<IRedis_CarDal>();

        }

        public override void Intercept(IInvocation invocation)
        {
            var result = _redisCarDal.Get();
            //IDataResult<result> x;
            if (result != null)
                invocation.ReturnValue = result;
            else
            {
                invocation.Proceed();
                _redisCarDal.Add(invocation.ReturnValue, 5);
                return;
            }
        }
    }
}
