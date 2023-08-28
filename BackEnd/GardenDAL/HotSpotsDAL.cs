using Garden.DAL.Core;
using Garden.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Garden.DAL
{
    public class HotSpotsDAL
    {

        private static HotSpots ToModel(DataRow row)
        {
            HotSpots hotSpots = new();

            hotSpots.HotspotId = row["hotspot_id"].ToString();
            hotSpots.VisitorFlow = Convert.ToInt32(row["visitor_flow"]);

            return hotSpots;
        }

        private static List<HotSpots> ToModelList(DataTable dt)
        {
            List<HotSpots> H = new();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                HotSpots hotSpots = ToModel(dr);
                H.Add(hotSpots);
            }
            return H;
        }

        //获取学校热点地图
        public List<HotSpots> GetHotSpots(out int status)
        {

            try
            {
                string sql = "SELECT * FROM hotSpots";
                DataTable dt = OracleHelper.ExecuteTable(sql);

                status = 0;
                return ToModelList(dt);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                status = 1;
                return null;
            }
        }
    }

}