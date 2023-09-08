using Garden.BLL.Interfaces;
using Garden.DAL;
using Garden.Models;

namespace Garden.BLL
{
    public class AuditBLL : IAuditBLL
    {
        AuditDAL auditDAL = new AuditDAL();

        public List<Report> GetReports()
        {
            return auditDAL.GetReports(out _);
        }
        public string PostAuditReply()
        {
            return "";
        }
    }
}
