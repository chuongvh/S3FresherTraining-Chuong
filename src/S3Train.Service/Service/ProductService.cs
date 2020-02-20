using System;
using System.Collections.Generic;
using System.Linq;
using S3Train.Contract;
using S3Train.Domain;
using X.PagedList;

namespace S3Train.Service
{
    public class ProductService : GenenicServiceBase<Product>, IProductService
    {
        public ProductService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public bool CheckAmoutProductById(string id, int amount)
        {
            Product product = EntityDbSet.SingleOrDefault(x => x.Id == id);
            if(product !=null)
            {
                return (product.Amount >= amount);
            }
            return false;
        }

        public IList<Product> GetAllProductByCategoryId(string category)
        {
            throw new NotImplementedException();
        }
    }
}