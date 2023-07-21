using Garden.BLL.Interfaces;
using Garden.DAL;
using Garden.Models;

namespace Garden.BLL
{
    public class LoginInfoBLL : ILoginInfoBLL
    {
        LoginInfoDAL loginInfoDAL = new();
        public bool AddLoginInfo(string accountId, DateTime? loginTime)
        {
            DateTime _loginTime = loginTime ?? System.DateTime.Now;
            return loginInfoDAL.Insert(accountId, _loginTime);
        }

    }
}
