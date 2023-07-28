using Garden.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

using Garden.Models;

namespace Garden.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogBLL _blogBLL;

        public BlogController(IBlogBLL blogBLL)
        {
            _blogBLL = blogBLL;
        }

        [HttpGet]
        public Blog Get(string id)
        {
            return _blogBLL.Get(id);
        }

        [HttpPost]
        public string Insert(string owner_id, string title, string content)
        {
            Blog blog = new();
            blog.OwnerId = owner_id;
            blog.Title = title;
            blog.Content = content;
            blog.ReleaseTime = DateTime.Now;
            blog.AgreeNum = 0;
            blog.CommentNum = 0;
            return _blogBLL.Insert(blog);
        }
    }
}
