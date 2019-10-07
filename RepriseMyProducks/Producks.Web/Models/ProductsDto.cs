﻿using System;
namespace Producks.Web.Models
{
    public class ProductsDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int StockLevel { get; set; }
        public bool Active { get; set; }

    }
}
