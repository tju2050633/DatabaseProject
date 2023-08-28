using Garden.Models;

namespace Garden.BLL.Interfaces
{
    public interface ICollegeIdlyBLL
    {
        public List<CollegeIdly> GetSingleCollegeIdly();

        public List<HotSpots> GetSingleHotSpots();

        public List<IdlyLots> GetSingleIdlyLots();

        public CollegeIdly GetCollegeIdlyInfo(string idly_id);
    }
}