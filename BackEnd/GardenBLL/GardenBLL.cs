using Garden.BLL.Interfaces;
using Garden.DAL;
using Garden.Models;

namespace Garden.BLL
{
    public class GardenBLL : IGardenBLL
    {
        GardenDAL gardenDAL = new();
        public Garden Get(string id)
        {
            return gardenDAL.GetGardenById(id, out _);
        }

        public string Insert(Garden garden)
        {
            gardenDAL.GetGardenById(garden.GardenId, out int status);
            if (status == 1)
            {
                return "garden_id已存在。";
            }

            bool Ins = gardenDAL.Insert(garden);
            if (Ins)
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