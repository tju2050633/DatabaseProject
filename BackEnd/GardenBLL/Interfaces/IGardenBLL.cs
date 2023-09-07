using Garden.Models;

namespace Garden.BLL.Interfaces
{
    public interface IGardenBLL
    {
        public GardenEntity GetGarden(string id);

        public GardenEntity GetGardenRandomly();

        public List<GardenEntity> GetUserGardens(string id);

        public List<GardenEntity> GetPopularGardens(int page);

        public List<GardenEntity> GetRecentGardens(int page);

        public List<GardenEntity> GetTopGardens();

        public List<GardenComments> GetGardenComments(string id);
        public bool AddGardenComment(string gardenId, string comment);

        public string Insert(GardenEntity garden);

        //获取互动信息：用户评论
        //输入用户id
        //返回评论信息
        public List<GardenComments> GetUserGardenComments(string account_id);

        //获取花园维护信息：用户工作记录
        //输入用户id
        //返回工作记录
        public List<GardenMaintenance> GetUserMaintenance(string account_id);
    }
}

