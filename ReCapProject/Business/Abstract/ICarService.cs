﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<CarDetailDto>> GetCarDetails();

        IDataResult<Car> GetById(int id);

        IResult AddCar(Car car);
        IResult DeleteCar(Car car);
        IResult UpdateCar(Car car);
    }
}
