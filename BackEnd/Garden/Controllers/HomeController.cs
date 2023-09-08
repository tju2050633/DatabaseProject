using Garden.BLL.Interfaces;
using Garden.DAL;
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

        // Home/GardenInfo
        // 返回该用户的全部花园（GardenInfo形式，简略）
        //List<BlogCommentInfo>:{
        //    Author:
        //    Title:
        //    GardenId:
        //    Cover:
        //    Stars:
        //    }
        [HttpGet("GardenInfo")]
        public ActionResult<List<GardenInfo>> GetGardenInfo(string userId)
        {
            return _gardenBLL.GetGardenInfos(userId);
        }

        // Home/GardenComment
        // 返回用户全部评论花园记录
        //List<GardenCommentInfo>:{
        //    Author:
        //    Title:
        //    GardenId:
        //    Avatar:
        //    Imageurl:
        //    Comment:
        //    Stars:
        //    CommentTime:
        //    }
        [HttpGet("GardenComment")]
        public ActionResult<List<GardenCommentInfo>> GetGardenComment(string userId)
        {
            return _gardenBLL.GetGardenCommentInfos(userId);
        }

        // /Home/GardenLike
        // 返回用户全部点赞花园记录
        //List<GardenCommentInfo>:{
        //    Author:
        //    Title:
        //    GardenId:
        //    Avatar:
        //    Imageurl:
        //    Stars:
        //    LikeTime:
        //    }
        [HttpGet("GardenLike")]
        public ActionResult<List<GardenLikeInfo>> GetGardenLike(string userId)
        {
            return _gardenBLL.GetGardenLikeInfos(userId);
        }

        // /Home/BlogComment
        // 返回用户全部评论博客记录
        //List<BlogCommentInfo>:{
        //    Author:
        //    BlogName:
        //    Avatar:
        //    FullContent:
        //    Comment:
        //    TotalLikes:
        //    TotalComment:
        //    CommentTime:
        //    }
        [HttpGet("BlogComment")]
        public ActionResult<List<BlogCommentInfo>> GetBlogComment(string userId)
        {
            return _blogBLL.GetBlogCommentInfos(userId);
        }

        // /Home/BlogLike
        // 返回该用户全部的点赞博客记录
        // List<BlogLikeInfo>：{
        //     Author:
        //     BlogName:
        //     Avatar:
        //     FullContent:
        //     TotalLikes:
        //     TotalComment:
        //     LikeTime:
        //}
        [HttpGet("BlogLike")]
        public ActionResult<List<BlogLikeInfo>> GetBlogLike(string userId)
        {
            return _blogBLL.GetBlogLikeInfos(userId);
        }


        //public class Record
        //{
        //    public DateTime date { get; set; }
        //    public string Location { get; set; }
        //    public string FullContent { get; set; }
        //}


        [HttpGet("Records")]
        public ActionResult<List<GardenMaintenance>> GetRecords(string userId)
        {
            return _gardenBLL.GetUserMaintenance(userId);
        }
    }
}
