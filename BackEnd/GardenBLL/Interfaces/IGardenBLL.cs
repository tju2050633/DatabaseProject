using Garden.DAL;
using Garden.Models;

namespace Garden.BLL.Interfaces
{
    public interface IGardenBLL
    {
        public GardenEntity GetGardenInfo(string id);
        public string GetGardenNameById(string id);

        public GardenEntity GetGardenRandomly();

        public List<GardenEntity> GetHotGardens(int cur_num, int len);

        public List<GardenEntity> GetUserGardens(string id);

        public List<GardenEntity> GetPopularGardens(int page);

        public List<GardenEntity> GetRecentGardens(int page);

        public List<GardenEntity> GetTopGardens();

        public List<GardenComments> GetCommentsByGardenId(string garden_id);
        public bool AddGardenComment(string userId, string gardenId, string comment);

        public string Insert(GardenEntity garden);

        //获取互动信息：用户评论
        //输入用户id
        //返回评论信息
        public List<GardenComments> GetUserGardenComments(string account_id);

        //获取花园维护信息：用户工作记录
        //输入用户id
        //返回工作记录
        public List<GardenMaintenance> GetUserMaintenance(string account_id);

        // 获取评论花园历史记录（GardenCommentInfo形式）
        // 输入用户id
        public List<GardenCommentInfo> GetGardenCommentInfos(string account_id);

        // 获取点赞（Star）花园历史记录（GardenCommentInfo形式）
        // 输入用户id
        public List<GardenLikeInfo> GetGardenLikeInfos(string account_id);

        // 输入用户id，获取简略版花园信息（GardenInfo）
        public List<GardenInfo> GetGardenInfos(string account_id);
    }
}

