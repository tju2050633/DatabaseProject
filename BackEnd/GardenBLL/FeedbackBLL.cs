using Garden.BLL.Interfaces;
using Garden.DAL;
using Garden.Models;

namespace Garden.BLL
{
	public class FeedbackBLL : IFeedbackBLL
	{

		FeedbackDAL feedbackDAL = new();

		public List<Feedback> GetSingleFeedback()
		{
			return feedbackDAL.GetFeedback(out _);
		}

        public string InsertFeedback(string feedback_id, string user_id, string description)
        {
            Feedback feedback_info = new()
            {
                FeedbackId = feedback_id,
                UserId = user_id,
                Description = description,
                FeedbackTime = DateTime.Now
            };

            bool Ins = feedbackDAL.Insert_Feedback(feedback_info);
            if (Ins)
            {
                return "反馈上传成功";
            }
            else
            {
                return "反馈上传失败，请重试";
            }
        }
    }

}