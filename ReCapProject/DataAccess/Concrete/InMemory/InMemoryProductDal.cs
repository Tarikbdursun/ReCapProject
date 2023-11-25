using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal //: IProductDal
    {
        private List<Car> _carList;

        public InMemoryProductDal()
        {
            _carList = new List<Car>
            {
                new Car{ID=1, ModelId=1, ColorID=1,ModelYear=1957,DailyPrice=10,Description="Garajın 1 numaralı arabası" },
                new Car{ID=2, ModelId=2, ColorID=2,ModelYear=1985,DailyPrice=20,Description="Garajın 2 numaralı arabası" },
                new Car{ID=3, ModelId=3, ColorID=3,ModelYear=1995,DailyPrice=25,Description="Garajın 3 numaralı arabası" },
                new Car{ID=4, ModelId=4, ColorID=4,ModelYear=2008,DailyPrice=30,Description="Garajın 4 numaralı arabası" },
                
            };
        }
        public void Add(Car car)
        {
            _carList.Add(car);
        }

        public void Delete(Car car)
        {
            var carToDelete = _carList.SingleOrDefault(x => x.ID == car.ID);

            _carList.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _carList;
        }

        public Car GetByID(int id)
        {
            return _carList.SingleOrDefault(x => x.ID == id); 
        }

        public void Update(Car car)
        {
            Car carToUpdated = _carList.SingleOrDefault(x => x.ID == car.ID);

            carToUpdated.ModelId = car.ModelId;
            carToUpdated.ColorID = car.ColorID;
            carToUpdated.DailyPrice = car.DailyPrice;
            carToUpdated.Description = car.Description;
        }
    }
}
