using Garden.BLL.Interfaces;
using Garden.Models;
using Microsoft.AspNetCore.Mvc;

namespace Garden.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NotifyController : ControllerBase
    {
        private readonly INotifyBLL _notifyBLL;

        public NotifyController(INotifyBLL notifyBLL)
        {
            _notifyBLL = notifyBLL;
        }

        // ��ѯ
        // �����û�ID(user_id)
        // ����״̬��[��Ϣ֪ͨID���û�ID��������ʱ��]
        [HttpGet("SingleNotify")]
        public IEnumerable<Notify> GetSingleNotify(string user_id)
        {
            return _notifyBLL.GetSingleNotify(user_id);
        }
    }
}
