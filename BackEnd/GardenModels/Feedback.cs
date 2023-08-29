namespace Garden.Models
{
    public class Feedback
    {
        public string FeedbackId { get; set; }
        public string UserId { get; set; }
        public string? Description { get; set; }
        public DateTime FeedbackTime { get; set; }
    }
}