using System;

namespace Core.Entities
{
    /// <summary>
    /// Készletet reprezentáló osztály
    /// </summary>
    public class Storage : BaseEntity
    {
        /// <summary>
        /// Darabszám
        /// </summary>
        public int Piece { get; set; }

        /// <summary>
        /// Alkatrész azonosító
        /// </summary>
        public Guid ComponentId { get; set; }

        /// <summary>
        /// Alkatrész
        /// </summary>
        public Component Component { get; set; }
    }
}
