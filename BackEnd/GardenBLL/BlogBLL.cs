using Garden.BLL.Interfaces;
using Garden.DAL;
using Garden.Models;

namespace Garden.BLL
{
    public class BlogBLL : IBlogBLL
    {
        AccountDAL accountDAL = new();
        BlogDAL blogDAL = new();
        BlogCommentsDAL blogcommentsDAL = new();

        public Blog GetSingleBlog(string id)
        {
            return blogDAL.GetBlogById(id, out _);
        }

        public List<Blog> GetHotBlogs(int cur_num, int len)
        {
            List<Blog> list = blogDAL.GetTopBlogs();
            list = list.Skip(cur_num).Take(len).ToList();
            return list;
        }

        public Blog GetBlogRandomly()
        {
            return blogDAL.GetBlogRandomly();
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


        public List<BlogComments> GetComments(string blog_id)
        {
            return blogcommentsDAL.GetCommentsById(blog_id, out _);
        }

        public string Insert_Comments(BlogComments blogComments)
        {
            if (blogcommentsDAL.Insert_Comment(blogComments))
            {
                return "评论发布成功";
            }
            else
            {
                return "评论发布失败，请重试";
            }
        }

        public List<Blog> GetMoreBlogs(int startIndex, int num)
        {
            return blogDAL.GetMoreBlogs(startIndex, num);
        }

        public string PutAgreeNum(int agreeNum, string blog_id)
        {
            return blogDAL.PutAgreeNum(agreeNum, blog_id);
        }

        public int AddAgree(string user_id, string blog_id, int num = 1)
        {
            return blogDAL.AddAgree(user_id, blog_id, num);
        }

        //获取个人的博客评论记录
        //输入账户id
        //返回博客记录
        public List<BlogLikeInfo> GetBlogsComments(string account_id)
        {
            return BlogDAL.GetBlogLikeInfo(account_id);
        }

        //获取个人的博客评论记录
        //输入账户id
        //返回博客评论记录(BlogCommentInfo形式)
        public List<BlogCommentInfo> GetBlogCommentInfos(string account_id)
        {
            return BlogDAL.GetBlogCommentInfo(account_id);
        }

        //获取个人的博客点赞记录
        //输入账户id
        //返回博客点赞记录(BlogLikeInfo形式)
        public List<BlogLikeInfo> GetBlogLikeInfos(string account_id)
        {
            return BlogDAL.GetBlogLikeInfo(account_id);
        }

        //获取个人的博客点赞记录
        //输入账户id
        //返回博客点赞记录
        public List<BlogLike> GetAllLikes(string account_id)
        {
            return BlogLikeDAL.GetAllLikes(account_id);
        }

        //更新点赞记录
        //输入用户id，博客id，加减1
        //返回点赞是否成功
        public string PostBlogLike(string account_id, string blog_id)
        {
            if (BlogLikeDAL.Insert(account_id, blog_id))
            {
                return "点赞记录成功";
            }
            else
            {
                return "点赞记录失败";
            }
        }
    }
}
