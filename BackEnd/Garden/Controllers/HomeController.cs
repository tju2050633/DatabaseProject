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

        // 未完工，假数据
        [HttpGet("GardenInfo")]
        public ActionResult<GardenInfo[]> GetGardenInfo(string userId)
        {
            GardenInfo[] gardenInfos = new GardenInfo[10];
            // 假数据
            gardenInfos[0].Author = "田所浩二";
            gardenInfos[0].Title = "114514";
            gardenInfos[0].Stars = 1;
            gardenInfos[0].GardenId = "1";
            gardenInfos[1].Author = "田所浩二";
            gardenInfos[1].Title = "11451419";
            gardenInfos[1].Stars = 1145;
            gardenInfos[1].GardenId = "2";

            return gardenInfos;
        }

        // 未完工，假数据
        [HttpGet("GardenComment")]
        public ActionResult<GardenComment[]> GetGardenComment(string userId)
        {
            GardenComment[] gardenComments = new GardenComment[10];

            // 假数据
            gardenComments[0].Comment = "114514";
            gardenComments[0].Author = "1919";
            gardenComments[0].Title = "810";
            gardenComments[1].Comment = "11111";
            gardenComments[1].Author = "2222";
            gardenComments[1].Title = "333";

            return gardenComments;
        }

        // 未完工，假数据
        [HttpGet("GardenLike")]
        public ActionResult<GardenLike[]> GetGardenLike(string userId)
        {
            GardenLike[] gardenLikes = new GardenLike[10];

            // 假数据
            gardenLikes[0].Author = "1919";
            gardenLikes[0].Title = "810";
            gardenLikes[1].Author = "1111";
            gardenLikes[1].Title = "222";

            return gardenLikes;
        }

        // 未完工，假数据
        [HttpGet("BlogComment")]
        public ActionResult<BlogComment[]> GetBlogComment(string userId)
        {
            BlogComment[] blogComments = new BlogComment[10];

            // 假数据
            blogComments[0].Author = "1919";
            blogComments[0].Comment = "1919";
            blogComments[0].TotalComment = 114;
            blogComments[0].TotalLikes = 514;
            blogComments[1].Author = "222";
            blogComments[1].Comment = "333";
            blogComments[1].TotalComment = 44;
            blogComments[1].TotalLikes = 555;

            return blogComments;
        }

        // 未完工，假数据
        [HttpGet("BlogLike")]
        public ActionResult<BlogLike[]> GetBlogLike(string userId)
        {
            BlogLike[] blogLikes = new BlogLike[10];

            // 假数据
            blogLikes[0].Author = "1919";
            blogLikes[0].TotalComment = 114;
            blogLikes[0].TotalLikes = 514;

            blogLikes[1].Author = "1234";
            blogLikes[1].TotalComment = 123;
            blogLikes[1].TotalLikes = 514;

            return blogLikes;
        }


        public class Record
        {
            public DateTime date { get; set; }
            public string Location { get; set; }
            public string FullContent { get; set; }
        }
        // 未完工，假数据
        [HttpGet("Records")]
        public ActionResult<Record[]> GetRecords(string userId)
        {
            Record[] records = new Record[10];

            // 假数据
            records[0].date = DateTime.Now;
            records[0].FullContent = "1111111111";
            records[0].Location = "A";

            return records;
        }
    }
}
