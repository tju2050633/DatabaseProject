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

        [HttpGet]
        public ActionResult<GardenEntity> GetGarden(string id)
        {
            return _gardenBLL.GetGarden(id);
        }

        [HttpGet("user")]
        public IEnumerable<GardenEntity> GetUserGardens(string id)
        {
            return _gardenBLL.GetUserGardens(id);
        }

        [HttpGet("popular")]
        public IEnumerable<GardenEntity> GetPopularGardens(int page)
        {
            return _gardenBLL.GetPopularGardens(page);
        }

        [HttpGet("recent")]
        public IEnumerable<GardenEntity> GetRecentGardens(int page)
        {
            return _gardenBLL.GetRecentGardens(page);
        }

        [HttpGet("top")]
        public IEnumerable<GardenEntity> GetTopGardens()
        {
            return _gardenBLL.GetTopGardens();
        }

        [HttpGet("comments")]
        public IEnumerable<GardenComments> GetGardenComments(string id)
        {
            return _gardenBLL.GetGardenComments(id);
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
