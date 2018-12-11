using System;
using System.Collections.Generic;
using Core.Entities;

namespace StorageApp.Models
{
    /// <summary>
    /// Raktárkészletet reprezentáló nézetmodell osztály
    /// </summary>
    public class StorageViewModel
    {
        /// <summary>
        /// Alkatrész azonosító
        /// </summary>
        public Guid ComponentId { get; set; }

        /// <summary>
        /// Darabszám
        /// </summary>
        public int Piece { get; set; }

        /// <summary>
        /// Hozzáadás-e
        /// </summary>
        public bool IsAdd { get; set; }

        /// <summary>
        /// Készleten lévő elemek listája
        /// </summary>
        public IEnumerable<Storage> Items { get; set; }

        /// <summary>
        /// Alkatrészek listája
        /// </summary>
        public IEnumerable<Component> Components { get; set; }

        /// <summary>
        /// Hibaüzenetek listája
        /// </summary>
        public IEnumerable<string> Errors { get; set; }
    }
}
