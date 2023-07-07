
namespace Garden.Models
{
    public class Account
    {
        public int AccountId { get; set; } 
        public string Password { get; set; }
        public string AccountType { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
