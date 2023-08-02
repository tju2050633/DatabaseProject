namespace Garden.Models
{
    public class GardenEntity
    {
        public string GardenId { get; set; }
        public string OwnerId { get; set; }
        public string? Pictures { get; set; }
        public DateTime CreateTime { get; set; }
        public string? Description { get; set; }
        public string? Position { get; set; }
        public int Stars { get; set; }
        public int Status { get; set; } // [0:"Approved", 1:"Waiting", 2:"Rejected"]
    }
}
