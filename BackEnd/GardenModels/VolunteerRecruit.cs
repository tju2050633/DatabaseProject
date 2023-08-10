namespace Garden.Models
{
    public class VolunteerRecruit
    {
        public string RecruitmentId { get; set; }
        public string GardenId { get; set; }
        public string RecruiterId { get; set; }
        public DateTime RecruitTime { get; set; }
        public string? RecruitContent { get; set; }
    }
}
