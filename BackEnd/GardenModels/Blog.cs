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

    // 用于返回前端
    public class BlogComment
    {
        public string Author { get; set; }
        public string BlogName { get; set; }
        public string Avatar { get; set; }
        public string FullContent { get; set; }
        public string Comment { get; set; }
        public int TotalLikes { get; set; }
        public int TotalComment { get; set; }
    }

    // 用于返回前端
    public class BlogLike
    {
        public string Author { get; set; }
        public string BlogName { get; set; }
        public string Avatar { get; set; }
        public string FullContent { get; set; }
        public int TotalLikes { get; set; }
        public int TotalComment { get; set; }
    }
}

