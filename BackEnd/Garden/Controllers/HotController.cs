using Garden.BLL.Interfaces;
using Garden.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Garden.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HotController : ControllerBase
    {
        private readonly IHotBLL _hotBLL;
        public HotController(IHotBLL hotBLL)
        {
            _hotBLL = hotBLL;
        }

        /* 返回格式：
        [{
          Type: "garden"/"blog"
          Data: List<GardenEntity>/List<BlogEntity> (只有一项)
        },
        {},
        ...]
        */
        [HttpGet("top")]
        public ActionResult<List<MySearchResult>> GetTop3()
        {
            return _hotBLL.GetTop(3);
        }

        [HttpGet]
        public ActionResult<List<MySearchResult>> GetAll()
        {
            return _hotBLL.GetTop(-1);
        }
    }
}
