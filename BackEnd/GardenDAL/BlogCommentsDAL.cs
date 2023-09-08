using Garden.DAL.Core;
using Garden.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Garden.DAL
{
    public class BlogCommentsDAL
    {

        private static BlogComments ToModel(DataRow row)
        {
            BlogComments blogcomments = new();

            blogcomments.BlogCommentId = row["blog_comment_id"].ToString();
            blogcomments.OwnerId = row["owner_id"].ToString();
            blogcomments.BlogId = row["blog_id"].ToString();
            blogcomments.ReleaseTime = Convert.ToDateTime(row["release_time"]);
            blogcomments.Content = row["content"].ToString();

            return blogcomments;
        }

        private static List<BlogComments> ToModelList(DataTable dt)
        {
            List<BlogComments> B = new();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                BlogComments blogcomments = ToModel(dr);
                B.Add(blogcomments);
            }
            return B;
        }

        //���ݲ���ID��������
        public List<BlogComments> GetCommentsById(string blog_id, out int status)
        {

            try
            {
                string sql = "SELECT * FROM blog_comments WHERE blog_id=:id";
                DataTable dt = OracleHelper.ExecuteTable(sql,
                    new OracleParameter("id", OracleDbType.Char) { Value = blog_id });

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

        //��������
        public bool Insert_Comment(BlogComments blogcomments)
        {
            try
            {
                string sql = "INSERT INTO blog_comments(owner_id, blog_id, release_time, content) VALUES(:owner_id, :blog_id, :release_time,: content)";
                OracleParameter[] oracleParameters = new OracleParameter[]
                {
                    new OracleParameter("owner_id", OracleDbType.Char) { Value = blogcomments.OwnerId },
                    new OracleParameter("blog_id", OracleDbType.Char) { Value = blogcomments.BlogId },
                    new OracleParameter("release_time", OracleDbType.Date) { Value = blogcomments.ReleaseTime},
                    new OracleParameter("content", OracleDbType.Char) { Value = blogcomments.Content},
                };
                OracleHelper.ExecuteNonQuery(sql, oracleParameters);
                OracleHelper.ExecuteNonQuery("commit;");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("DAL BlogCommentsDAL Insert_Comment Exception:" + ex.Message);
                if (ex.Message.Contains("ORA-02185"))
                {
                    return true;
                }
                return false;
            }
        }

        //获取个人的博客评论记录
        //输入账户id
        //返回博客评论记录
        public static List<BlogComments> GetBlogsComments(string account_id)
        {
            try
            {
                string sql = "SELECT * FROM blog_comments WHERE owner_id=:id";
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