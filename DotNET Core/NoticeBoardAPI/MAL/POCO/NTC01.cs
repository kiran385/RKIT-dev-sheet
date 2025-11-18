using ServiceStack.DataAnnotations;

namespace NoticeBoardAPI.MAL.POCO
{
    /// <summary>
    /// Notice model
    /// </summary>
    public class NTC01
    {
        /// <summary>
        /// noticeId
        /// </summary>
        [PrimaryKey]
        [AutoIncrement]
        public int C01F01 { get; set; }

        /// <summary>
        /// title
        /// </summary>
        public string C01F02 { get; set; }

        /// <summary>
        /// description
        /// </summary>
        public string C01F03 { get; set; }

        /// <summary>
        /// noticeDate
        /// </summary>
        [IgnoreOnUpdate]
        public DateTime C01F04 { get; set; }
    }
}
