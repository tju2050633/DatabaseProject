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

        public string InsertFeedback(FeedbackModel feedbackModel)
        {
            // 拼接得到描述
            string description = $"1. 问题分类：{feedbackModel.SelectedRadio}\n 2. 标题：{feedbackModel.Topic}\n 3. 内容：{feedbackModel.Content}\n 4. 联系方式：{string.Join(", ", feedbackModel.Email)}";

            // 找出数据库FeedbackId最大的值，+1得到新id
            int maxId = 0;
            foreach (Feedback fb in feedbackDAL.GetFeedback(out _))
            {
                Console.WriteLine("loop");
                if (int.Parse(fb.FeedbackId) > maxId)
                {
                    maxId = int.Parse(fb.FeedbackId);
                }
            }
            maxId += 1;

            // 转成长为10的字符串，后面补空格
            string id = maxId.ToString().PadRight(10);

            Feedback feedback = new()
            {
                FeedbackId = id,
                UserId = feedbackModel.AccountId,
                Description = description,
                FeedbackTime = DateTime.Now
            };

            bool Ins = feedbackDAL.Insert_Feedback(feedback);
            if (Ins)
            {
                return "反馈成功";
            }
            else
            {
                return "反馈失败";
            }
        }
    }

}