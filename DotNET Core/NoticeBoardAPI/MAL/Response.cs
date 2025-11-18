namespace NoticeBoardAPI.MAL
{
    /// <summary>
    /// Encapsulates error, message and data
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Value indicating whether an error occurred.
        /// Default is false
        /// </summary>
        public bool IsError { get; set; } = false;

        /// <summary>
        /// Gets or sets the message associated with the response.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the data associated with the response.
        /// This field is dynamic and can hold any type of data.
        /// </summary>
        public dynamic Data { get; set; }
    }
}
