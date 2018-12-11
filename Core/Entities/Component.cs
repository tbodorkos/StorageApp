namespace Core.Entities
{
    /// <summary>
    /// Alkatrészeket reprezentáló osztály
    /// </summary>
    public class Component : BaseEntity
    {
        /// <summary>
        /// Alkatrész neve
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Alkatrész ára
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Alkatrész leírása
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Alkatrész tömege
        /// </summary>
        public int Weight { get; set; }
    }
}
