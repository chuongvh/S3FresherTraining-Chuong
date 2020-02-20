using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using S3Train.Domain;
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

        protected readonly DbSet<T> EntityDbSet;

        protected GenenicServiceBase(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
            EntityDbSet = dbContext.Set<T>();
        }

        public IQueryable<T> Query()
        {
            return EntityDbSet;
        }

        public List<T> GetAll()
        {
            return EntityDbSet.ToList();
        }

        public List<T> GetAll(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy)
        {
            return orderBy(EntityDbSet).ToList();
        }

        public IEnumerable<T> Gets(Expression<Func<T, bool>> predicate)
        {
            return EntityDbSet.Where(predicate).ToList();
        }

        public IEnumerable<T> Gets(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy)
        {
            return orderBy(EntityDbSet.Where(predicate)).ToList();
        }

        public T GetById(string id)
        {
            return EntityDbSet.Find(id);
        }

        public T Get(Expression<Func<T, bool>> predicate) 
        {
            return EntityDbSet.FirstOrDefault(predicate);
        }

        public T Get(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy)
        {
            return orderBy(EntityDbSet.Where(predicate)).FirstOrDefault();
        }

        public T Add(T item)
        {
            var result = EntityDbSet.Add(item);
            DbContext.SaveChanges();
            return result;
        }

        public void Add(List<T> items)
        {
            EntityDbSet.AddRange(items);
            DbContext.SaveChanges();
        }

        public T Update(T item)
        {
            EntityDbSet.Attach(item);
            DbContext.Entry(item).State = EntityState.Modified;
            DbContext.SaveChanges();
            return item;
        }

        public T Remove(T item)
        {
            var result = EntityDbSet.Remove(item);
            DbContext.SaveChanges();
            return result;
        }

        public void Remove(Expression<Func<T, bool>> predicate)
        {
            var items = EntityDbSet.Where(predicate);
            EntityDbSet.RemoveRange(items);
            DbContext.SaveChanges();
        }

        public IPagedList<T> GetAllPaged()
        {
            throw new NotImplementedException();
        }
    }
}
