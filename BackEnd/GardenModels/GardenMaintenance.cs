namespace Garden.Models
{
    public class GardenMaintenance
    {
        public string MaintenanceId { get; set; }
        public string GardenId { get; set; }
        public DateTime? MaintenanceTime { get; set; }
        public string VolunteerId { get; set; }
        public string? Description { get; set; }
        public int? Point { get; set; }
    }
}
