using Garden.Models;

namespace Garden.BLL.Interfaces
{
    public interface IVolunteerBLL
    {
        public VolunteerApply GetSingleApply(string id);

        public List<VolunteerApply> GetUserApplies(string id);

        //修改的获取招募信息的函数
        public List<VolunteerRecruit> GetMoreRecruits(int startIndex, int num);

        public VolunteerRecruit GetRecruitRandomly();

        public List<VolunteerRecruit> GetGardenRecruits(string id);

        public string InsertApply(VolunteerApply volunteerApply);

        public string InsertRecruit(VolunteerRecruit volunteerRecruit);

        public string UpdateApply(VolunteerApply volunteerApply);

        public string UpdateRecruit(VolunteerRecruit volunteerRecruit);

        public string DeleteApply(string id);

        public string DeleteRecruit(string id);

        //新增的获取top名单
        public List<Account> GetTopPoints();
    }
}
