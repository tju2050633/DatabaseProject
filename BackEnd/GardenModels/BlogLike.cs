namespace Garden.Models
{
    public class BlogLike
    {
        public string LikeId { get; set; }
        public string AccountId { get; set; }
        public string BlogId { get; set; }
        public DateTime? LikeTime { get; set; }
    }
}
