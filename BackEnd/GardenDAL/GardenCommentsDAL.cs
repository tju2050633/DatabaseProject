using Garden.DAL.Core;
using Garden.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Garden.DAL
{
    public class GardenCommentsDAL
    {
        private GardenComments ToModel(DataRow row)
        {
            GardenComments comment = new()
            {
                GardenId = row["garden_id"].ToString(),
                CommentId = row["comment_id"].ToString(),
                ReleaseTime = Convert.ToDateTime(row["release_time"]),
                Content = row["content"].ToString()
            };
            return comment;
        }

        private List<GardenComments> ToModelList(DataTable dt)
        {
            List<GardenComments> cl = new();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                GardenComments comment = ToModel(dr);
                cl.Add(comment);
            }
            return cl;
        }

        public List<GardenComments> GetCommentsByGardenId(string garden_id)
        {
            try
            {
                string sql = "SELECT * FROM garden_comments WHERE garden_id=:id";
                DataTable dt = OracleHelper.ExecuteTable(sql,
                    new OracleParameter("id", OracleDbType.Char) { Value = garden_id });
                return ToModelList(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine("DAL : GetCommentsByGardenId error");
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool Insert(GardenComments comment)
        {
            // 由于尚未确定id的存储方式，暂未实现
            return false;
            //try
            //{
            //    string sql = "INSERT INTO garden_comments(garden_id, comment_id, release_time, content) VALUES(:garden_id, SEQ_GARDEN_COMMENTS.NEXTVAL, :release_time, :content)";
            //    OracleParameter[] parameters =
            //    {
            //        new OracleParameter("garden_id", OracleDbType.Char) { Value = comment.GardenId },
            //        new OracleParameter("release_time", OracleDbType.Date) { Value = comment.ReleaseTime },
            //        new OracleParameter("content", OracleDbType.Varchar2) { Value = comment.Content }
            //    };
            //    return OracleHelper.ExecuteNonQuery(sql, parameters) == 1;
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    return false;
            //}
        }

        //获取互动信息：用户评论
        //输入用户id
        //返回评论信息
        public List<GardenComments> GetUserGardenComments(string account_id)
        {
            try
            {
                string sql = "SELECT * FROM garden_comments WHERE owner_id=:id";
                DataTable dt = OracleHelper.ExecuteTable(sql,
                    new OracleParameter("id", OracleDbType.Char) { Value = account_id });
                return ToModelList(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine("DAL : GetCommentsByGardenId error");
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
