namespace Garden.BLL.Interfaces
{
    public interface IAccountBLL
    {
        public string Login(string id, string password);
        public string Register(string ssid, string password, string accountName);

    }
}
