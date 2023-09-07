using System.Reflection.Metadata;
using Garden.Models;

namespace Garden.BLL.Interfaces
{
        public interface IBlogBLL
        {
                public Blog GetSingleBlog(string id);
                public List<Blog> GetHotBlogs(int cur_num, int len);

                public Blog GetBlogRandomly();

                public List<Blog> GetUserBlogs(string id);

                public string Insert(Blog blog);

                //public string Update(Blog blog);

                public string Delete(string id);

                public List<BlogComments> GetComments(string blog_id);

                public string Insert_Comments(string owner_id, string blog_id, string content);

                public List<Blog> GetMoreBlogs(int startIndex, int num = 10);

                public string PutAgreeNum(int agreeNum, string blog_id);

                public int AddAgree(string user_id, string blog_id, int num = 1);

                //获取个人的博客评论记录
                //输入账户id
                //返回博客记录
                public List<BlogLikeInfo> GetBlogsComments(string account_id);

                //获取个人的博客点赞记录
                //输入账户id
                //返回博客点赞记录
                public List<BlogLike> GetAllLikes(string account_id);

                //更新点赞记录
                //输入用户id，博客id，加减1
                //返回点赞是否成功
                public string PostBlogLike(string account_id, string blog_id);
        }
}
