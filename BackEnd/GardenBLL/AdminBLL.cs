using Garden.BLL.Interfaces;
using Garden.DAL;
using Garden.Models;
using System.Security.Principal;

namespace Garden.BLL
{
    public class AdminBLL : IAdminBLL
    {
        AdminDAL adminDAL = new();
        public string AdminLogin(string id, string password)
        {
            int status;
            Admin admin = adminDAL.GetAdminByIdAndPwd(id, password, out status);
            if(admin == null)
            {
                if (status == 0) return "账号或密码错误";
                else return "发生错误";
            }

            return "登录成功";
        }
    }
}
