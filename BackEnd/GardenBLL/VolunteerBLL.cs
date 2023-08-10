using Garden.BLL.Interfaces;
using Garden.DAL;
using Garden.Models;

namespace Garden.BLL
{
    public class VolunteerBLL: IVolunteerBLL
    {
        VolunteerApplyDAL volunteerApplyDAL = new();
        VolunteerRecruitDAL volunteerRecruitDAL = new();
        public VolunteerApply GetSingleApply(string id)
        {
            return volunteerApplyDAL.GetApplyById(id, out _);
        }

        public List<VolunteerApply> GetUserApplies(string id)
        {
            return volunteerApplyDAL.GetApplyByAccountId(id, out _);
        }

        public VolunteerRecruit GetSingleRecruit(string id)
        {
            return volunteerRecruitDAL.GetRecruitById(id, out _);
        }

        public List<VolunteerRecruit> GetGardenRecruits(string id)
        {
            return volunteerRecruitDAL.GetRecruitByGardenId(id, out _);
        }

        public string InsertApply(VolunteerApply volunteerApply)
        {
            if (volunteerApplyDAL.Insert(volunteerApply, out _))
            {
                return "申请成功，等待审核。";
            }
            else
            {
                return "申请失败，请重试。";
            }
        }

        public string InsertRecruit(VolunteerRecruit volunteerRecruit)
        {
            if (volunteerRecruitDAL.Insert(volunteerRecruit, out _))
            {
                return "发布成功。";
            }
            else
            {
                return "发布失败，请重试。";
            }
        }

        public string UpdateApply(VolunteerApply volunteerApply)
        {
            if (volunteerApply.IsApproved != 0 && volunteerApply.IsApproved != 1)
            {
                return "审核状态错误。";
            }
            VolunteerApply oldApply = volunteerApplyDAL.GetApplyById(volunteerApply.ApplyId, out _);
            if (oldApply.IsApproved == 1)
            {
                return "已审核的申请不可修改。";
            }
            if (volunteerApplyDAL.Update(volunteerApply, out _))
            {
                return "更新成功。";
            }
            else
            {
                return "更新失败，请重试。";
            }
        }

        public string UpdateRecruit(VolunteerRecruit volunteerRecruit)
        {
            if (volunteerRecruitDAL.Update(volunteerRecruit, out _))
            {
                return "更新成功。";
            }
            else
            {
                return "更新失败，请重试。";
            }
        }

        public string DeleteApply(string id)
        {
            if (volunteerApplyDAL.Delete(id, out _))
            {
                return "删除成功。";
            }
            else
            {
                return "删除失败。";
            }
        }

        public string DeleteRecruit(string id)
        {
            if (volunteerRecruitDAL.Delete(id, out _))
            {
                return "删除成功。";
            }
            else
            {
                return "删除失败。";
            }
        }
    }
}
