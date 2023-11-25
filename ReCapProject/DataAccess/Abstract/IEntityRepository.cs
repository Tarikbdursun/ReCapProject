using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IEntityRepository<T> where T: IEntity, new()
    {
        //GetById, GetAll, Add, Update, Delete
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T GetByID(int id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
