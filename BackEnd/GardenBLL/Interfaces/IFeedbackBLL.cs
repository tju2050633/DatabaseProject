using Garden.Models;

namespace Garden.BLL.Interfaces
{
    public interface IFeedbackBLL
    {
        public List<Feedback> GetSingleFeedback();

        public string InsertFeedback(string feedback_id, string user_id, string description);
    }
}