using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public string GetByIdModelAndBrand(int id)
        {
            return _iCarDal.GetModelAndBrand(id);
        }
        //GetCarsByBrandId , GetCarsByColorId servislerini yazınız.

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _iCarDal.GetCarsByBrandId(brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _iCarDal.GetAll(car=>car.ColorID == colorId);

        }
    }
}
