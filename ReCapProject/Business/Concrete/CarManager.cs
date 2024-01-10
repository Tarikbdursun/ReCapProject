using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Business;
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
        private IProductDal _carDal;
        private IModelService _modelService;

        public CarManager(IProductDal iCardal, IModelService modelService)
        {
            _carDal = iCardal;
            _modelService = modelService;
        }
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<Car> GetById(int id)
        {
            if (!GetAll().Data.Any(x => x.Id == id))
                return new ErrorDataResult<Car>();

            return new SuccessDataResult<Car>(_carDal.GetByID(id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            if (GetAll().Data.Any(x => x.ColorId != colorId))
                return new ErrorDataResult<List<Car>>();

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(car => car.ColorId == colorId));

        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult AddCar(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfModelLimitExceded());

            if (result != null)
                return result;

            _carDal.Add(car);
            return new SuccessResult(Messages.ProductAdded);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult DeleteCar(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.ProductDeleted);
        }
        
        [ValidationAspect(typeof(CarValidator))]
        public IResult UpdateCar(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.ProductDeleted);
        }

        private IResult CheckIfModelLimitExceded()
        {
            int modelCount = _modelService.GetAll().Data.Count;
            if (modelCount > 15)
                return new ErrorResult();

            return new SuccessResult();
        }
    }
}
