using Garden.Models;

namespace Garden.BLL.Interfaces
{
    public interface IVolunteerBLL
    {
        public VolunteerApply GetSingleApply(string id);

        public List<VolunteerApply> GetUserApplies(string id);

        public VolunteerRecruit GetSingleRecruit(string id);

        public List<VolunteerRecruit> GetGardenRecruits(string id);
        
        public string InsertApply(VolunteerApply volunteerApply);

        public string InsertRecruit(VolunteerRecruit volunteerRecruit);

        public string UpdateApply(VolunteerApply volunteerApply);

        public string UpdateRecruit(VolunteerRecruit volunteerRecruit);

        public string DeleteApply(string id);

        public string DeleteRecruit(string id);
    }
}
