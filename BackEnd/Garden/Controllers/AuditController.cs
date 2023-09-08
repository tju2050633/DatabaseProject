using Garden.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Garden.Models;

namespace Garden.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuditController : ControllerBase
    {
        private readonly IAuditBLL _auditBLL;

        public AuditController(IAuditBLL auditBLL)
        {
            _auditBLL = auditBLL;
        }

        [HttpGet("/reoprt/get")]
        public List<Report> GetReports()
        {
            return _auditBLL.GetReports();
        }

        // [HttpPost("/blog/comments/post")]
        // public ActionResult<string> InsertBlogComments([FromForm] string blogCommentJson)
        // {
        //     Console.WriteLine("Controller blogCommentJson : " + blogCommentJson);
        //     BlogComments blogComments = JsonConvert.DeserializeObject<BlogComments>(blogCommentJson);
        //     return _blogBLL.Insert_Comments(blogComments);
        // }
    }
}
