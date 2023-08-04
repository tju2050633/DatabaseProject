using Garden.BLL.Interfaces;
using Garden.Models;
using Microsoft.AspNetCore.Mvc;

namespace Garden.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GardenController : ControllerBase
	{
        private readonly IGardenBLL _gardenBLL;

        public GardenController(IGardenBLL gardenBLL)
        {
            _gardenBLL = gardenBLL;
        }

        [HttpGet]
        public ActionResult<GardenEntity> Get(string id)
        {
            return _gardenBLL.Get(id);
        }


        [HttpPost]
        public ActionResult<string> Insert(string applier_id, string garden_id)
        {
            GardenEntity garden = new();
            garden.GardenId = garden_id;
            garden.OwnerId = applier_id;
            garden.Status = 1;
            garden.CreateTime = DateTime.Now;
            return _gardenBLL.Insert(garden);
        }
    }
}
