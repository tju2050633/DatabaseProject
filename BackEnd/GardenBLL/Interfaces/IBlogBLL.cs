using Garden.Models;

namespace Garden.BLL.Interfaces
{
    public interface IBlogBLL
    {
        public Blog GetSingleBlog(string id);

        public List<Blog> GetUserBlogs(string id);

        public string Insert(Blog blog);

        //public string Update(Blog blog);

        public string Delete(string id);
    }
}
