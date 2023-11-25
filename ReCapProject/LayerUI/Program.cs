using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;
using System.Linq;

namespace LayerUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfProductDal());

            //Console.WriteLine(carManager.GetAll().FirstOrDefault().DailyPrice);
            //Console.WriteLine(carManager.GetAll().LastOrDefault().ModelId);
           

            //foreach (var c in carManager.GetCarsByBrandId(1))
            //{
            //    Console.WriteLine(carManager.GetByIdModelAndBrand(c.ID));
            //}
            foreach (var c in carManager.GetCarsByColorId(7))
            {
                Console.WriteLine(carManager.GetByIdModelAndBrand(c.ID));
            }
        }
    }
}
