using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Car entity)
        {
            using (CarRentalDbContext context = new CarRentalDbContext())
            {
                //Find the referance
                var addedEntity = context.Entry(entity);
                //Add to db
                addedEntity.State = EntityState.Added;
                //Save Changes
                context.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (CarRentalDbContext context = new CarRentalDbContext())
            {
                //Find the referance
                var addedEntity = context.Entry(entity);
                //Add to db
                addedEntity.State = EntityState.Deleted;
                //Save Changes
                context.SaveChanges();
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (CarRentalDbContext context = new CarRentalDbContext())
            {
                return filter == null
                    ? context.Set<Car>().ToList()
                    : context.Set<Car>().Where(filter).ToList();

            }
        }

        public Car GetByID(int id)
        {
            using (CarRentalDbContext context = new CarRentalDbContext())
            {
                return context.Set<Car>().SingleOrDefault(x => x.ID == id);
            }
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            using (CarRentalDbContext context = new CarRentalDbContext())
            {
                List<Model> models = context.Set<Model>().Where(x => x.BrandId == brandId).ToList();

                return (from car in GetAll()
                       join model in models on car.ModelId equals model.Id
                       select car)
                       .ToList();                
            }
        }

        public string GetModelAndBrand(int id)
        {
            using (CarRentalDbContext context = new CarRentalDbContext())
            {
                var returnedModel = context.Set<Model>().SingleOrDefault(x => x.Id == GetByID(id).ModelId);
                var returnedBrand = context.Set<Brand>().SingleOrDefault(x => x.Id == returnedModel.BrandId);
                return $"{returnedModel.Name} , {returnedBrand.Name}";
            }
        }

        public void Update(Car entity)
        {
            using (CarRentalDbContext context = new CarRentalDbContext())
            {
                //Find the referance
                var addedEntity = context.Entry(entity);
                //Add to db
                addedEntity.State = EntityState.Modified;
                //Save Changes
                context.SaveChanges();
            }
        }
    }
}
