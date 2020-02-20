using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using S3Train.Domain;
using X.PagedList;

namespace S3Train
{
    public interface IGenenicServiceBase<T> where T : EntityBase
    {
        IQueryable<T> Query();
        List<T> GetAll();
        List<T> GetAll(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy);
        IEnumerable<T> Gets(Expression<Func<T, bool>> predicate);
        IEnumerable<T> Gets(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy);
        T GetById(string id);
        T Get(Expression<Func<T, bool>> predicate);
        T Get(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy);
        T Add(T item);
        void Add(List<T> items);
        T Update(T item);
        T Remove(T item);
        void Remove(Expression<Func<T, bool>> predicate);
        IPagedList<T> GetAllPaged();
    }
}