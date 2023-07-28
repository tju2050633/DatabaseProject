using Garden.BLL.Interfaces;
using Garden.DAL;
using Garden.Models;

namespace Garden.BLL
{
    public class BlogBLL: IBlogBLL
    {
        AccountDAL accountDAL = new();
        BlogDAL blogDAL = new();
        public Blog Get(string id)
        {
            //Blog blog = blogDAL.GetBlogById(id, out status);
            //if (status == 0)
            //{
            //    return null;
            //}
            return blogDAL.GetBlogById(id, out _);
        }

        public string Insert(Blog blog)
        {
            accountDAL.GetAccountById(blog.OwnerId, out int status);
            if (status != 1)
            {
                return "用户错误。";
            }
            if (blogDAL.Insert(blog))
            {
                return "上传成功，等待审核。";
            }
            else
            {
                return "上传失败，请重试。";
            }
        }
    }
}
