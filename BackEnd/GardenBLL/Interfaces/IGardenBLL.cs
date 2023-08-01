using Garden.Models;

namespace Garden.BLL.Interfaces
{
    public interface IGardenBLL
    {
        public GardenEntity Get(string id);

        public string Insert(GardenEntity garden);
    }
}

