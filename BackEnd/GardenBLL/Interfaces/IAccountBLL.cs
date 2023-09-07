using Garden.Models;

namespace Garden.BLL.Interfaces
{
    public interface IAccountBLL
    {
        public string Login(string id, string password);
        public string Register(string ssid, string password, string accountName);
        public Account GetAllInfo(string id);
        public bool UpdateInfo(string id, string bio, string email, string phone);

        public int GetPoints(string id);
        public string GetUserNameById(string id);
        public string GetUserAvatarById(string id);
    }
}
