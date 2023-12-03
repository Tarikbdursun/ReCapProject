using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        public IResult AddCar(Car car)
        {           
            if (_iCarDal.GetAll().Any(x => x.Id == car.Id))
                return new ErrorResult();
            
            _iCarDal.Add(car);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult DeleteCar(Car car)
        {
            if (GetAll().Data.All(x=>x.Id!=car.Id))
                return new ErrorResult();

            _iCarDal.Delete(car);
            return new SuccessResult(Messages.ProductDeleted);
        }
    }
}
