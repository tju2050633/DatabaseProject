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
            loginInfo.LoginInfoId = Convert.ToInt32(row["login_info_id"]);
            loginInfo.Account_id = Convert.ToInt32(row["account_id"]);
            loginInfo.LoginLocation = row["login_location"].ToString();
            loginInfo.LoginTime = Convert.ToDateTime(row["login_time"]);
            return loginInfo;
        }

        public bool Insert(int loginInfoId, int accountId, string loginLocation, DateTime loginTime)
        {
            try
            {
                string sql = "INSERT INTO login_info(login_info_id, account_id, login_time, login_location) VALUES(:param1,:param2,:param3,:param4)";
                OracleParameter[] oracleParameters = new OracleParameter[]
                {
                    new OracleParameter("param1", OracleDbType.Int32) {Value = loginInfoId},
                    new OracleParameter("param2", OracleDbType.Int32) {Value = accountId},
                    new OracleParameter("param3", OracleDbType.Date) {Value = loginTime},
                    new OracleParameter("param4", OracleDbType.Varchar2) {Value = loginLocation}
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

        public static int GetMaxId()
        {
            object result = OracleHelper.ExecuteScalar("SELECT COALESCE(MAX(login_info_id), 0) FROM login_info");
            return result != DBNull.Value ? Convert.ToInt32(result) : 0;
        }

    }
}
