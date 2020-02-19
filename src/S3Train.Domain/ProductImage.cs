using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.Domain
{
    public class ProductImage : EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; } 
        public string ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
