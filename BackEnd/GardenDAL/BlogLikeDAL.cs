using Garden.DAL.Core;
using Garden.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Garden.DAL
{
    public class BlogLikeDAL
    {
        private static BlogLike ToModel(DataRow row)
        {
            BlogLike blogLike = new();
            blogLike.LikeId = row["like_id"].ToString();
            blogLike.AccountId = row["account_id"].ToString();
            blogLike.BlogId = row["blog_id"].ToString();
            blogLike.LikeTime = Convert.ToDateTime(row["like_time"]);
            return blogLike;
        }
        private static List<BlogLike> ToModelList(DataTable dt)
        {
            List<BlogLike> bl = new();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                BlogLike b = ToModel(dr);
                bl.Add(b);
            }
            return bl;
        }

        // 查询出该用户ID下所有点赞博客记录
        public static List<BlogLike> GetAllLikes(string user_id)
        {
            var dt = OracleHelper.ExecuteTable("SELECT * FROM blog_like WHERE account_id=:id",
                new OracleParameter("id", OracleDbType.Char) { Value = user_id });
            return ToModelList(dt);
        }

        // 创建点赞记录
        public static bool Insert(string account_id, string blog_id, DateTime time)
        {
            try
            {
                string sql = "INSERT INTO blog_like(like_id, account_id, blog_id, like_time) VALUES(blog_like_seq.NEXTVAL,:aid,:bid,:time)";
                OracleParameter[] oracleParameters = new OracleParameter[]
                {
                    new OracleParameter("aid", OracleDbType.Char) {Value = account_id},
                    new OracleParameter("bid", OracleDbType.Char) {Value = blog_id},
                    new OracleParameter("time", OracleDbType.Date) {Value = time}
                };
                OracleHelper.ExecuteNonQuery(sql, oracleParameters);
                OracleHelper.ExecuteNonQuery("commit;");
                return true;
            }
            catch(Exception ex)
            {
                if (ex.Message.Contains("ORA-02185")) return true;
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
}
