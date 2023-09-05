using Garden.Models;

namespace Garden.BLL.Interfaces
{
    public interface IBlogBLL
    {
        public Blog GetSingleBlog(string id);

        public Blog GetBlogRandomly();

        public List<Blog> GetUserBlogs(string id);

        public string Insert(Blog blog);

        //public string Update(Blog blog);

        public string Delete(string id);

        public List<BlogComments> GetComments(string blog_id);

        public string Insert_Comments(string blog_comment_id, string owner_id, string blog_id, string content);

        public List<Blog> GetMoreBlogs(int startIndex, int num = 10);

        public int AddAgree(string blog_id, int num = 1);
    }
}
