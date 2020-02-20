using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using S3Train.Domain;
using S3Train.Service;
using X.PagedList;

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

        public T Create(T entity)
        {
            try
            {
                EntityDbSet.Add(entity);
                DbContext.SaveChanges();
                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        public IPagedList<T> getAllPaged()
        {
            throw new NotImplementedException();
        }
        public T GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public T Update(T entity)
        {
            try
            {
                EntityDbSet.Add(entity);
                DbContext.SaveChanges();
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get entity by Id, return null if not found
        /// </summary>
        /// <param name="id">The identifier.</param>
        public T GetById(string id)
        {
            return EntityDbSet.SingleOrDefault(x => x.Id == id);
        }

    }
}
