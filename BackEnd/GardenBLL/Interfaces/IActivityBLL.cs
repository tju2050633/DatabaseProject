using Garden.Models;

namespace Garden.BLL.Interfaces
{
    public interface IActivityBLL
    {
        public List<GardenActivity> GetActivities();

        public List<GardenActivity> GetActivitiesByGarden(string garden_id);

        public List<GardenActivityInvitation> GetInvitationsByActivity(string activity_id);

        public string SignUpForActivity(GardenActivityInvitation invitation);
    }
}
