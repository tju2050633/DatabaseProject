using Garden.DAL.Core;
using Garden.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Garden.DAL
{
    public class NotifyDAL
    {
        private static Notify ToModel(DataRow row)
        {
            Notify notify = new()
            {
                NotifyId = row["notify_id"].ToString(),
                UserId = row["user_id"].ToString(),
                Description = row["description"].ToString(),
                NotifyTime = Convert.ToDateTime(row["notify_time"])
            };
            return notify;
        }

        private static List<Notify> ToModelList(DataTable dt)
        {
            List<Notify> N = new();
            if (dt.Rows.Count > 0)
            {
                for (int i = dt.Rows.Count - 1; i > dt.Rows.Count - 10; i--)
                {
                    DataRow dr = dt.Rows[i];
                    Notify notify = ToModel(dr);
                    N.Add(notify);
                }
            }
            return N;
        }

        public List<Notify> GetNotifyByUserId(string id, out int status)
        {
            try
            {
                DataTable dt = OracleHelper.ExecuteTable("SELECT * FROM notify WHERE user_id=:id",
                    new OracleParameter("id", OracleDbType.Char) { Value = id });

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