using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>
        where TEntity : class,IEntity,new()
        where TContext: DbContext,new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                //Find the referance
                var addedEntity = context.Entry(entity);
                //Add to db
                addedEntity.State = EntityState.Added;
                //Save Changes
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                //Find the referance
                var addedEntity = context.Entry(entity);
                //Add to db
                addedEntity.State = EntityState.Deleted;
                //Save Changes
                context.SaveChanges();
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public TEntity GetByID(int id)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(x => x.Id == id);
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
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
