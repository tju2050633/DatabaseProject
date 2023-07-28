using Garden.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Garden.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GardenController : ControllerBase
	{
        private readonly IGardenBLL _GardenBLL;

        public BlogController(IGardenBLL gardenBLL)
        {
            _GardenBLL = gardenBLL;
        }

        [HttpGet]
        public ActionResult<Garden> Get(string id)
        {
            return _GardenBLL.Get(id);
        }


        [HttpPost]
        public ActionResult<string> Insert(string applier_id, string garden_id)
        {
            Garden garden = new();
            garden.GardenId = garden_id;
            garden.OwnerId = applier_id;
            garden.Status = 1;
            garden.ReleaseTime = DateTime.Now;
            return _gardenBLL.Insert(garden);
        }

    }
}
