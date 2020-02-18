using System;
using System.Collections.Generic;

namespace S3Train.Domain
{
    public class Product : EntityBase
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public int Amount { get; set; }
        public string SKU { get; set; }
        public int? Rating { get; set; }

        public virtual Category Category { get; set; }
        //public virtual ICollection<ProductImage> ProductImage { get; set; }
    }
}