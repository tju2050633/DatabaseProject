using Garden.DAL.Core;
using Garden.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Garden.DAL
{
    public class VolunteerApplyDAL
    {
        private VolunteerApply ToModel(DataRow row)
        {
            VolunteerApply apply = new();
            apply.ApplyId = row["apply_id"].ToString();
            apply.AccountId = row["account_id"].ToString();
            apply.ApplyDescription = row["apply_description"].ToString();
            apply.IsApproved = Convert.ToInt32(row["is_approved"]);
            return apply;
        }

        private List<VolunteerApply> ToModelList(DataTable dt)
        {
            List<VolunteerApply> al = new();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                VolunteerApply apply = ToModel(dr);
                al.Add(apply);
            }
            return al;
        }

        public VolunteerApply GetApplyById(string apply_id, out int status)
        {
            try
            {
                string sql = "SELECT * FROM volunteer_apply WHERE apply_id=:id";
                DataTable dt = OracleHelper.ExecuteTable(sql,
                    new OracleParameter("id", OracleDbType.Char) { Value = apply_id });
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

        public List<VolunteerApply> GetApplyByAccountId(string account_id, out int status)
        {
            try
            {
                string sql = "SELECT * FROM volunteer_apply WHERE account_id=:id";
                DataTable dt = OracleHelper.ExecuteTable(sql,
                    new OracleParameter("id", OracleDbType.Char) { Value = account_id });
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

        public bool Insert(VolunteerApply apply, out int status)
        {
            try
            {
                string sql = "INSERT INTO volunteer_apply(apply_id, account_id, apply_description, is_approved) VALUES(volunteer_apply_seq.nextval, :account_id, :apply_description, :is_approved)";
                OracleParameter[] oracleParameters = new OracleParameter[]
                {
                    new OracleParameter("account_id", OracleDbType.Char) { Value = apply.AccountId },
                    new OracleParameter("apply_description", OracleDbType.Clob) { Value = apply.ApplyDescription },
                    new OracleParameter("is_approved", OracleDbType.Int32) { Value = apply.IsApproved }
                };
                OracleHelper.ExecuteNonQuery(sql, oracleParameters);
                OracleHelper.ExecuteNonQuery("commit;");
                status = 0;
                return true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("ORA-02185"))
                {
                    status = 0;
                    return true;
                }
                Console.WriteLine(ex.Message);
                status = 1;
                return false;
            }
        }

        public bool Delete(string apply_id, out int status)
        {
            try
            {
                string sql = "DELETE FROM volunteer_apply WHERE apply_id=:id";
                OracleParameter[] oracleParameters = new OracleParameter[]
                {
                    new OracleParameter("id", OracleDbType.Char) { Value = apply_id }
                };
                OracleHelper.ExecuteNonQuery(sql, oracleParameters);
                OracleHelper.ExecuteNonQuery("commit;");
                status = 0;
                return true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("ORA-02185"))
                {
                    status = 0;
                    return true;
                }
                Console.WriteLine(ex.Message);
                status = 1;
                return false;
            }
        }

        public bool Update(VolunteerApply apply, out int status)
        {
            try
            {
                string sql = "UPDATE volunteer_apply SET apply_description=:apply_description, is_approved=:is_approved WHERE apply_id=:apply_id";
                OracleParameter[] oracleParameters = new OracleParameter[]
                {
                    new OracleParameter("apply_description", OracleDbType.Clob) { Value = apply.ApplyDescription },
                    new OracleParameter("is_approved", OracleDbType.Int32) { Value = apply.IsApproved },
                    new OracleParameter("apply_id", OracleDbType.Char) { Value = apply.ApplyId }
                };
                OracleHelper.ExecuteNonQuery(sql, oracleParameters);
                OracleHelper.ExecuteNonQuery("commit;");
                status = 0;
                return true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("ORA-02185"))
                {
                    status = 0;
                    return true;
                }
                Console.WriteLine(ex.Message);
                status = 1;
                return false;
            }
        }
    }
}
