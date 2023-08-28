using Garden.Models;

namespace Garden.BLL.Interfaces
{
    public interface INotifyBLL
    {
        public List<Notify> GetSingleNotify(string user_id);

    }
}