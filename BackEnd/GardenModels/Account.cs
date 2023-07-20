namespace Garden.Models
{
    public class Account
    {
        public string AccountId { get; set; }  
        public string StudentStaffId { get; set; }
        public string Password { get; set; }
        public string AccountName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Portrait { get; set; }
        public string? Bio { get; set; }
        public DateTime JoinTime { get; set; }
        public int Points { get; set; }
    }
}
