namespace Garden.Models
{
    public class GardenCreateApply
    {
        public string ApplyId { get; set; }
        public string ApplicantId { get; set; }
        public DateTime ApplyTime { get; set; }
        public string GardenId { get; set; }
    }
}
