using Garden.DAL.Core;
using Garden.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Garden.DAL
{
    public class GardenMaintenanceDAL
    {
        GardenDAL gardenDAL = new();
        private GardenMaintenance ToModel(DataRow row)
        {
            GardenMaintenance maintenance = new()
            {
                MaintenanceId = row["maintenance_id"].ToString(),
                GardenId = row["garden_id"].ToString(),
                MaintenanceTime = Convert.ToDateTime(row["maintenance_time"]),
                VolunteerId = row["volunteer_id"].ToString(),
                Description = row["description"].ToString(),
                Point = Convert.ToInt32(row["point"]),
                Location = "",
            };
            //处理花园位置问题：
            GardenEntity gd = gardenDAL.GetGardenById(maintenance.GardenId, out _);
            maintenance.Location = gd.Position;
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

        //获取花园维护信息：用户工作记录
        //输入用户id
        //返回工作记录
        public List<GardenMaintenance> GetUserMaintenance(string account_id)
        {
            try
            {
                string sql = "SELECT * FROM garden_maintenance WHERE volunteer_id=:id";
                DataTable dt = OracleHelper.ExecuteTable(sql,
                    new OracleParameter("id", OracleDbType.Char) { Value = account_id });

                return ToModelList(dt);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
