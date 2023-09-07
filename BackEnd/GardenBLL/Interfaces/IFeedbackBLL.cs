using Garden.Models;

namespace Garden.BLL.Interfaces
{
    public interface IFeedbackBLL
    {
        public List<Feedback> GetSingleFeedback();

        public string InsertFeedback(FeedbackModel feedbackModel);
    }
}