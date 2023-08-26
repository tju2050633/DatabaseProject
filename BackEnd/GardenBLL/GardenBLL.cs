using Garden.BLL.Interfaces;
using Garden.DAL;
using Garden.Models;

namespace Garden.BLL
{
    public class GardenBLL : IGardenBLL
    {
        GardenDAL gardenDAL = new();
        GardenCommentsDAL gardenCommentsDAL = new();

        public static List<GardenEntity> Shuffle(List<GardenEntity> list)
        {
            if (list.Count == 0)
                return list;
            Random random = new();
            return list.OrderBy(x => random.Next()).ToList();
        }

        public GardenEntity GetGarden(string id)
        {
            return gardenDAL.GetGardenById(id, out _);
        }

        public GardenEntity GetGardenRandomly()
        {
            return gardenDAL.GetGardenRandomly();
        }

        public List<GardenEntity> GetUserGardens(string id)
        {
            return gardenDAL.GetGardensByOwnerId(id);
        }

        public List<GardenEntity> GetPopularGardens(int page)
        {
            int offset = (page - 1) * 10;
            return Shuffle(gardenDAL.GetPopularGardens(offset));
        }

        public List<GardenEntity> GetRecentGardens(int page)
        {
            int offset = (page - 1) * 10;
            return Shuffle(gardenDAL.GetRecentGardens(offset));
        }

        public List<GardenEntity> GetTopGardens()
        {
            return gardenDAL.GetTopGardens();
        }

        public List<GardenComments> GetGardenComments(string id)
        {
            return gardenCommentsDAL.GetCommentsByGardenId(id);
        }

        public string Insert(GardenEntity garden)
        {
            if (gardenDAL.Insert(garden))
            {
                return "插入成功";
            }
            else
            {
                return "插入失败";
            }
        }
    }
}
