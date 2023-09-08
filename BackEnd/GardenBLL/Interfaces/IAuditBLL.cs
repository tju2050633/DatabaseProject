using Garden.Models;

namespace Garden.BLL.Interfaces
{
    public interface IAuditBLL
    {
        public List<Report> GetReports();
        public string PostAuditReply();

    }
}
