namespace EcommercePlatformAPI.MAL.DTO
{
    /// <summary>
    /// DTO model for Product
    /// </summary>
    public class DTOPRD01
    {
        /// <summary>
        /// D01F01 = productId
        /// </summary>
        public int D01F01 { get; set; }

        /// <summary>
        /// D01F02 = productName
        /// </summary>
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