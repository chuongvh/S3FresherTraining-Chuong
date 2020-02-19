using System;

namespace S3Train.Models
{
    public class ProductViewModel
    {
        public string Id { get; set; }
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DisplayPrice { get; set; }
        public int Rating { get; set; }
    }
}