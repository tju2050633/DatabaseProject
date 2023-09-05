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
            if(status == 1) return "发生错误";
            else if(status == 2)
            {
                account = accountDAL.GetAccountBySSIdAndPwd(id, password, out status);
                if (status == 1) return "发生错误";
                else if(status == 2) return "账号或密码错误";
            }

            LoginInfoBLL loginInfoBLL = new();
            loginInfoBLL.AddLoginInfo(account.AccountId, null);
            return "登录成功";
        }

        public string Register(string ssid, string password, string accountName)
        {
            int status;
            if (accountDAL.IsSSIDRegistered(ssid, out status))  return "此学工号已被注册";
            if (status != 0) return "发生错误";
            if (!StudentStaffDAL.IsSSIDExist(ssid, out status)) return "此学工号不存在";
            if (status != 0) return "发生错误";
            if (accountDAL.IsAccountNameExist(accountName, out status)) return "用户名已存在";
            if (status != 0) return "发生错误";

            accountDAL.Insert(password, accountName, System.DateTime.Now, ssid);
            return accountDAL.GetAccountBySSID(ssid);
            //return "注册成功";
        }

        public Account GetAllInfo(string id)
        {
            int status;
            return accountDAL.GetAccountById(id, out status);
        }

        public bool UpdateInfo(string id, string bio, string email, string phone)
        {
            return accountDAL.UpdateInfo(id, bio, email, phone);
        }

        public int GetPoints(string id)
        {
            int status;
            return accountDAL.GetPoints(id, out status);
        }

    }
}
