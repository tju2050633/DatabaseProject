using Garden.DAL.Core;
using Garden.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Garden.DAL
{
    public class StatisticsDAL
    {
        public int GetUsersCountBefore(DateTime date)
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM account WHERE join_time < :date";
                return (int)OracleHelper.ExecuteScalar(sql,
                    new OracleParameter("date", OracleDbType.Date) { Value = date });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        public int GetActiveUsersCountBefore(DateTime date)
        {
            try
            {
                string sql = "SELECT COUNT(DISTINCT account_id) FROM login_info WHERE login_time < :date";
                return (int)OracleHelper.ExecuteScalar(sql,
                    new OracleParameter("date", OracleDbType.Date) { Value = date });
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
                return (int)OracleHelper.ExecuteScalar(sql,
                    new OracleParameter("grade", OracleDbType.Char) { Value = grade });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        public int GetGardensCountBefore(DateTime date)
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM garden WHERE create_time < :date";
                return (int)OracleHelper.ExecuteScalar(sql,
                    new OracleParameter("date", OracleDbType.Date) { Value = date });
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
                return (int)OracleHelper.ExecuteScalar(sql,
                    new OracleParameter("position", OracleDbType.Char) { Value = position });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        public int GetBlogsCountBefore(DateTime date)
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM blog WHERE release_time < :date";
                return (int)OracleHelper.ExecuteScalar(sql,
                    new OracleParameter("date", OracleDbType.Date) { Value = date });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }
    }
}
