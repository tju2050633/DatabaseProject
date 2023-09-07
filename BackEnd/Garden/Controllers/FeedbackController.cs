using Garden.BLL.Interfaces;
using Garden.Models;
using Microsoft.AspNetCore.Mvc;

namespace Garden.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackBLL _feedbackBLL;

        public FeedbackController(IFeedbackBLL feedbackBLL)
        {
            _feedbackBLL = feedbackBLL;
        }

        // 查询
        // 无输入
        // 返回状态：[意见反馈ID、用户ID、描述、时间]
        [HttpGet("SingleFeedback")]
        public IEnumerable<Feedback> GetSingleFeedback()
        {
            return _feedbackBLL.GetSingleFeedback();
        }

        // 插入意见反馈
        // 输入意见反馈ID(feedback_id)、反馈者id(user_id)、描述(description)
        // 返回状态：["反馈成功""反馈失败"]
        [HttpPost]
        public ActionResult<string> InsertFeedback(string feedback_id, string user_id, string description)
        {
            return _feedbackBLL.InsertFeedback(feedback_id, user_id, description);
        }
    }
}
