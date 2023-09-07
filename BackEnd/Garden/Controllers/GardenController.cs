using Garden.BLL.Interfaces;
using Garden.Models;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult<GardenEntity> GetGarden(string garden_id)
        {
            return _gardenBLL.GetGarden(garden_id);
        }

        // 查询
        // 无输入
        // 返回：一个随机的花园，[花园ID、花园主人ID、花园名、花园图片URL、创建时间、描述、位置、星数、状态]
        [HttpGet("/garden/random")]
        public ActionResult<GardenEntity> GetGardenRandomly()
        {
            return _gardenBLL.GetGardenRandomly();
        }

        [HttpGet("/garden/user")]
        public IEnumerable<GardenEntity> GetUserGardens(string id)
        {
            return _gardenBLL.GetUserGardens(id);
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
        public IEnumerable<GardenEntity> GetTopGardens()
        {
            return _gardenBLL.GetTopGardens();
        }

        [HttpGet("/garden/comments")]
        public IEnumerable<GardenComments> GetGardenComments(string id)
        {
            return _gardenBLL.GetGardenComments(id);
        }

        [HttpPost("/garden/comments")]
        public IActionResult AddGardenComment([FromBody] GardenComments comment)
        {
            if (_gardenBLL.AddGardenComment(comment.GardenId, comment.Content))
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
    }
}
