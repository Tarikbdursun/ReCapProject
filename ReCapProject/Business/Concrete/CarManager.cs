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
        private ICarDal _iCarDal;
        public CarManager(ICarDal iCardal)
        {
            _iCarDal = iCardal;
        }
        public List<Car> GetAll()
        {
            //Business Codes

            return _iCarDal.GetAll();
        }
    }
}
