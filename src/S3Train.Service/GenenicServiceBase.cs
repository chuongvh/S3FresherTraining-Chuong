using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using S3Train.Domain;

namespace S3Train
{
    /// <summary>
    /// Base generic class for Service
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class GenenicServiceBase<T> : IGenenicServiceBase<T> where T : EntityBase
    {
        protected readonly ApplicationDbContext DbContext;

        protected DbSet<T> EntityDbSet => DbContext.Set<T>();

        protected GenenicServiceBase(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        /// <summary>
        /// Select all data
        /// </summary>
        /// <returns></returns>
        public List<T> SelectAll()
        {
            return EntityDbSet.ToList();
        }

        /// <summary>
        /// Get entity by Id, return null if not found
        /// </summary>
        /// <param name="id">The identifier.</param>
        public T GetById(Guid id)
        {
            return EntityDbSet.SingleOrDefault(x => x.Id == id);
        }

    }
}
