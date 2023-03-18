using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dto_s;
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
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>();
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            var temp = _cars.SingleOrDefault(x=> x.Id == car.Id);
            _cars.Remove(temp);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
           return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            var car = _cars.Find(x => x.Id == id);
            return car;
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailsByBrandId(int brandId)
        {
            throw new NotImplementedException();
        }

        public CarDetailDto GetCarDetailsByCarId(int carId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarsByBrandAndColor(int brandId, int colorId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarsByColorAndBrand(int brandId, int colorId)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            var temp = _cars.SingleOrDefault(x => x.Id == car.Id);
            temp.Description = car.Description;
            temp.DailyPrice = car.DailyPrice;
            temp.ModelYear = car.ModelYear;
        }

        List<CarDetailDto> ICarDal.GetCarDetailsByCarId(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
