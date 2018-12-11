using System;

namespace Core.Entities
{
    /// <summary>
    /// Entitás ősosztály
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Entitás azonosító
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Törölt-e
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Létrehozás dátuma
        /// </summary>
        public DateTime Created { get; set; }
    }
}
