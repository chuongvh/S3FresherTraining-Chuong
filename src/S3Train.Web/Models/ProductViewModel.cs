using System;

namespace S3Train.Models
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string DisplayPrice { get; set; }
        public int Rating { get; set; }
    }
}