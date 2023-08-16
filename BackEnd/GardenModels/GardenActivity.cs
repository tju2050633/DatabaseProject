namespace Garden.Models
{
    public class GardenActivity
    {
        public string ActivityId { get; set; }
        public string GardenId { get; set; }
        public string HolderId { get; set; }
        public string? Picture { get; set; }
        public string? Description { get; set; }
    }
}
