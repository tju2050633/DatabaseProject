using Garden.DAL.Core;
using Garden.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Garden.DAL
{
    public class GardenActivityDAL
    {
        private GardenActivity ToModel(DataRow row)
        {
            GardenActivity activity = new()
            {
                GardenId = row["garden_id"].ToString(),
                ActivityId = row["activity_id"].ToString(),
                HolderId = row["holder_id"].ToString(),
                Picture = row["picture"].ToString(),
                Description = row["description"].ToString(),
                Time = Convert.ToDateTime(row["time"]),
                Location = row["location"].ToString()
            };
            return activity;
        }

        private List<GardenActivity> ToModelList(DataTable dt)
        {
            List<GardenActivity> al = new();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                GardenActivity activity = ToModel(dr);
                al.Add(activity);
            }
            return al;
        }

        public List<GardenActivity> GetAvailableActivities()
        {
            try
            {
                string sql = "SELECT * FROM garden_activity WHERE time > SYSDATE";
                DataTable dt = OracleHelper.ExecuteTable(sql);
                return ToModelList(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public GardenActivity GetActivityRandomly()
        {
            try
            {
                string sql = "SELECT * FROM garden_activity WHERE time > SYSDATE ORDER BY DBMS_RANDOM.VALUE";
                DataTable dt = OracleHelper.ExecuteTable(sql);
                return ToModel(dt.Rows[0]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<GardenActivity> GetActivitiesByGardenId(string garden_id)
        {
            try
            {
                string sql = "SELECT * FROM garden_activity WHERE garden_id=:id";
                DataTable dt = OracleHelper.ExecuteTable(sql,
                    new OracleParameter("id", OracleDbType.Char) { Value = garden_id });
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
