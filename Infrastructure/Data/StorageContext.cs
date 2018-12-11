using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    /// <summary>
    /// Adatbázis kontextus
    /// </summary>
    public class StorageContext : DbContext
    {
        public StorageContext(DbContextOptions<StorageContext> options) : base(options)
        {
        }

        /// <summary>
        /// Alkatrészek
        /// </summary>
        public DbSet<Component> Components { get; set; }

        /// <summary>
        /// Készlet
        /// </summary>
        public DbSet<Storage> Storages { get; set; }
    }
}
