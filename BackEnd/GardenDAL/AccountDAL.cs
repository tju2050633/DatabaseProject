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
            account.Portrait = row["portrait"].ToString() ;
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

        public Account GetAccountById(int id, out int status)
        {
            try
            {
                DataTable dt = OracleHelper.ExecuteTable("SELECT * FROM account WHERE account_id=:id",
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
                    status = 0;
                    return null;
                }
                DataRow dr = dt.Rows[0];
                status = 1;
                return ToModel(dr);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                status = -1;
                return null;
            }
        }


    }
}
