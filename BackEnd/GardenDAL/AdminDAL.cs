using Garden.DAL.Core;
using Garden.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Garden.DAL
{
    public class AdminDAL
    {
        private Admin ToModel(DataRow row)
        {
            Admin admin = new();
            admin.AccountId = row["admin_id"].ToString();
            admin.StudentStaffId = row["student_staff_id"].ToString();
            admin.Password = row["password"].ToString();
            return admin;
        }

        public Admin GetAdminByIdAndPwd(string id, string pwd, out int status)
        {
            try
            {
                string sql = "SELECT * FROM admin WHERE admin_id=:id AND password=:pwd";
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

    }
}
