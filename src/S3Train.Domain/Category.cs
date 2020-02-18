using System.Collections.Generic;

namespace S3Train.Domain
{
    public class Category : EntityBase
    {
        public string name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public int ParentId { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}