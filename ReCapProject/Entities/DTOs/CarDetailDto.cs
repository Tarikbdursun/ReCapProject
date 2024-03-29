﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto : IDto
    {
        public int CarId { get; set; }
        public string ModelName { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public decimal DailyPrice { get; set; }

        public bool IsAvaliableToRenting { get; set; }
        public string AvaibleIndıcator 
        {
            get
            {
                return IsAvaliableToRenting
                    ? "Avaliable For Renting"
                    : "Not Avaliable For Renting";
            }
        }
    }
}
