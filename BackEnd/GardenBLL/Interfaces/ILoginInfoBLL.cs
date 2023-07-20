

namespace Garden.BLL.Interfaces
{
    public interface ILoginInfoBLL
    {
        public bool AddLoginInfo(string accountId, DateTime? loginTime);

    }
}
