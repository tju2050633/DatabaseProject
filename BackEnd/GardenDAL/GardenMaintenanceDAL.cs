using Garden.DAL.Core;
using Garden.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Garden.DAL
{
    public class GardenMaintenanceDAL
    {
        private GardenMaintenance ToModel(DataRow row)
        {
            GardenMaintenance maintenance = new()
            {
                MaintenanceId = row["maintenance_id"].ToString(),
                GardenId = row["garden_id"].ToString(),
                MaintenanceTime = Convert.ToDateTime(row["maintenance_time"]),
                VolunteerId = row["volunteer_id"].ToString(),
                Description = row["description"].ToString(),
                Point = Convert.ToInt32(row["point"])
            };
            return maintenance;
        }

        private List<GardenMaintenance> ToModelList(DataTable dt)
        {
            List<GardenMaintenance> ml = new();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                GardenMaintenance maintenance = ToModel(dr);
                ml.Add(maintenance);
            }
            return ml;
        }
    }
}
