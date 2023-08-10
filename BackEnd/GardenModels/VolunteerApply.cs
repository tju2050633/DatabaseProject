namespace Garden.Models
{
    public class VolunteerApply
    {
        public string ApplyId { get; set; }
        public string AccountId { get; set; }
        public string? ApplyDescription { get; set; }
        public int? IsApproved { get; set; }
    }
}
