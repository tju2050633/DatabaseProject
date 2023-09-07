using Garden.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Garden.Models;

namespace Garden.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountBLL _accountBLL;
        private readonly IAdminBLL _adminBLL;

        public AccountController(IAccountBLL accountBLL, IAdminBLL adminBLL)
        {
            _accountBLL = accountBLL;
            _adminBLL = adminBLL;
        }

        // 输入账号或学工号(id)、密码(pwd)
        // 返回状态：["账号或密码错误","发生错误","登录成功"]
        // 登录成功时向login_info中插入一条数据
        [HttpGet("login")]
        public ActionResult<string> Login(string id, string pwd)
        {
            return _accountBLL.Login(id, pwd);
        }

        // 输入学工号(id)、密码(pwd)、用户名(name)
        // 返回状态：["用户名已存在","此学工号已被注册","此学工号不存在","发生错误","注册成功"(返回account_id)]
        [HttpPost("register")]
        public ActionResult<string> Register(string ssid, string pwd, string name)
        {
            return _accountBLL.Register(ssid, pwd, name);
        }

        // 输入账号id
        // 返回Account：
        /*{
            "accountId": "1         ",
            "studentStaffId": "3         ",
            "password": "123",
            "accountName": "test",
            "email": "",
            "phone": "",
            "portrait": "",
            "bio": "",
            "joinTime": "2023-07-04T00:30:00",
            "points": 0
        }*/
        [HttpGet("info/{id}")]
        public ActionResult<Account> GetAllInfo(string id)
        {
            return _accountBLL.GetAllInfo(id);
        }

        // 输入账号(id)、密码(pwd)
        // 返回状态：["账号或密码错误","发生错误","登录成功"]
        // 供管理员登录
        [HttpGet("admin")]
        public ActionResult<string> AdminLogin(string id, string pwd)
        {
            return _adminBLL.AdminLogin(id, pwd);
        }

        // 获取当前账户积分
        [HttpGet("/user/points")]
        public ActionResult<int> GetMyPoints(string userId)
        {
            return _accountBLL.GetPoints(userId);
        }

        // 获取用户ID
        [HttpGet("/user/name")]
        public ActionResult<string> GetUserNameById(string userId)
        {
            return _accountBLL.GetUserName(userId);
        }

    }
}
