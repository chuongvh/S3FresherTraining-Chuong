using S3Train.Contract;
using S3Train.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace S3Train.Service
{
    public class CategoryService : GenenicServiceBase<Category>, ICategoryService
    {
        public CategoryService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public IList<Category> GetAllCategoryByProductId(string productId)
        {
            throw new NotImplementedException();
        }
    }
}
