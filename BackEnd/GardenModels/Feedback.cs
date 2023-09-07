namespace Garden.Models
{
    // for database
    public class Feedback
    {
        public string FeedbackId { get; set; }
        public string UserId { get; set; }
        public string? Description { get; set; }
        public DateTime FeedbackTime { get; set; }
    }

    // for data transfer

    public class FeedbackModel
    {
        public string AccountId { get; set; }
        public string SelectedRadio { get; set; }
        public string Topic { get; set; }
        public string Content { get; set; }
        public string Email { get; set; }
    }
}