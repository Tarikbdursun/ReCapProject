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
    public class EfModelDal : IModelDal
    {
        public void Add(Model entity)
        {
            using (CarRentalDbContext context = new CarRentalDbContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Model entity)
        {
            using (CarRentalDbContext context = new CarRentalDbContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<Model> GetAll(Expression<Func<Model, bool>> filter = null)
        {
            using (CarRentalDbContext context = new CarRentalDbContext())
            {
                return (filter == null
                ? context.Set<Model>()
                : context.Set<Model>().Where(filter)).ToList();
            }
        }

        public Model GetByID(int id)
        {
            using (CarRentalDbContext context=new CarRentalDbContext())
            {
                return context.Set<Model>().SingleOrDefault(x => x.Id == id);
            }
        }

        public void Update(Model entity)
        {
            using (CarRentalDbContext context=new CarRentalDbContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
