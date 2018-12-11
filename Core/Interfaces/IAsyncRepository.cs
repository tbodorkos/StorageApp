using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(Guid id);
        Task<List<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
