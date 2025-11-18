using ServiceStack.DataAnnotations;

namespace EcommercePlatformAPI.MAL.POCO
{
    /// <summary>
    /// Product Model
    /// </summary>
    public class PRD01
    {
        /// <summary>
        /// D01F01 = productId
        /// </summary>
        [PrimaryKey]
        public int D01F01 { get; set; }

        /// <summary>
        /// D01F02 = productName
        /// </summary>
        [Unique]
        public string D01F02 { get; set; }

        /// <summary>
        /// D01F03 = quantity
        /// </summary>
        public int D01F03 { get; set; }

        /// <summary>
        /// D01F04 = price
        /// </summary>
        public int D01F04 { get; set; }

        /// <summary>
        /// D01F05 = categoryId
        /// </summary>
        public int D01F05 { get; set; }
    }
}