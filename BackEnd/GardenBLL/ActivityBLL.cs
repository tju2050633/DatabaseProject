using Garden.BLL.Interfaces;
using Garden.DAL;
using Garden.Models;

namespace Garden.BLL
{
    public class ActivityBLL: IActivityBLL
    {
        GardenActivityDAL activityDAL = new();
        GardenActivityInvitationDAL invitationDAL = new();

        public List<GardenActivity> GetActivities()
        {
            return activityDAL.GetAvailableActivities();
        }

        public List<GardenActivity> GetActivitiesByGarden(string garden_id)
        {
            return activityDAL.GetActivitiesByGardenId(garden_id);
        }

        public List<GardenActivityInvitation> GetInvitationsByActivity(string activity_id)
        {
            return invitationDAL.GetInvitationsByActivityId(activity_id);
        }

        public string SignUpForActivity(GardenActivityInvitation invitation)
        {
            if (invitationDAL.GetInvitationsCountByInviteeIdAndActivityId(invitation.InviteeId, invitation.ActivityId) > 0)
            {
                return "您已经报名过了。";
            }
            if (invitationDAL.Insert(invitation))
            {
                return "报名成功。";
            }
            else
            {
                return "报名失败，请重试。";
            }
        }
    }
}
