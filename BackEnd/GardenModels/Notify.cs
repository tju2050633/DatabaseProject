namespace Garden.Models
{
    public class Notify
    {
        public string NotifyId { get; set; }
        public string UserId { get; set; }
        public string? Description { get; set; }
        public DateTime NotifyTime { get; set; }
    }
}