using Garden.BLL.Interfaces;
using Garden.DAL;
using Garden.Models;

namespace Garden.BLL
{
    public class CollegeIdlyBLL : ICollegeIdlyBLL
    {

        CollegeIdlyDAL collegeIdlyDAL = new();
        HotSpotsDAL hotSpotsDAL = new();
        IdlyLotsDAL idlyLotsDAL = new();

        //获取学校空闲地
        public List<CollegeIdly> GetSingleCollegeIdly()
        {
            return collegeIdlyDAL.GetCollegeIdly(out _);
        }

        //获取学校空闲地详细信息（单个）
        public CollegeIdly GetCollegeIdlyInfo(string idly_id)
        {
            return collegeIdlyDAL.Get_CollegeIdly(idly_id, out _);
        }

        //获取学校热点地图
        public List<HotSpots> GetSingleHotSpots()
        {
            return hotSpotsDAL.GetHotSpots(out _);
        }

        //获取闲置地已使用地段
        public List<IdlyLots> GetSingleIdlyLots()
        {
            return idlyLotsDAL.GetIdlyLots(out _);
        }
    }

}