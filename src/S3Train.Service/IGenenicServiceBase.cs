using System;
using System.Collections.Generic;
using S3Train.Domain;

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
        T GetById(Guid id);
    }
}