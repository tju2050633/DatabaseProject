namespace Garden.Models
{
    public class BlogComments
    {
        public string BlogCommentId { get; set; }
        public string BlogId { get; set; }
        public DateTime ReleaseTime { get; set; }
        public string Content { get; set; }
    }
}
