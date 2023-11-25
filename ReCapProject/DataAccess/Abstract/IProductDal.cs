using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Car>
    {
        string GetModelAndBrand(int id);
        List<Car> GetCarsByBrandId(int brandId);
    }
}
