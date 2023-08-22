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

        public string Register(string ssid, string password, string accountName)
        {
            int status;
            if (accountDAL.IsAccountNameExist(accountName, out status))
            {
                return "用户名已存在";
            }
            if (status < 0)
            {
                return "发生错误";
            }

            if (accountDAL.IsSSIDExist(ssid, out status))
            {
                return "此学工号已被使用";
            }
            if (status < 0)
            {
                return "发生错误";
            }
            accountDAL.Insert(password, accountName, System.DateTime.Now, ssid);
            return "注册成功";
        }

        public Account GetAllInfo(string id)
        {
            int status;
            return accountDAL.GetAccountById(id, out status);
        }
    }
}
