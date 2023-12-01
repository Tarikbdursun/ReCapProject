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
            //ColorManager colorManager = new ColorManager(new EfColorDal());
            //UserManager userManager = new UserManager(new EfUserDal());
            //CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            //GetAllCarsDetail(carManager);
            //clrManager.GetAll().ForEach(x => Console.WriteLine(x.ColorName));
            //carManager.GetCarDetails().Data.ForEach(x => Console.WriteLine
            //(
            //    $"{x.ModelName},{x.BrandName},{x.DailyPrice}, {x.AvaibleIndıcator}"
            //));

            //S400 id=1
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.GetAll().Data.ForEach(x => Console.WriteLine(x.Id + " " + x.CarId));
            Rental newRental = new Rental()
            {
                Id = rentalManager.GetAll().Data.LastOrDefault().Id + 1,
                CarId = 1,
                CustomerId = 1,
                RentDate = DateTime.Today,
                ReturnDate = null
            };
            
            rentalManager.Add(newRental);
            rentalManager.GetAll().Data.ForEach(x => Console.WriteLine(x.Id + " " + x.CarId));
        }

        private static void GetAllCarsDetail(CarManager carManager)
            => carManager.GetCarDetails().Data.ForEach
            (x => Console.WriteLine($"{x.CarId} {x.BrandName} {x.ModelName} {x.ColorName} {x.DailyPrice}"));


        private static void AddCarTest(CarManager carManager, Car car)
            => carManager.AddCar(car);


        private static void DeleteCarTest(CarManager carManager, Car car)
            => carManager.DeleteCar(car);

        private static void AddNewUser(UserManager userManager, User newUser)
        {
            userManager.Add(newUser);
            userManager.GetAll().Data.ForEach(x => Console.WriteLine($"Name:{x.FirstName} Last Name:{x.LastName}"));
        }
    }
}
