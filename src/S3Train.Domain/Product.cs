using System;
using System.Collections.Generic;

namespace S3Train.Domain
{
    public class Product : EntityBase
    {
        //public string CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public string SKU { get; set; }
        public string Status { get; set; }
        public int? Rating { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
    }
}