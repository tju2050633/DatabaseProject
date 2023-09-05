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

        // ��ѯ
        // ������
        // ����״̬��[�������ID���û�ID��������ʱ��]
        [HttpGet("SingleFeedback")]
        public IEnumerable<Feedback> GetSingleFeedback()
        {
            return _feedbackBLL.GetSingleFeedback();
        }

        // �����������
        // �����������ID(feedback_id)��������id(user_id)������(description)
        // ����״̬��["�����ɹ�""����ʧ��"]
        [HttpPost]
        public ActionResult<string> InsertFeedback(string feedback_id, string user_id, string description)
        {
            return _feedbackBLL.InsertFeedback(feedback_id, user_id, description);
        }
    }
}
