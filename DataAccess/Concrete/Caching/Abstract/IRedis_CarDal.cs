using Core.CrossCuttingConcerns.Caching;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Caching.Abstract
{
    public interface IRedis_CarDal : ICacheManager<Car>
    {
    }
}
