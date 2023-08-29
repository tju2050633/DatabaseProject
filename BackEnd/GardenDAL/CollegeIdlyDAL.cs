using Garden.DAL.Core;
using Garden.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Garden.DAL
{
    public class CollegeIdlyDAL
    {

        private static CollegeIdly ToModel(DataRow row)
        {
            CollegeIdly collegeIdly = new();

            collegeIdly.IdlyId = row["idly_id"].ToString();
            collegeIdly.Latitude = Convert.ToInt32(row["latitude"]);
            collegeIdly.Longtitude = Convert.ToInt32(row["longtitude"]);
            collegeIdly.Position = row["position"].ToString();
            collegeIdly.Size = Convert.ToInt32(row["size"]);
            collegeIdly.SoilProperty = row["soil_property"].ToString();

            return collegeIdly;
        }

        private static List<CollegeIdly> ToModelList(DataTable dt)
        {
            List<CollegeIdly> C = new();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                CollegeIdly collegeIdly = ToModel(dr);
                C.Add(collegeIdly);
            }
            return C;
        }

        //获取学校空闲地
        public List<CollegeIdly> GetCollegeIdly(out int status)
        {

            try
            {
                string sql = "SELECT * FROM collegeidly";
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

        //获取空闲地详细信息
        public CollegeIdly Get_CollegeIdly(string idly_id, out int status)
        {

            try
            {
                string sql = "SELECT * FROM collegeIdly WHERE idly_id=:id";
                DataTable dt = OracleHelper.ExecuteTable(sql,
                    new OracleParameter("id", OracleDbType.Char) { Value = idly_id });
                if (dt.Rows.Count != 1)
                {
                    status = 2;
                    return null;
                }
                status = 0;
                DataRow dr = dt.Rows[0];
                return ToModel(dr);

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