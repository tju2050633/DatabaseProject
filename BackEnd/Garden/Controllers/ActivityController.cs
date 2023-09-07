using Garden.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Garden.Models;
using System.Collections.Generic;

namespace Garden.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityBLL _activityBLL;

        public ActivityController(IActivityBLL activityBLL)
        {
            _activityBLL = activityBLL;
        }

        // 查询
        // 无输入
        // 返回：所有即将举办的活动，[活动ID、花园ID、举办者ID、活动图片URL、活动简介、活动开始时间、活动地点]
        [HttpGet("/activities/get")]
        public List<GardenActivity> GetActivities()
        {
            return _activityBLL.GetActivities();
        }

        // 查询
        // 无输入
        // 返回：随机的一个即将举办的活动，[活动ID、花园ID、举办者ID、活动图片URL、活动简介、活动开始时间、活动地点]
        [HttpGet("activities/random")]
        public ActionResult<GardenActivity> GetActivityRandomly()
        {
            return _activityBLL.GetActivityRandomly();
        }

        // 查询
        // 输入：花园ID
        // 返回：该花园的所有活动，[活动ID、花园ID、举办者ID、活动图片URL、活动简介、活动开始时间、活动地点]
        [HttpGet("activities/{garden_id}")]
        public IEnumerable<GardenActivity> GetActivitiesByGarden(string garden_id)
        {
            return _activityBLL.GetActivitiesByGarden(garden_id);
        }

        // 查询
        // 输入：活动ID
        // 返回：该活动的所有邀请，[活动ID、邀请者ID、被邀请者ID、活动ID]
        [HttpGet("invitations/{activity_id}")]
        public IEnumerable<GardenActivityInvitation> GetInvitationsByActivity(string activity_id)
        {
            return _activityBLL.GetInvitationsByActivity(activity_id);
        }

        // 插入
        // 输入：邀请者ID、被邀请者ID、活动ID
        // 返回：成功或失败
        [HttpPost("invitations")]
        public ActionResult<string> SignUpForActivity(string invitor_id, string invitee_id, string activity_id)
        {
            GardenActivityInvitation invitation = new()
            {
                InvitorId = invitor_id,
                InviteeId = invitee_id,
                ActivityId = activity_id
            };
            return _activityBLL.SignUpForActivity(invitation);
        }
    }
}
