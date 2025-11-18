using ServiceStack.DataAnnotations;

namespace EcommercePlatformAPI.MAL.POCO
{
    /// <summary>
    /// Category Model
    /// </summary>
    public class CTG01
    {
        /// <summary>
        /// G01F01 = categoryId
        /// </summary>
        [PrimaryKey]
        public int G01F01 { get; set; }

        /// <summary>
        /// G01F02 = name
        /// </summary>
        [Unique]
        public string G01F02 { get; set; }

        /// <summary>
        /// G01F03 = description
        /// </summary>
        public string G01F03 { get; set; }
    }
}