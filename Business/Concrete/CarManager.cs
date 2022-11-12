using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
using Business.Validation.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Entities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Concrete.DTO_s;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationException = FluentValidation.ValidationException;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {

        ICarDal carDal;

        public CarManager(ICarDal carDal)
        {
            this.carDal = carDal;
        }

 

        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("car.add,admin")]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Car car)
        {
            carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(carDal.GetAll());
        }

        public IDataResult<Car> GetCarById(int carId)
        {
            return new SuccessDataResult<Car>(carDal.Get(p => p.CarId == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(carDal.GetCarDetails().data);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(carDal.GetCarDetailsByBrandId(brandId).data);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorIdDto(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(carDal.GetCarDetailsByColorIdDto(colorId).data);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(carDal.GetAll(p => p.BrandId == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarsByCarIdDto(int carId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(carDal.GetCarsByCarIdDto(carId).data);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(carDal.GetAll(p => p.ColorId == id));
        }
    }
}
