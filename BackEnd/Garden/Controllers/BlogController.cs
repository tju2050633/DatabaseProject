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

        // 查询
        // 输入博客ID(blog_id)
        // 返回状态：[博客ID、博主ID、博客标题、正文、博客图片URL、发布时间、评分、评分数]
        [HttpGet]
        public ActionResult<Blog> GetSingleBlog(string id)
        {
            return _blogBLL.GetSingleBlog(id);
        }

        // 查询
        // 无输入
        // 返回：一个随机的博客，[博客ID、博主ID、博客标题、正文、博客图片URL、发布时间、赞数、评论数]
        [HttpGet("random")]
        public ActionResult<Blog> GetBlogRandomly()
        {
            return _blogBLL.GetBlogRandomly();
        }

        // 查询
        // 输入博主ID(owner_id)
        // 返回状态：[博客ID、博主ID、博客标题、正文、博客图片URL、发布时间、评分、评分数]
        [HttpGet("user")]
        public IEnumerable<Blog> GetUserBlogs(string id)
        {
            return _blogBLL.GetUserBlogs(id);
        }

        // 插入博客
        // 输入博主ID(owner_id)、博客标题（title）、正文（content）、本地图片路径（imagePath）
        // 返回状态：["上传成功"、"上传失败"]
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


        // 删除博客
        // 输入博客ID(blog_id)
        // 返回状态：["删除成功"、"删除失败"]
        [HttpDelete]
        public ActionResult<string> Delete(string id)
        {
            return _blogBLL.Delete(id);
        }

        // 查询已知博客的评论
        // 输入博客ID(blog_id)
        // 返回状态：[评论ID、评论者ID、所在博客ID、评论发布时间、评论内容]（评论不止一条，返回一个List）
        [HttpGet("Comments")]
        public IEnumerable<BlogComments> GetComments(string blog_id)
        {
            return _blogBLL.GetComments(blog_id);
        }

        // 插入评论
        // 输入评论ID(blog_comment_id)、评论者ID（owner_id）、所在博客ID（blog_id）、评论内容（content）
        // 返回状态：["评论发布成功"、"评论发布失败"]
        [HttpPost("Comments")]
        public ActionResult<string> Insert_Comments(string blog_comment_id, string owner_id, string blog_id, string content)
        {

            return _blogBLL.Insert_Comments(blog_comment_id, owner_id, blog_id, content);
        }

    }
}
