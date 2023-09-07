namespace Garden.Models
{
    public class GardenComments
    {
        public string CommentId { get; set; }
        public string GardenId { get; set; }
        public DateTime ReleaseTime { get; set; }
        public string Content { get; set; }
    }

    public class GardenCommentData
    {
        public string UserId { get; set; }
        public string GardenId { get; set; }
        public string Content { get; set; }
    }
}
