using Garden.DAL.Core;
using Garden.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Garden.DAL
{
    public class GardenLikeDAL
    {
        private static GardenLike ToModel(DataRow row)
        {
            GardenLike gardenLike = new();
            gardenLike.LikeId = row["like_id"].ToString();
            gardenLike.AccountId = row["account_id"].ToString();
            gardenLike.GardenId = row["garden_id"].ToString();
            gardenLike.LikeTime = Convert.ToDateTime(row["like_time"]);
            return gardenLike;
        }
        private static List<GardenLike> ToModelList(DataTable dt)
        {
            List<GardenLike> gl = new();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                GardenLike g = ToModel(dr);
                gl.Add(g);
            }
            return gl;
        }

        // 查询出该用户ID下所有点赞（Star）花园记录
        public static List<GardenLike> GetAllLikes(string user_id)
        {
            var dt = OracleHelper.ExecuteTable("SELECT * FROM garden_like WHERE account_id=:id",
                new OracleParameter("id", OracleDbType.Char) { Value = user_id });
            return ToModelList(dt);
        }

        // 创建点赞/Star记录
        public static bool Insert(string account_id, string garden_id, DateTime time)
        {
            try
            {
                string sql = "INSERT INTO garden_like(like_id, account_id, garden_id, like_time) VALUES(garden_like_seq.NEXTVAL,:aid,:gid,:time)";
                OracleParameter[] oracleParameters = new OracleParameter[]
                {
                    new OracleParameter("aid", OracleDbType.Char) {Value = account_id},
                    new OracleParameter("gid", OracleDbType.Char) {Value = garden_id},
                    new OracleParameter("time", OracleDbType.Date) {Value = time}
                };
                OracleHelper.ExecuteNonQuery(sql, oracleParameters);
                OracleHelper.ExecuteNonQuery("commit;");
                return true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("ORA-02185")) return true;
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
