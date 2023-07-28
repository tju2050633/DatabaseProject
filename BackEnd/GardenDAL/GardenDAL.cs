using Garden.DAL.Core;
using Garden.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Garden.DAL
{
    public class GardenDAL
    {

        private Garden ToModel(DataRow row)
        {
            Garden garden = new();
            garden.GardenId = row["garden_id"].ToString();
            garden.OwnerId = row["owner_id"].ToString();
            garden.Pictures = row["pictures"].ToString();
            garden.Create_time = row["create_time"].ToString();
            garden.Description = row["description"].ToString();
            garden.Position = row["position"].ToString();
            garden.Stars = row["stars"].ToString();
            garden.Status = row["status"].ToString();

            return garden;
        }

        private static List<Garden> ToModelList(DataTable dt)
        {
            List<Garden> G = new();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                Garden garden = ToModel(dr);
                G.Add(garden);
            }
            return G;
        }

        public Garden GetGardenById(string garden_id, out int status)
        {
            
            try
            {
                string sql = "SELECT * FROM garden WHERE garden_id=:id";
                DataTable dt = OracleHelper.ExecuteTable(sql, 
                    new OracleParameter("id", OracleDbType.Char) { Value = id });
                if (dt.Rows.Count != 1)
                {
                    status = 0;
                    return null;
                }
                status = 1;
                DataRow dr = dt.Rows[0];
                return ToModel(dr);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                status = -1;
                return null;
            }
        }

        public bool Insert(Garden garden)
        {
            try
            {
                string sql = "INSERT INTO garden(garden_id, owner_id, pictures, create_time, description, position, stars, status) VALUES(garden_seq.NEXTVAL, :garden_id, :owner_id, :pictures, :create_time, :description, :position, :stars, :status)";
                OracleParameter[] oracleParameters = new OracleParameter[]
                {
                    new OracleParameter("garden_id", OracleDbType.Char) { Value = garden.GardenId },
                    new OracleParameter("owner_id", OracleDbType.Char) { Value = garden.OwnerId },
                    new OracleParameter("pictures", OracleDbType.Varchar255) { Value = garden.Pictures },
                    new OracleParameter("create_time", OracleDbType.Date) { Value = garden.Create_time},
                    new OracleParameter("description", OracleDbType.Clob) { Value = garden.Description },
                    new OracleParameter("position", OracleDbType.Varchar20) { Value =  garden.Position }
                    new OracleParameter("stars", OracleDbType.Int32) { Value = garden.Stars }
                    new OracleParameter("status", OracleDbType.Int32) { Value = garden.Status }
                };
                OracleHelper.ExecuteNonQuery(sql, oracleParameters);
                OracleHelper.ExecuteNonQuery("commit;");
                return true;
            }


            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (ex.Message.Contains("ORA-02185"))
                {
                    return true;
                }
                return false;
            }
        }
    }
       
}
