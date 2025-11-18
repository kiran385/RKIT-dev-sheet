namespace WebAPICore.Models
{
    public class TodoItem
    {
        /// <summary>
        /// Task Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Task Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Task Completed Or Not
        /// </summary>
        public bool IsCompleted { get; set; }
    }
}
