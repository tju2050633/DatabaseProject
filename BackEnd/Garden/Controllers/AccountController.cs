using Garden.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Garden.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountBLL _accountBLL;

        public AccountController(IAccountBLL accountBLL)
        {
            _accountBLL = accountBLL;
        }

        // 输入账号(id)、密码(pwd)
        // 返回状态：["账号或密码错误","发生错误","登陆成功"]
        // 登录成功时向login_info中插入一条数据
        [HttpGet]
        public ActionResult<string> Get(string id, string pwd)
        {
            return _accountBLL.Login(id, pwd);
        }

        // 输入学工号(id)、密码(pwd)、用户名(name)
        // 返回状态：["用户名已存在","此学工号已被使用","发生错误","注册成功"]
        // 有bug，目前无法正常插入
        [HttpPost]
        public ActionResult<string> Register(string id, string pwd, string name)
        {
            return _accountBLL.Register(id, pwd, name);
        }

    }
}
