using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
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
        public List<Car> GetAll()
        {
            //Business Codes

            return _iCarDal.GetAll();
        }

        public Car GetById(int id)
        {
            return _iCarDal.GetByID(id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _iCarDal.GetCarDetails();
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _iCarDal.GetAll(car=>car.ColorId == colorId);

        }

        public void AddCar(Car car)
        {
            _iCarDal.Add(car);
        }

        public void DeleteCar(Car car)
        {
            _iCarDal.Delete(car);
        }
    }
}
