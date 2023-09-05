using Garden.DAL.Core;
using Garden.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Garden.DAL
{
    public class StatisticsDAL
    {
        public int GetUsersCountBefore(string date)
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM account WHERE join_time < to_date(:input_date,'yyyy-mm-dd hh24:mi:ss')";
                return Convert.ToInt32(OracleHelper.ExecuteScalar(sql,
                    new OracleParameter("input_date", OracleDbType.Char) { Value = date }));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        public int GetActiveUsersCountBefore(string date)
        {
            try
            {
                string sql = "SELECT COUNT(DISTINCT account_id) FROM login_info WHERE login_time < to_date(:input_date,'yyyy-mm-dd hh24:mi:ss')";
                return Convert.ToInt32(OracleHelper.ExecuteScalar(sql,
                    new OracleParameter("input_date", OracleDbType.Char) { Value = date }));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        public int GetUsersCountByGrade(string grade)
        {
            try
            {
                string sql = "SELECT COUNT(a.account_id) FROM account a JOIN student_staff s ON a.student_staff_id = s.student_staff_id WHERE s.grade = :grade";
                return Convert.ToInt32(OracleHelper.ExecuteScalar(sql,
                    new OracleParameter("grade", OracleDbType.Char) { Value = grade }));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        public int GetGardensCountBefore(string date)
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM garden WHERE create_time < to_date(:input_date,'yyyy-mm-dd hh24:mi:ss')";
                return Convert.ToInt32(OracleHelper.ExecuteScalar(sql,
                    new OracleParameter("input_date", OracleDbType.Char) { Value = date }));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        public int GetGardensCountByPosition(string position)
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM garden WHERE position LIKE '%' || :position || '%'";
                return Convert.ToInt32(OracleHelper.ExecuteScalar(sql,
                    new OracleParameter("position", OracleDbType.Char) { Value = position }));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        public int GetBlogsCountBefore(string date)
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM blog WHERE release_time < to_date(:input_date,'yyyy-mm-dd hh24:mi:ss')";
                return Convert.ToInt32(OracleHelper.ExecuteScalar(sql,
                    new OracleParameter("input_date", OracleDbType.Char) { Value = date }));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }
    }
}
