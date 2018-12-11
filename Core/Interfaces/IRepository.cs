using System;
using System.Collections.Generic;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(Guid id);
        IEnumerable<T> ListAll();
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
