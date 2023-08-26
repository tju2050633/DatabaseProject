using Garden.Models;

namespace Garden.BLL.Interfaces
{
    public interface IGardenBLL
    {
        public GardenEntity GetGarden(string id);

        public GardenEntity GetGardenRandomly();

        public List<GardenEntity> GetUserGardens(string id);

        public List<GardenEntity> GetPopularGardens(int page);

        public List<GardenEntity> GetRecentGardens(int page);

        public List<GardenEntity> GetTopGardens();

        public List<GardenComments> GetGardenComments(string id);

        public string Insert(GardenEntity garden);
    }
}

