namespace Garden.Models
{
    public class Blog
    {
        public string BlogId { get; set; }
        public string OwnerId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime ReleaseTime { get; set; }
        public int AgreeNum { get; set; }
        public int CommentNum { get; set; }
    }
}
