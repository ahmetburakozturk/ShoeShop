﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShop.Dtos.Responses
{
    public class ProductListResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public double? Discount { get; set; }
        public bool? IsActive { get; set; }
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
        public int GenderID { get; set; }
        public int BrandID { get; set; }
        public int ColorID { get; set; }
    }
}