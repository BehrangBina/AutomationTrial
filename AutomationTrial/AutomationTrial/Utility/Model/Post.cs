namespace AutomationTrial.Utility.Model
{
    /// <summary>
    ///     Representing API object typeOf(Posts)
    /// </summary>
    public class Post
    {
        /// <summary>
        ///     User Identification value
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        ///     Post Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Post Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     Post Body
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        ///     override to string to write a post in a format
        /// </summary>
        /// <returns>string formated post</returns>
        public override string ToString()
        {
            return
                $"|{nameof(UserId)}: {UserId}, {nameof(Id)}: {Id}, {nameof(Title)}: {Title}, {nameof(Body)}:{Body} |";
        }
    }
}
