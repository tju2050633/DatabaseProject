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

        // 查询
        // 输入用户ID(user_id)
        // 返回状态：[消息通知ID、用户ID、描述、时间]
        [HttpGet("SingleNotify")]
        public IEnumerable<Notify> GetSingleNotify(string user_id)
        {
            return _notifyBLL.GetSingleNotify(user_id);
        }
    }
}
