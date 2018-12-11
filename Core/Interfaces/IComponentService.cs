using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Core.Entities;

namespace Core.Interfaces
{
    /// <summary>
    /// Alkatrész service interfész
    /// </summary>
    public interface IComponentService
    {
        /// <summary>
        /// Alkatrész törlése
        /// </summary>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// Alkatrész lekérdezése azonosító alapján
        /// </summary>
        Task<Component> GetByIdAsync(Guid id);

        /// <summary>
        /// Összes alkatrész lekérdezése
        /// </summary>
        Task<IEnumerable<Component>> GetAllAsync();

        /// <summary>
        /// Új alkatrész létrehozása
        /// </summary>
        Task CreateAsync(string name, int price, string description, int weight);

        /// <summary>
        /// Alkatrész szerkesztése
        /// </summary>
        Task EditAsync(Guid id, string name, int price, string description, int weight);
    }
}
