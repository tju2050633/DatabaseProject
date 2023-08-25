using Garden.DAL.Core;
using Garden.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Garden.DAL
{
    public class SearchDAL
    {
        private static Blog ToModel(DataRow row)
        {
            Blog blog = new()
            {
                BlogId = row["blog_id"].ToString(),
                OwnerId = row["owner_id"].ToString(),
                Title = row["title"].ToString(),
                Content = row["content"].ToString(),
                ImageUrl = row["image_url"].ToString(),
                ReleaseTime = Convert.ToDateTime(row["release_time"]),
                AgreeNum = Convert.ToInt32(row["agree_num"]),
                CommentNum = Convert.ToInt32(row["comment_num"])
            };
            return blog;
        }

        private static List<Blog> ToModelList(DataTable dt)
        {
            List<Blog> bl = new();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                Blog blog = ToModel(dr);
                bl.Add(blog);
            }
            return bl;
        }
        public List<MySearchResult> GetResults(string searchTerm, out int status)
        {
            try
            {
                //这里定义搜索算法，对每个类型返回10个结果（自定义，合适即可，这里应该还有一个结果相关度的筛查）
                //前端的几种结果：博客、花园、志愿、其他，选择一些表来完成筛选
                status = 0;
                // 在这里执行搜索逻辑，并获取不同类型的搜索结果;  类似地如下
                // List<BlogResult> blogResults = SearchBlogs(searchTerm);
                // List<GardenResult> gardenResults = SearchGardens(searchTerm);
                // List<ItemResult> itemResults = SearchItems(searchTerm);
                // List<VolunteerResult> volunteerResults = SearchVolunteers(searchTerm);

                // 构建包含不同类型搜索结果的数据结构
                var searchResults = new List<MySearchResult>
                {
                    // new { type = "blog", data = blogResults },
                    // new { type = "garden", data = gardenResults },
                    // new { type = "item", data = itemResults },
                    // new { type = "volunteer", data = volunteerResults }
                };

                // 返回结果
                return searchResults;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                status = 1;
                return null;
            }
        }
    }
}