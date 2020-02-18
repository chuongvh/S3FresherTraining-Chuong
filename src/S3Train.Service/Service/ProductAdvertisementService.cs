using System.Collections.Generic;
using System.Linq;
using S3Train.Contract;
using S3Train.Domain;

namespace S3Train.Service
{
    public class ProductAdvertisementService : GenenicServiceBase<ProductAdvertisement>, IProductAdvertisementService
    {
        public ProductAdvertisementService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public IList<ProductAdvertisement> GetSliderItems()
        {
            return this.EntityDbSet.Where(x => x.AdType == ProductAdvertisementType.SliderBanner && x.IsActive).ToList();
        }
    }
}