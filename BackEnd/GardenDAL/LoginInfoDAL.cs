using Garden.DAL.Core;
using Garden.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Garden.DAL
{
    public class LoginInfoDAL
    {
        private LoginInfo ToModel(DataRow row)
        {
            LoginInfo loginInfo = new();
            loginInfo.LoginInfoId = row["login_info_id"].ToString();
            loginInfo.AccountId = row["account_id"].ToString();
            loginInfo.LoginTime = Convert.ToDateTime(row["login_time"]);
            return loginInfo;
        }

        public bool Insert(string accountId, DateTime loginTime)
        {
            try
            {
                string sql = "INSERT INTO login_info(login_info_id, account_id, login_time) VALUES(login_info_seq.NEXTVAL,:id,:time)";
                OracleParameter[] oracleParameters = new OracleParameter[]
                {
                    new OracleParameter("id", OracleDbType.Char) {Value = accountId},
                    new OracleParameter("time", OracleDbType.Date) {Value = loginTime}
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

    }
}
