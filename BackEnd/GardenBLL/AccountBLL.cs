using Garden.BLL.Interfaces;
using Garden.DAL;
using Garden.Models;

namespace Garden.BLL
{
    public class AccountBLL : IAccountBLL
    {
        AccountDAL accountDAL = new();
        public string Login(string id, string password)
        {
            int status;
            Account account = accountDAL.GetAccountByIdAndPwd(id, password, out status);
            if (account == null)
            {
                if (status == 0)
                    return "账号或密码错误";
                else
                    return "发生错误";
            }

            LoginInfoBLL loginInfoBLL = new();
            loginInfoBLL.AddLoginInfo(account.AccountId, null);
            return "登录成功";
        }


    }
}
