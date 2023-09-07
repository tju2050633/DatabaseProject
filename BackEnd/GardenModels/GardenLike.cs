namespace Garden.Models
{
    public class GardenLike
    {
        public string LikeId { get; set; }
        public string AccountId { get; set; }
        public string GardenId { get; set; }
        public DateTime? LikeTime { get; set; }
    }
}

