﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("recruit")]
        public ActionResult<VolunteerRecruit> GetSingleRecruit(string id)
        {
            return _volunteerBLL.GetSingleRecruit(id);
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
