using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();

        IDataResult<CarImage> GetById(int id);

        IDataResult<List<CarImage>> GetImagesByCarId(int carId);

        IResult AddCarImage(IFormFile file,CarImage carImage);
        IResult DeleteCarImage(CarImage carImage);
        IResult UpdateCarImage(IFormFile file,CarImage carImage);
    }
}
