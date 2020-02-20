using System;
using System.Collections.Generic;
using S3Train.Domain;

namespace S3Train.Contract
{
    public interface IProductService : IGenenicServiceBase<Product>
    {
        IList<Product> GetAllProductByCategoryId(string category);
        bool CheckAmoutProductById(string id, int amount);
    }
}
