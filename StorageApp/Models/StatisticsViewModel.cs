using Core.Entities;

namespace StorageApp.Models
{
    /// <summary>
    /// Statisztikákat reprezentáló nézetmodell osztály
    /// </summary>
    public class StatisticsViewModel
    {
        /// <summary>
        /// Raktár össztömege
        /// </summary>
        public int StorageWeight { get; set; }

        /// <summary>
        /// Raktár összértéke
        /// </summary>
        public int StorageValue { get; set; }

        /// <summary>
        /// Legtöbb tételű termék
        /// </summary>
        public Component PieceComponent { get; set; }

        /// <summary>
        /// Legnagyobb tömegű termék
        /// </summary>
        public Component WeightComponent { get; set; }
    }
}
