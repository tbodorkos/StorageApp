using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Core.Entities;

namespace Core.Interfaces
{
    /// <summary>
    /// Készlet service interfész
    /// </summary>
    public interface IStorageService
    {
        /// <summary>
        /// Készlet elem lekérdezése azonosító alapján
        /// </summary>
        Task<Storage> GetByIdAsync(Guid id);

        /// <summary>
        /// Teljes készlet lekérdezése
        /// </summary>
        Task<IEnumerable<Storage>> GetAllAsync();

        /// <summary>
        /// Készlethez bevétel
        /// </summary>
        Task AddAsync(Guid componentId, int piece);

        /// <summary>
        /// Készletből kivétel
        /// </summary>
        Task RemoveAsync(Guid componentId, int piece);
    }
}
