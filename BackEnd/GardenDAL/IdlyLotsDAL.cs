using Garden.DAL.Core;
using Garden.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Garden.DAL
{
    public class IdlyLotsDAL
    {

        private static IdlyLots ToModel(DataRow row)
        {
            IdlyLots idlyLots = new();

            idlyLots.LotsId = row["lots_id"].ToString();
            idlyLots.IdlyId = row["idly_id"].ToString();
            idlyLots.GardenId = row["garden_id"].ToString();
            idlyLots.ResidualSize = Convert.ToInt32(row["residual_size"]);

            return idlyLots;
        }

        private static List<IdlyLots> ToModelList(DataTable dt)
        {
            List<IdlyLots> I = new();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                IdlyLots idlyLots = ToModel(dr);
                I.Add(idlyLots);
            }
            return I;
        }

        //获取闲置地已使用地段
        public List<IdlyLots> GetIdlyLots(out int status)
        {

            try
            {
                string sql = "SELECT * FROM idlylots";
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