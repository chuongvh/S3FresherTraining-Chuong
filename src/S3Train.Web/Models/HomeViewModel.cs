using System.Collections.Generic;

namespace S3Train.Models
{
    public class HomeViewModel
    {
        public IList<SliderItemViewModel> SliderItems { get; set; }
        public IList<ProductViewModel> Products { get; set; }
    }
}