using Garden.Models;

namespace Garden.BLL.Interfaces
{
    public interface IHotBLL
    {
        public List<MySearchResult> GetTop(int num);
    }
}
