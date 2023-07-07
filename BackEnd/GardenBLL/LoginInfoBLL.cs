using Garden.BLL.Interfaces;
using Garden.DAL;

namespace Garden.BLL
{
    public class LoginInfoBLL : ILoginInfoBLL
    {
        LoginInfoDAL loginInfoDAL = new();
        private static int IdCount = LoginInfoDAL.GetMaxId() + 1;
        public bool AddLoginInfo(int accountId, string? loginLocation, DateTime? loginTime)
        {
            string _loginLocation = loginLocation ?? string.Empty;
            DateTime _loginTime = loginTime ?? System.DateTime.Now;   
            return loginInfoDAL.Insert(IdCount++, accountId, _loginLocation, _loginTime);
        }

    }
}
