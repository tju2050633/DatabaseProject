using Garden.BLL.Interfaces;
using Garden.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Garden.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GardenController : ControllerBase
    {
        private readonly IGardenBLL _gardenBLL;

        public GardenController(IGardenBLL gardenBLL)
        {
            _gardenBLL = gardenBLL;
        }

        [HttpGet("/garden/info")]
        public ActionResult<GardenEntity> GetGardenInfo(string garden_id)
        {
            return _gardenBLL.GetGardenInfo(garden_id);
        }

        [HttpGet("/garden/name")]
        public ActionResult<string> GetGardenNameById(string garden_id)
        {
            return _gardenBLL.GetGardenNameById(garden_id);
        }

        // 查询
        // 无输入
        // 返回：一个随机的花园，[花园ID、花园主人ID、花园名、花园图片URL、创建时间、描述、位置、星数、状态]
        [HttpGet("/garden/random")]
        public ActionResult<GardenEntity> GetGardenRandomly()
        {
            return _gardenBLL.GetGardenRandomly();
        }

        [HttpGet("/garden/hot")]
        public List<GardenEntity> GetHotGardens(int cur_num, int len)
        {
            return _gardenBLL.GetHotGardens(cur_num, len);
        }

        [HttpGet("/garden/user")]
        public List<GardenEntity> GetUserGardens(string user_id)
        {
            List<GardenEntity> gardens = _gardenBLL.GetUserGardens(user_id);
            Console.WriteLine("Controllers GetUserGardens gardens", gardens);
            return gardens;
        }

        [HttpGet("/garden/popular")]
        public IEnumerable<GardenEntity> GetPopularGardens(int page)
        {
            return _gardenBLL.GetPopularGardens(page);
        }

        [HttpGet("/garden/recent")]
        public IEnumerable<GardenEntity> GetRecentGardens(int page)
        {
            return _gardenBLL.GetRecentGardens(page);
        }

        [HttpGet("/garden/top")]
        public List<GardenEntity> GetTopGardens()
        {
            List<GardenEntity> gardens = _gardenBLL.GetTopGardens();
            return gardens;
        }

        [HttpGet("/garden/comments")]
        public List<GardenComments> GetCommentsByGardenId(string garden_id)
        {
            return _gardenBLL.GetCommentsByGardenId(garden_id);
        }

        [HttpPost("/garden/comment")]
        public IActionResult AddGardenComment([FromForm] string commentJson)
        {
            GardenCommentData comment = JsonConvert.DeserializeObject<GardenCommentData>(commentJson);

            if (_gardenBLL.AddGardenComment(comment.UserId, comment.GardenId, comment.Content))
            {
                return Ok(new { success = true, message = "评论成功" });
            }
            else
            {
                return Ok(new { success = false, message = "评论失败" });
            }
        }

        [HttpPost]
        public ActionResult<string> Insert(string applier_id, string name = "", string description = "", string position = "")
        {
            GardenEntity garden = new()
            {
                OwnerId = applier_id,
                Name = name,
                // PictureUrl = pictureUrl,
                CreateTime = DateTime.Now,
                Description = description,
                Position = position,
                Stars = 0,
                Status = 1,
            };
            return _gardenBLL.Insert(garden);
        }

        //获取互动信息：用户评论
        //输入用户id
        //返回评论信息
        [HttpGet("/garden/userComments")]
        public IEnumerable<GardenComments> GetUserGardenComments(string account_id)
        {
            return _gardenBLL.GetUserGardenComments(account_id);
        }

        //获取花园维护信息：用户工作记录
        //输入用户id
        //返回工作记录
        [HttpGet("/garden/maintenanceRecords")]
        public IEnumerable<GardenMaintenance> GetUserMaintenance(string account_id)
        {
            return _gardenBLL.GetUserMaintenance(account_id);
        }
    }
}
