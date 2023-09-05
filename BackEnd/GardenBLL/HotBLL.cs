using Garden.BLL.Interfaces;
using Garden.DAL;
using Garden.Models;


namespace Garden.BLL
{
    public class HotBLL : IHotBLL
    {
        const int MAXHOT = 10;
        GardenDAL gardenDAL = new();
        BlogDAL blogDAL = new();
        // num < 0 返回最大值个
        // 返回一半Garden一半Blog
        public List<MySearchResult> GetTop(int num = -1)
        {
            List<MySearchResult> results = new();
            if (num <= 0) num = MAXHOT;

            var gardenResult = gardenDAL.GetTopGardens(num / 2);
            //List<MySearchResult> gr = new();
            foreach (var item in gardenResult)
            {
                MySearchResult r = new MySearchResult
                {
                    Type = "garden",
                    Data = new List<object>() // 只有一项
                };
                r.Data.Add(item);
                //gr.Add(r);
                results.Add(r);
            }

            var blogResult = blogDAL.GetTopBlogs(num / 2 + num % 2);
            //List<MySearchResult> br = new();
            foreach (var item in blogResult)
            {
                MySearchResult r = new MySearchResult
                {
                    Type = "blog",
                    Data = new List<object>() // 只有一项
                };
                r.Data.Add(item);
                //gr.Add(r);
                results.Add(r);
            }

            return results;
        }
    }
}
