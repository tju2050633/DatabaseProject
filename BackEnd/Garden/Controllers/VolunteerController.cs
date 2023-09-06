using Microsoft.AspNetCore.Mvc;
using Garden.BLL.Interfaces;
using Garden.Models;
using Garden.BLL;

namespace Garden.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VolunteerController : ControllerBase
    {
        private readonly IVolunteerBLL _volunteerBLL;
        public VolunteerController(IVolunteerBLL volunteerBLL)
        {
            _volunteerBLL = volunteerBLL;
        }

        [HttpGet("apply")]
        public ActionResult<VolunteerApply> GetSingleApply(string id)
        {
            return _volunteerBLL.GetSingleApply(id);
        }

        [HttpGet("apply/user")]
        public IEnumerable<VolunteerApply> GetUserApplies(string id)
        {
            return _volunteerBLL.GetUserApplies(id);
        }

        [HttpGet("moreRecruits")]
        public IEnumerable<VolunteerRecruit> GetMoreRecruits(int startIndex, int num)
        {
            return _volunteerBLL.GetMoreRecruits(startIndex, num);
        }

        // 查询
        // 无输入
        // 返回：一条随机的招募信息，[招募信息ID，花园ID，招募者ID，招募时间，招募信息内容]
        [HttpGet("recruit/random")]
        public ActionResult<VolunteerRecruit> GetRecruitRandomly()
        {
            return _volunteerBLL.GetRecruitRandomly();
        }

        [HttpGet("recruit/garden")]
        public IEnumerable<VolunteerRecruit> GetGardenRecruits(string id)
        {
            return _volunteerBLL.GetGardenRecruits(id);
        }

        [HttpPost("apply")]
        public ActionResult<string> InsertApply(string id, string description)
        {
            VolunteerApply volunteerApply = new()
            {
                AccountId = id,
                ApplyDescription = description,
                IsApproved = 0
            };
            return _volunteerBLL.InsertApply(volunteerApply);
        }

        [HttpPost("recruit")]
        public ActionResult<string> InsertRecruit(string garden_id, string recruiter_id, string content)
        {
            VolunteerRecruit volunteerRecruit = new()
            {
                GardenId = garden_id,
                RecruiterId = recruiter_id,
                RecruitTime = DateTime.Now,
                RecruitContent = content
            };
            return _volunteerBLL.InsertRecruit(volunteerRecruit);
        }

        [HttpPut("apply")]
        public ActionResult<string> UpdateApply(string id, string description, int isApproved = 0)
        {
            VolunteerApply volunteerApply = new()
            {
                ApplyId = id,
                ApplyDescription = description,
                IsApproved = isApproved
            };
            return _volunteerBLL.UpdateApply(volunteerApply);
        }

        [HttpPut("recruit")]
        public ActionResult<string> UpdateRecruit(string id, string content)
        {
            VolunteerRecruit volunteerRecruit = new()
            {
                RecruitmentId = id,
                RecruitContent = content
            };
            return _volunteerBLL.UpdateRecruit(volunteerRecruit);
        }

        [HttpDelete("apply")]
        public ActionResult<string> DeleteApply(string id)
        {
            return _volunteerBLL.DeleteApply(id);
        }

        [HttpDelete("recruit")]
        public ActionResult<string> DeleteRecruit(string id)
        {
            return _volunteerBLL.DeleteRecruit(id);
        }
    }
}
