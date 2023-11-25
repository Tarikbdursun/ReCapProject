using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class VehicleType : IEntity
    {
        public int Id { get; set; }
        public  string Type { get; set; }
    }
}
