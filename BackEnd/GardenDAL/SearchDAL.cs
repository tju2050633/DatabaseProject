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
                //前端的几种结果：博客、花园、志愿、活动，选择一些表来完成筛选
                status = 0;
                // 在这里执行搜索逻辑，并获取不同类型的搜索结果;  类似地如下
                MySearchResult blogResults = SearchBlogs(searchTerm);
                MySearchResult gardenResults = SearchGardens(searchTerm);
                MySearchResult activityResults = SearchActivity(searchTerm);
                MySearchResult volunteerResults = SearchVolunteers(searchTerm);

                // 构建包含不同类型搜索结果的数据结构
                var searchResults = new List<MySearchResult>
                {
                     blogResults,
                     gardenResults,
                     activityResults,
                     volunteerResults,
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

        MySearchResult ProcessSearch(MySearchResult result, string query1, string query2)
        {
            DataTable dt = OracleHelper.ExecuteTable(query1);
            int searchcnt = dt.Rows.Count; // 搜索出相关的条目数
            Console.WriteLine(searchcnt);
            if (result.Type == "blog")
            {
                if (searchcnt >= 10)
                {
                    result.Data.AddRange(BlogDAL.ToModelList(dt).Take(10)); // 取10个结果
                    return result;
                }
                else
                {
                    result.Data.AddRange(BlogDAL.ToModelList(dt)); // 不足10个，用其他项补齐，最终结果依旧可能小于10个
                    DataTable dt2 = OracleHelper.ExecuteTable(query2);
                    result.Data.AddRange(BlogDAL.ToModelList(dt2).Take(10 - searchcnt));
                }
            }
            else if (result.Type == "garden")
            {
                if (searchcnt >= 10)
                {
                    result.Data.AddRange(GardenDAL.ToModelList(dt).Take(10)); // 取10个结果
                    return result;
                }
                else
                {
                    result.Data.AddRange(GardenDAL.ToModelList(dt)); // 不足10个，用其他项补齐，最终结果依旧可能小于10个
                    DataTable dt2 = OracleHelper.ExecuteTable(query2);
                    result.Data.AddRange(GardenDAL.ToModelList(dt2).Take(10 - searchcnt));
                }
            }
            else if (result.Type == "activity")
            {
                if (searchcnt >= 10)
                {
                    result.Data.AddRange(GardenActivityDAL.ToModelList(dt).Take(10)); // 取10个结果
                    return result;
                }
                else
                {
                    result.Data.AddRange(GardenActivityDAL.ToModelList(dt)); // 不足10个，用其他项补齐，最终结果依旧可能小于10个
                    DataTable dt2 = OracleHelper.ExecuteTable(query2);
                    result.Data.AddRange(GardenActivityDAL.ToModelList(dt2).Take(10 - searchcnt));
                }
            }
            else if (result.Type == "volunteer")
            {
                if (searchcnt >= 10)
                {
                    result.Data.AddRange(AccountDAL.ToUserInfoModelList(dt).Take(10)); // 取10个结果
                    return result;
                }
                else
                {
                    result.Data.AddRange(AccountDAL.ToUserInfoModelList(dt)); // 不足10个，用其他项补齐，最终结果依旧可能小于10个
                    DataTable dt2 = OracleHelper.ExecuteTable(query2);
                    result.Data.AddRange(AccountDAL.ToUserInfoModelList(dt2).Take(10 - searchcnt));
                }
            }

            return result;
        }

        MySearchResult SearchBlogs(string searchTerm)
        {
            MySearchResult result = new MySearchResult
            {
                Type = "blog",
                Data = new List<object>()
            };

            string query1 = $"SELECT * FROM Blog WHERE blog_id LIKE '%{searchTerm}%' " +
                $"OR owner_id LIKE '%{searchTerm}%' " +
                $"OR title LIKE '%{searchTerm}%' " +
                $"OR content LIKE '%{searchTerm}%'";
            string query2 = $"SELECT * FROM Blog WHERE NOT blog_id LIKE '%{searchTerm}%' " +
                $"AND NOT owner_id LIKE '%{searchTerm}%' " +
                $"AND NOT title LIKE '%{searchTerm}%' " +
                $"AND NOT content LIKE '%{searchTerm}%' ";
            return ProcessSearch(result, query1, query2);
        }

        MySearchResult SearchGardens(string searchTerm)
        {
            MySearchResult result = new MySearchResult
            {
                Type = "garden",
                Data = new List<object>()
            };

            string query1 = $"SELECT * FROM Garden WHERE garden_id LIKE '%{searchTerm}%' " +
                $"OR owner_id LIKE '%{searchTerm}%' " +
                $"OR name LIKE '%{searchTerm}%' " +
                $"OR description LIKE '%{searchTerm}%'";
            string query2 = $"SELECT * FROM Garden WHERE NOT garden_id LIKE '%{searchTerm}%' " +
                $"AND NOT owner_id LIKE '%{searchTerm}%' " +
                $"AND NOT name LIKE '%{searchTerm}%' " +
                $"AND NOT description LIKE '%{searchTerm}%' ";
            return ProcessSearch(result, query1, query2);
        }
        MySearchResult SearchActivity(string searchTerm)
        {
            MySearchResult result = new MySearchResult
            {
                Type = "activity",
                Data = new List<object>()
            };
            string query1 = $"SELECT * FROM Garden_Activity WHERE activity_id LIKE '%{searchTerm}%' " +
                $"OR garden_id LIKE '%{searchTerm}%' " +
                $"OR holder_id LIKE '%{searchTerm}%' " +
                $"OR description LIKE '%{searchTerm}%'";
            string query2 = $"SELECT * FROM Garden_Activity WHERE NOT activity_id LIKE '%{searchTerm}%' " +
                $"OR NOT garden_id LIKE '%{searchTerm}%' " +
                $"OR NOT holder_id LIKE '%{searchTerm}%' " +
                $"OR NOT description LIKE '%{searchTerm}%'";
            return ProcessSearch(result, query1, query2);
        }
        MySearchResult SearchVolunteers(string searchTerm)
        {
            MySearchResult result = new MySearchResult
            {
                Type = "volunteer",
                Data = new List<object>()
            };
            string query1 = $"SELECT * FROM Account WHERE account_id LIKE '%{searchTerm}%' " +
                $"OR account_name LIKE '%{searchTerm}%' " +
                $"OR bio LIKE '%{searchTerm}%' " +
                $"OR phone LIKE '%{searchTerm}%'";
            string query2 = $"SELECT * FROM Account WHERE NOT account_id LIKE '%{searchTerm}%' " +
                $"AND NOT account_name LIKE '%{searchTerm}%' " +
                $"AND NOT bio LIKE '%{searchTerm}%' " +
                $"AND NOT phone LIKE '%{searchTerm}%' ";
            return ProcessSearch(result, query1, query2);
        }
    }
}

