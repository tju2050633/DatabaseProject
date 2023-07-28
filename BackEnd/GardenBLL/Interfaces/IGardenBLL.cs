using Garden.Models;

namespace Garden.BLL.Interfaces
{
    public interface IGardenBLL
    {
        public Garden Get(string id);

        public string Insert(Garden garden);
    }
}
