using System.Collections.Generic;

namespace S3Train.Domain
{
    public class Category : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string ParentId { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}