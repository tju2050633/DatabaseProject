namespace Garden.Models
{
    public class Blog
    {
        public string BlogId { get; set; }
        public string OwnerId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime ReleaseTime { get; set; }
        public int AgreeNum { get; set; } = 0;
        public int CommentNum { get; set; } = 0;
    }
}
