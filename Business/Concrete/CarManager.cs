using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Business.BusinessRules;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dto_s;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        readonly ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator),Priority = 2)]
        [SecuredOperation("admin,product.add",Priority = 1)]
        [TransactionScopeAspect]
        public IResult Add(Car entity)
        {
            var result = BusinessRules.Run(CheckIfCarNamesSame(entity.Description), CheckIfColorCountIsTrue(entity.ColorId));

            if (result != null)
            {
                return result;
            }
            _carDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(Car entity)
        {
            _carDal.Delete(entity);
            return new SuccessResult();
        }

        [CacheAspect]
        [PerformanceAspect(1)]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),"Veriler Başarıyla Getirildi.");
        }

        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(x=>x.Id == id));  
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }
        public IResult Update(Car entity)
        {
            _carDal.Update(entity);
            return new SuccessResult();
        }

        private IResult CheckIfColorCountIsTrue(int colorId)
        {
            var result = _carDal.GetAll(x => x.ColorId == colorId).Count;

            if (result > 10)
            {
                return new ErrorResult("Renk olarak maximum 10 araba olabilir");
            }
            return new SuccessResult();
        }

        private IResult CheckIfCarNamesSame(string carName)
        {
            var values = _carDal.GetAll(x => x.Description.Equals(carName));
            if (values.Any())
            {
                return new ErrorResult("Aynı isimde araba olamaz");
            }
            return new SuccessResult();
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsByBrandId(brandId), "ilgili markaya ait arabalar getirildi");
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsBycarId(int carId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsByCarId(carId), "ilgili id'ye ait araba getirildi");
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandAndColorId(int brandId, int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsByBrandAndColor(brandId, colorId),"İlgili Arabalar Getirildi");
        }

        public IDataResult<int> AddCarAndReturnCarId(Car car)
        {
            _carDal.Add(car);
            return new SuccessDataResult<int>(car.Id, "Araba Eklendi ve id'si geri döndü");
        }

    }
}
