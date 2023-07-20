namespace Garden.Models
{
    public class Report
    {
        public string ReportId { get; set; }
        public string ReporterId { get; set; }
        public string ReportedContentId { get; set; }
        public int ReportType { get; set; } //[0:"Blog", 1:"BlogComment", 2:"Garden", 3:"GardenComment", 4:"GardenAcivity"]
        public int Status { get; set; } //[0:"Approved", 1:"Waiting", 2:"Rejected"]
        public DateTime ReportTime { get; set; }
    }
}
