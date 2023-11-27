using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Linq;

namespace LayerUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfProductDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            GetAllCarsDetail(carManager);
            //clrManager.GetAll().ForEach(x => Console.WriteLine(x.ColorName));
            
        }

        private static void GetAllCarsDetail(CarManager carManager)
            => carManager.GetCarDetails().ForEach
            (x => Console.WriteLine($"{x.CarId} {x.BrandName} {x.ModelName} {x.ColorName} {x.DailyPrice}"));
        

        private static void AddCarTest(CarManager carManager, Car car)
            => carManager.AddCar(car);


        private static void DeleteCarTest(CarManager carManager, Car car) 
            => carManager.DeleteCar(car);
    }
}
