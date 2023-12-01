using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Car, CarRentalDbContext>, IProductDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentalDbContext context = new CarRentalDbContext())
            {
                var result = from c in context.Products
                             join m in context.Models
                             on c.ModelId equals m.Id
                             join b in context.Brands
                             on m.BrandId equals b.Id
                             join clr in context.Colors
                             on c.ColorId equals clr.Id
                             join r in context.Rentals
                             on c.Id equals r.CarId
                             into rGruop
                             from rental
                             in rGruop.DefaultIfEmpty()
                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 ModelName = m.Name,
                                 BrandName = b.Name,
                                 DailyPrice = c.DailyPrice,
                                 ColorName = clr.ColorName,
                                 IsAvaliableToRenting = rental == null || 
                                    rental != null && rental.ReturnDate != null
                             };
                return result.ToList();
            };
        }
    }
}

