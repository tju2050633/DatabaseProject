using Garden.BLL.Interfaces;
using Garden.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Garden.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IAccountBLL _accountBLL;
        private readonly IBlogBLL _blogBLL;
        private readonly IGardenBLL _gardenBLL;
        public HomeController(IAccountBLL accountBLL, IBlogBLL blogBLL, IGardenBLL gardenBLL)
        {
            _accountBLL = accountBLL;
            _blogBLL = blogBLL;
            _gardenBLL = gardenBLL;
        }

        public class UserInfo
        {
            public string Name { get; set; }
            public string? Description { get; set; }
            public string? Email { get; set; }
            public DateTime RegisterTime { get; set; }
            public string? Tel { get; set; }
            public int Points { get; set; }
            public string Id { get; set; }
        }

        /*
        路由：/Home/getUserInfo
        用户信息 
        UserInfo: {
          name: "楚杰",
          description: "我真的不卷。。。",
          email: "123@tongji.edu.cn",
          registerTime: "2020年1月",
          tel: "123456",
          points: "114",
          id: "1919810",
        },
        */
        [HttpGet("getUserInfo")]
        public ActionResult<UserInfo> GetAllUserInfo(string userId)
        {
            Account account = _accountBLL.GetAllInfo(userId);
            return new UserInfo
            {
                Name = account.AccountName,
                Description = account.Bio,
                Email = account.Email,
                RegisterTime = account.JoinTime,
                Tel = account.Phone,
                Points = account.Points,
                Id = userId
            };
        }

        /*
        路由：/Home/postUserInfo
        修改用户信息 id, description, email, tel 
        返回true/false
        */
        [HttpPost("postUserInfo")]
        public ActionResult<bool> PostAllUserInfo([FromBody] UserInfo userInfo)
        {
            return _accountBLL.UpdateInfo(userInfo.Id, userInfo.Description, userInfo.Email, userInfo.Tel);
        }

    }
}
