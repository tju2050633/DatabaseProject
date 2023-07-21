namespace Garden.Models
{
    public class Blog
    {
        public string BlogId { get; set; }
        public string OwnerId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime ReleaseTime { get; set; }
        public float Rating { get; set; }   
        public int RatingNum { get; set; }
    }
}
