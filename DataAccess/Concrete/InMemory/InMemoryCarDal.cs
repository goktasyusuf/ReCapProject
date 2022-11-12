using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Concrete.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {

        List<Car> cars;

        public InMemoryCarDal()
        {
            cars = new List<Car>();
        }
        public void Add(Car entity)
        {
            cars.Add(entity);
        }

        public void Delete(Car entity)
        {
            Car temp = cars.SingleOrDefault(p => p.CarId == entity.CarId);
            cars.Remove(temp);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            return cars.AsQueryable().SingleOrDefault(filter);
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return filter == null ? cars.ToList() : cars.AsQueryable().Where(filter).ToList(); 
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorIdDto(int colorId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarDetailDto>> GetCarsByCarIdDto(int carId)
        {
            throw new NotImplementedException();
        }

        public void Update(Car entity)
        {
            Car temp = cars.SingleOrDefault(p => p.CarId == entity.CarId);
            temp.ModelYear=entity.ModelYear;
            Console.WriteLine(temp.ModelYear + " güncellendi ! ");
        }

        IDataResult<List<CarDetailDto>> ICarDal.GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}
