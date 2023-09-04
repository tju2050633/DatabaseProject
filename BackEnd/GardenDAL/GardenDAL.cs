using Garden.DAL.Core;
using Garden.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Garden.DAL
{
    public class GardenDAL
    {

        private static GardenEntity ToModel(DataRow row)
        {
            GardenEntity garden = new()
            {
                GardenId = row["garden_id"].ToString(),
                OwnerId = row["owner_id"].ToString(),
                Name = row["name"].ToString(),
                Pictures = row["pictures"].ToString(),
                CreateTime = Convert.ToDateTime(row["create_time"]),
                Description = row["description"].ToString(),
                Position = row["position"].ToString(),
                Stars = Convert.ToInt32(row["stars"]),
                Status = Convert.ToInt32(row["status"])
            };

            return garden;
        }

        public static List<GardenEntity> ToModelList(DataTable dt)
        {
            List<GardenEntity> G = new();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                GardenEntity garden = ToModel(dr);
                G.Add(garden);
            }
            return G;
        }

        public GardenEntity GetGardenById(string garden_id, out int status)
        {
            try
            {
                string sql = "SELECT * FROM garden WHERE garden_id=:id";
                DataTable dt = OracleHelper.ExecuteTable(sql,
                    new OracleParameter("id", OracleDbType.Char) { Value = garden_id });
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

        public GardenEntity GetGardenRandomly()
        {
            try
            {
                string sql = "SELECT * FROM garden WHERE status=0 ORDER BY DBMS_RANDOM.VALUE() FETCH NEXT 1 ROWS ONLY";
                DataTable dt = OracleHelper.ExecuteTable(sql);
                if (dt.Rows.Count != 1)
                {
                    return null;
                }
                DataRow dr = dt.Rows[0];
                return ToModel(dr);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<GardenEntity> GetGardensByOwnerId(string owner_id)
        {
            try
            {
                string sql = "SELECT * FROM garden WHERE owner_id=:id";
                DataTable dt = OracleHelper.ExecuteTable(sql,
                    new OracleParameter("id", OracleDbType.Char) { Value = owner_id });
                return ToModelList(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }     

        public List<GardenEntity> GetPopularGardens(int offset)
        {
            try
            {
                string sql = "SELECT * FROM garden WHERE status=0 ORDER BY stars DESC OFFSET :offset ROWS FETCH NEXT 10 ROWS ONLY";
                DataTable dt = OracleHelper.ExecuteTable(sql,
                    new OracleParameter("offset", OracleDbType.Int32) { Value = offset });
                return ToModelList(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<GardenEntity> GetRecentGardens(int offset)
        {
            try
            {
                string sql = "SELECT * FROM garden WHERE status=0 ORDER BY create_time DESC OFFSET :offset ROWS FETCH NEXT 10 ROWS ONLY";
                DataTable dt = OracleHelper.ExecuteTable(sql,
                    new OracleParameter("offset", OracleDbType.Int32) { Value = offset });
                return ToModelList(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<GardenEntity> GetTopGardens()
        {
            try
            {
                string sql = "SELECT * FROM garden WHERE status=0 ORDER BY stars DESC FETCH FIRST 5 ROWS ONLY";
                DataTable dt = OracleHelper.ExecuteTable(sql);
                return ToModelList(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool Insert(GardenEntity garden)
        {
            try
            {
                string sql = "INSERT INTO garden(garden_id, owner_id, name, pictures, create_time, description, position, stars, status) VALUES(garden_seq.NEXTVAL, :owner_id, :name, :pictures, :create_time, :description, :position, :stars, :status)";
                OracleParameter[] oracleParameters = new OracleParameter[]
                {
                    new OracleParameter("owner_id", OracleDbType.Char) { Value = garden.OwnerId },
                    new OracleParameter("name", OracleDbType.Varchar2) { Value = garden.Name },
                    new OracleParameter("pictures", OracleDbType.Varchar2) { Value = garden.Pictures },
                    new OracleParameter("create_time", OracleDbType.Date) { Value = garden.CreateTime},
                    new OracleParameter("description", OracleDbType.Clob) { Value = garden.Description },
                    new OracleParameter("position", OracleDbType.Varchar2) { Value =  garden.Position },
                    new OracleParameter("stars", OracleDbType.Int32) { Value = garden.Stars },
                    new OracleParameter("status", OracleDbType.Int32) { Value = garden.Status }
                };
                OracleHelper.ExecuteNonQuery(sql, oracleParameters);
                OracleHelper.ExecuteNonQuery("commit;");
                return true;
            }

            catch (Exception ex)
            {
                if (ex.Message.Contains("ORA-02185"))
                {
                    return true;
                }
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
