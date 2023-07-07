

namespace Garden.BLL.Interfaces
{
    public interface ILoginInfoBLL
    {
        public bool AddLoginInfo(int accountId, string? loginLocation, DateTime? loginTime);

    }
}
