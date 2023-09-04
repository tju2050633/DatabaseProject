using Garden.DAL.Core;
using Garden.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Garden.DAL
{
    public class AccountDAL
    {
        private Account ToModel(DataRow row)
        {
            Account account = new();
            account.AccountId = row["account_id"].ToString();
            account.StudentStaffId = row["student_staff_id"].ToString();
            account.Password = row["password"].ToString();
            account.Email = row["email"].ToString();
            account.Phone = row["phone"].ToString();
            account.Portrait = row["portrait"].ToString();
            account.Bio = row["bio"].ToString();
            account.AccountName = row["account_name"].ToString();
            account.Points = Convert.ToInt32(row["points"]);
            account.JoinTime = Convert.ToDateTime(row["join_time"]);
            return account;
        }

        private List<Account> ToModelList(DataTable dt)
        {
            List<Account> ul = new();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                Account account = ToModel(dr);
                ul.Add(account);
            }
            return ul;
        }

        public Account GetAccountById(string id, out int status)
        {
            try
            {
                DataTable dt = OracleHelper.ExecuteTable("SELECT * FROM account WHERE account_id=:id",
                    new OracleParameter("id", OracleDbType.Char) { Value = id });
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

        public Account GetAccountByIdAndPwd(string id, string pwd, out int status)
        {
            try
            {
                string sql = "SELECT * FROM account WHERE account_id=:id AND password=:pwd";
                OracleParameter[] oracleParameters = new OracleParameter[]
                {
                    new OracleParameter("id", OracleDbType.Char) {Value = id},
                    new OracleParameter("pwd", OracleDbType.Varchar2) {Value = pwd}
                };
                DataTable dt = OracleHelper.ExecuteTable(sql, oracleParameters);

                if (dt.Rows.Count != 1)
                {
                    status = 2;
                    return null;
                }
                DataRow dr = dt.Rows[0];
                status = 0;
                return ToModel(dr);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                status = 1;
                return null;
            }
        }

        public bool IsAccountNameExist(string name, out int status)
        {
            try
            {
                DataTable dt = OracleHelper.ExecuteTable("SELECT account_id FROM account WHERE account_name=:name",
                    new OracleParameter("name", OracleDbType.Varchar2) { Value = name });
                status = 0;
                return dt.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                status = 1;
                return false;
            }
        }

        public bool IsSSIDExist(string ssid, out int status)
        {
            try
            {
                DataTable dt = OracleHelper.ExecuteTable("SELECT account_id FROM account WHERE student_staff_id=:ssid",
                    new OracleParameter("ssid", OracleDbType.Char) { Value = ssid });
                status = 0;
                return dt.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                status = 1;
                return false;
            }
        }

        public bool Insert(string password, string accountName, DateTime joinTime, string studentStaffId)
        {
            // 插入jointime有bug，用直接插入字符串（不使用oracleParameter）的方式暂时解决了bug
            try
            {
                string formattedTime = joinTime.ToString("yyyy-MM-dd HH:mm:ss");
                Console.WriteLine(formattedTime);

                //string sql = "INSERT INTO account(account_id, password, account_name, student_staff_id, points, join_time) VALUES(account_seq.NEXTVAL, :pwd, :name, :ssid, :point, :time)";
                //string sql = $"INSERT INTO account(account_id, password, account_name, student_staff_id, points, join_time) VALUES(account_seq.NEXTVAL, :pwd, :name, :ssid, :point, TO_DATE('{formattedTime}','yyyy-mm-dd hh24:mi:ss'))";
                //string sql = $"INSERT INTO account(account_id, password, account_name, student_staff_id, points, join_time) VALUES(account_seq.NEXTVAL, :pwd, :name, '1', 0, TO_DATE('2023-07-27 20:42:59','yyyy-mm-dd hh24:mi:ss'))";
                string sql = $"INSERT INTO account(account_id, password, account_name, student_staff_id, points, join_time) VALUES(account_seq.NEXTVAL, :pwd, :name, '{studentStaffId}', 0, TO_DATE('{formattedTime}','yyyy-mm-dd hh24:mi:ss'))";

                OracleParameter[] oracleParameters = new OracleParameter[]
                {
                    new OracleParameter("pwd", OracleDbType.Varchar2) {Value = password},
                    //new OracleParameter("time", OracleDbType.Date) {Value = joinTime},
                    //new OracleParameter("point", OracleDbType.Int64) {Value = 0},
                    //new OracleParameter("ssid", OracleDbType.Char) {Value = studentStaffId},
                    new OracleParameter("name", OracleDbType.Varchar2) {Value = accountName}
                };
                OracleHelper.ExecuteNonQuery(sql, oracleParameters);
                OracleHelper.ExecuteNonQuery("commit;");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool UpdateInfo(string id, string bio, string email, string phone)
        {
            try
            {
                OracleParameter[] oracleParameters = new OracleParameter[]
                {
                    new OracleParameter("bio", OracleDbType.Clob) {Value = bio},
                    new OracleParameter("email", OracleDbType.Varchar2) {Value = email},
                    new OracleParameter("phone", OracleDbType.Varchar2) {Value = phone},
                    new OracleParameter("id", OracleDbType.Char) { Value = id },
                };
                OracleHelper.ExecuteNonQuery(
                    "UPDATE account SET bio=:bio AND email=:email AND phone=:phone WHERE account_id=:id",
                    oracleParameters);
                OracleHelper.ExecuteNonQuery("commit;");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //获取用户个人积分
        public int GetPoints(string user_id, out int status)
        {

            try
            {
                string sql = "SELECT points FROM user WHERE user_id=:id";
                DataTable dt = OracleHelper.ExecuteTable(sql,
                    new OracleParameter("id", OracleDbType.Char) { Value = user_id });
                if (dt.Rows.Count != 1)
                {
                    status = 2;
                    return -1;
                }
                status = 0;
                DataRow dr = dt.Rows[0];
                int value = Convert.ToInt32(dr["price"]);
                return value;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                status = 1;
                return -1;
            }

        }
    }
}