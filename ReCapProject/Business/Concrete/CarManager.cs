using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private IProductDal _iCarDal;
        public CarManager(IProductDal iCardal)
        {
            _iCarDal = iCardal;
        }
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll());
        }

        public IDataResult<Car> GetById(int id)
        {
            if (!GetAll().Data.Any(x => x.Id == id))
                return new ErrorDataResult<Car>();

            return new SuccessDataResult<Car>(_iCarDal.GetByID(id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            if (GetAll().Data.Any(x => x.ColorId != colorId))
                return new ErrorDataResult<List<Car>>();

            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(car => car.ColorId == colorId));

        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult AddCar(Car car)
        {   
            _iCarDal.Add(car);
            return new SuccessResult(Messages.ProductAdded);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult DeleteCar(Car car)
        {
            _iCarDal.Delete(car);
            return new SuccessResult(Messages.ProductDeleted);
        }
        
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _iCarDal.Update(car);
            return new SuccessResult(Messages.ProductDeleted);
        }
    }
}
