using ServiceStack.DataAnnotations;
using System;

namespace EcommercePlatformAPI.MAL.POCO
{
    /// <summary>
    /// Order Model
    /// </summary>
    public class ORD01
    {
        /// <summary>
        /// D01F01 = orderId
        /// </summary>
        [PrimaryKey]
        [AutoIncrement]
        public int D01F01 { get; set; }

        /// <summary>
        /// D01F02 = productId
        /// </summary>
        [IgnoreOnUpdate]
        public int D01F02 { get; set; }

        /// <summary>
        /// D01F03 = quantity
        /// </summary>
        [IgnoreOnUpdate]
        public int D01F03 { get; set; }

        /// <summary>
        /// D01F04 = totalAmount
        /// </summary>
        [IgnoreOnUpdate]
        public int D01F04 { get; set; }

        /// <summary>
        /// D01F05 = orderStatus
        /// </summary>
        public EnumStatus D01F05 { get; set; } = EnumStatus.pending;

        /// <summary>
        /// D01F06 = orderDate
        /// </summary>
        public DateTime D01F06 { get; set; }
    }
}