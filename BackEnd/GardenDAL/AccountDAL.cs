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
            account.AccountId = Convert.ToInt32(row["account_id"]);
            account.AccountType = row["account_type"].ToString();
            account.Password = row["password"].ToString();
            account.CreateTime = Convert.ToDateTime(row["create_time"]);
            return account;
        }
        private List<Account> ToModelList(DataTable dt)
        {
            List<Account> al = new();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                Account account = ToModel(dr);
                al.Add(account);
            }
            return al;
        }
        public Account GetAccountById(int id, out int status)
        {
            try
            {
                DataTable dt = OracleHelper.ExecuteTable("SELECT * FROM account WHERE account_id=:id",
                    new OracleParameter("id", OracleDbType.Int32) { Value = id });
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
        public Account GetAccountByIdAndPwd(int id, string pwd, out int status)
        {
            try
            {
                string sql = "SELECT * FROM account WHERE account_id=:param1 AND password=:param2";
                OracleParameter[] oracleParameters = new OracleParameter[]
                {
                    new OracleParameter("param1", OracleDbType.Int32) {Value = id},
                    new OracleParameter("param2", OracleDbType.Varchar2) {Value = pwd}
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
