using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal,IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult AddCarImage(IFormFile file,CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarMaxImageCount(carImage.CarId));

            if (result != null)
                return result;

            carImage.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult DeleteCarImage(CarImage carImage)
        {
            _fileHelper.Delete(PathConstants.ImagesPath + carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }
        
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult UpdateCarImage(IFormFile file,CarImage carImage)
        {
            carImage.ImagePath = _fileHelper.Update
                (file, PathConstants.ImagesPath + carImage.ImagePath, PathConstants.ImagesPath);
            carImage.Date = DateTime.Today;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.GetByID(id));
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckCarHasImage(carId));

            if (result != null)
                GetDefaultImage();

            var carImages = _carImageDal.GetAll(x => x.CarId == carId);
            return new SuccessDataResult<List<CarImage>>(carImages);
        }

        private IResult CheckIfCarMaxImageCount(int carId)
        {
            var imageCountOfTheCar = _carImageDal.GetAll(x => x.CarId == carId).Count;
            if(imageCountOfTheCar >= 5)
                return new ErrorResult();
                
            return new SuccessResult();
        }

        private IDataResult<List<CarImage>> GetDefaultImage()
        {
            CarImage defaultImagecarImage = new CarImage 
            {
                CarId = 0, Date = DateTime.Now, ImagePath = "defaultImage.jpg" 
            };

            List<CarImage> defaultImages = new List<CarImage> { defaultImagecarImage };

            return new SuccessDataResult<List<CarImage>>(defaultImages); 
        }

        private IResult CheckCarHasImage(int id)
        {
            var imagesList = _carImageDal.GetAll(x => x.CarId == id);
            if (imagesList.Count <= 0)
                return new ErrorResult();

            return null;
        }
    }
}
