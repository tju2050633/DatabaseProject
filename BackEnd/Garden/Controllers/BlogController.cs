using Garden.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

using Garden.Models;

namespace Garden.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogBLL _blogBLL;

        public BlogController(IBlogBLL blogBLL)
        {
            _blogBLL = blogBLL;
        }

        [HttpGet]
        public ActionResult<Blog> GetSingleBlog(string id)
        {
            return _blogBLL.GetSingleBlog(id);
        }

        [HttpGet("user")]
        public IEnumerable<Blog> GetUserBlogs(string id)
        {
            return _blogBLL.GetUserBlogs(id);
        }

        [HttpPost]
        public ActionResult<string> Insert(string owner_id, string title, string content, string imagePath = "")
        {
            Blog blog = new()
            {
                OwnerId = owner_id,
                Title = title,
                Content = content,
                ImageUrl = imagePath,
                ReleaseTime = DateTime.Now
            };
            return _blogBLL.Insert(blog);
        }

        //[HttpPut]
        //public ActionResult<string> Update(string owner_id, string title, string content, string imagePath = "")
        //{
        //    return "";
        //}

        [HttpDelete]
        public ActionResult<string> Delete(string id)
        {
            return _blogBLL.Delete(id);
        }
    }
}
