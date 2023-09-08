using Garden.DAL.Core;
using Garden.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Garden.DAL
{
    public class AuditDAL
    {
        private Report ToModel(DataRow row)
        {
            Report report = new();
            report.ReportId = row["report_id"].ToString();
            report.ReporterId = row["reporter_id"].ToString();
            report.ReportedContentId = row["reported_content_id"].ToString();
            report.ReportType = int.Parse(row["report_type"].ToString());
            report.Status = int.Parse(row["status"].ToString());
            report.ReportTime = (DateTime)row["report_time"];
            return report;
        }

        public List<Report> GetReports(out int status)
        {
            try
            {
                string sql = "SELECT * FROM report";
                DataTable dt = OracleHelper.ExecuteTable(sql);

                List<Report> reports = new List<Report>();
                foreach (DataRow row in dt.Rows)
                {
                    Report report = ToModel(row);
                    reports.Add(report);
                }

                status = 0;
                return reports;
            }
            catch (Exception ex)
            {
                Console.WriteLine("DAL Audit GetReports Exception");
                Console.WriteLine(ex.Message);
                status = 1;
                return null;
            }
        }
    }
}
