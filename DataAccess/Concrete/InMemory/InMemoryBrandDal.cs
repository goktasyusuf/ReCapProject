using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryBrandDal : IBrandDal
    {

        List<Brand> brands;

        public InMemoryBrandDal()
        {
            brands = new List<Brand>
            {
                new Brand {BrandId=1,BrandName="Mercedes"},
                new Brand { BrandId=2,BrandName="Opel" },
                new Brand {BrandId=3,BrandName="BMW"  }
            };
        }
        public void Add(Brand entity)
        {
            brands.Add(entity);
        }

        public void Delete(Brand entity)
        {
            Brand temp = brands.SingleOrDefault(p => p.BrandId == entity.BrandId);
            brands.Remove(temp);
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            return brands.AsQueryable().SingleOrDefault(filter);
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            return filter == null ? brands.ToList() : brands.AsQueryable().Where(filter).ToList();
        }

        public void Update(Brand entity)
        {
            Brand temp = brands.SingleOrDefault(p => p.BrandId == entity.BrandId);
            temp.BrandName = entity.BrandName;
            temp.BrandId = entity.BrandId;
            Console.WriteLine(temp.BrandName  + " güncellendi ! ");
        }
    }
}
