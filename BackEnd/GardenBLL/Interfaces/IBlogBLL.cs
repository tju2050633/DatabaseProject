using Garden.Models;

namespace Garden.BLL.Interfaces
{
    public interface IBlogBLL
    {
        public Blog Get(string id);

        public string Insert(Blog blog);
    }
}
