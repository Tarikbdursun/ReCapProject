using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;
using System.Linq;

namespace LayerUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryProductDal());

            Console.WriteLine(carManager.GetAll().FirstOrDefault().Description);
            Console.WriteLine(carManager.GetAll().LastOrDefault().Description);
        }
    }
}
