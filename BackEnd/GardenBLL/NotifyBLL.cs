using Garden.BLL.Interfaces;
using Garden.DAL;
using Garden.Models;

namespace Garden.BLL
{
    public class NotifyBLL : INotifyBLL
    {

        NotifyDAL notifyDAL = new();

        public List<Notify> GetSingleNotify(string user_id)
        {
            return notifyDAL.GetNotifyByUserId(user_id, out _);
        }
    }

}