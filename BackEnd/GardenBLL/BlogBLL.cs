using Garden.BLL.Interfaces;
using Garden.DAL;
using Garden.Models;

namespace Garden.BLL
{
    public class BlogBLL: IBlogBLL
    {
        AccountDAL accountDAL = new();
        BlogDAL blogDAL = new();
        public Blog GetSingleBlog(string id)
        {
            return blogDAL.GetBlogById(id, out _);
        }

        public List<Blog> GetUserBlogs(string id)
        {
            return blogDAL.GetBlogByOwnerId(id, out _);
        }

        public string Insert(Blog blog)
        {
            if (blogDAL.Insert(blog, out _))
            {
                return "上传成功，等待审核。";
            }
            else
            {
                return "上传失败，请重试。";
            }
        }

        //public string Update(Blog blog)
        //{
        //    return "";
        //}

        public string Delete(string id)
        {
            if (blogDAL.Delete(id, out _))
            {
                return "删除成功。";
            }
            else
            {
                return "删除失败。";
            }
        }
    }
}
