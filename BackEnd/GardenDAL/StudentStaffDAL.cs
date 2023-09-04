using Garden.DAL.Core;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garden.DAL
{
    public class StudentStaffDAL
    {
        public static bool IsSSIDExist(string ssid, out int status)
        {
            try
            {
                DataTable dt = OracleHelper.ExecuteTable("SELECT student_staff_id FROM student_staff WHERE student_staff_id=:ssid",
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
    }
}
