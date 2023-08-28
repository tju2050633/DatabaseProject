using Garden.DAL.Core;
using Garden.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Garden.DAL
{
    public class FeedbackDAL
    {

        private static Feedback ToModel(DataRow row)
        {
            Feedback feedback = new();

            feedback.FeedbackId = row["feedback_id"].ToString();
            feedback.UserId = row["user_id"].ToString();
            feedback.Description = row["description"].ToString();
            feedback.FeedbackTime = Convert.ToDateTime(row["notify_time"]);
            return feedback;
        }

        private static List<Feedback> ToModelList(DataTable dt)
        {
            List<Feedback> F = new();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                Feedback feedback = ToModel(dr);
                F.Add(feedback);
            }
            return F;
        }

        //获取反馈信息
        public List<Feedback> GetFeedback(out int status)
        {

            try
            {
                string sql = "SELECT * FROM feedback";
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

        //插入反馈信息
        public bool Insert_Feedback(Feedback feedback)
        {
            try
            {
                string sql = "INSERT INTO feedback(feedback_id, user_id, description, feedback_time) VALUES(redeems_seq.NEXTVAL, :feedback_id, :user_id, :description, :feedback_time)";
                OracleParameter[] oracleParameters = new OracleParameter[]
                {
                    new OracleParameter("feedback_id", OracleDbType.Char) { Value = feedback.FeedbackId },
                    new OracleParameter("user_id", OracleDbType.Char) { Value = feedback.UserId },
                    new OracleParameter("description", OracleDbType.Char) { Value = feedback.Description },
                    new OracleParameter("feedback_time", OracleDbType.Date) { Value = feedback.FeedbackTime },
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