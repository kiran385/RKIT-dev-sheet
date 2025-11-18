namespace EcommercePlatformAPI.MAL.DTO
{
    /// <summary>
    /// DTO model for Order
    /// </summary>
    public class DTOORD01
    {
        /// <summary>
        /// D01F01 = orderId
        /// </summary>
        public int D01F01 { get; set; }

        /// <summary>
        /// D01F02 = productId
        /// </summary>
        public int D01F02 { get; set; }

        /// <summary>
        /// D01F03 = quantity
        /// </summary>
        public int D01F03 { get; set; }
    }
}