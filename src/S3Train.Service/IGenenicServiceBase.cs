﻿using System;
using System.Collections.Generic;
using S3Train.Domain;
using X.PagedList;

namespace S3Train
{
    public interface IGenenicServiceBase<T> where T : EntityBase
    {
        /// <summary>
        /// Select all data
        /// </summary>
        /// <returns></returns>
        List<T> SelectAll();

        /// <summary>
        /// Get entity by Id, return null if not found
        /// </summary>
        /// <param name="id">The identifier.</param>
        T GetById(string id);
        T Create(T entity);
        bool DeleteById(string id);
        IPagedList<T> getAllPaged();
        T GetByName(string name);
        T Update(T entity);
    }
}