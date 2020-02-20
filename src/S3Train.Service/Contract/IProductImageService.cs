using S3Train.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.Contract
{
    public interface IProductImageService : IGenenicServiceBase<ProductImage>
    {
        IList<ProductImage> GetAllProducImagetByProductId(string productId);
    }
}
