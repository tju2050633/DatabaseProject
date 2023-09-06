using Garden.DAL.Core;
using Garden.Models;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Data;

namespace Garden.DAL
{
    public class BlogDAL
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

        public static List<Blog> ToModelList(DataTable dt)
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

        // 转化为BlogInfo形式，需要查Account表得到用户名
        public static BlogInfo ToBlogInfo(Blog b)
        {
            Account ac = AccountDAL.GetAccountById(b.OwnerId, out _);
            BlogInfo bi = new()
            {
                BlogId = b.BlogId,
                OwnerId = b.OwnerId,
                Title = b.Title,
                Content = b.Content,
                ImageUrl = b.ImageUrl,
                ReleaseTime = b.ReleaseTime,
                AgreeNum = b.AgreeNum,
                CommentNum = b.CommentNum,
                Author = ac.AccountName,
                Avatar = ac.Portrait
            };
            return bi;
        }
        public static List<BlogInfo> ToBlogInfoList(List<Blog> bl)
        {
            List<BlogInfo> B = new();
            foreach (Blog b in bl)
            {
                BlogInfo bi = ToBlogInfo(b);
                B.Add(bi);
            }
            return B;
        }
        public static List<BlogInfo> DtToBlogInfoList(DataTable dt)
        {
            return ToBlogInfoList(ToModelList(dt));
        }

        // 通过用户ID返回前端需要的历史点赞博客的记录
        public static List<BlogLikeInfo> GetBlogLikeInfo(string user_id)
        {
            List<BlogLikeInfo> blogLikeInfoList = new();
            var blogLikeList = BlogLikeDAL.GetAllLikes(user_id); // 获取该用户所有点赞记录
            BlogDAL blogDAL = new();
            foreach (BlogLike blogLike in blogLikeList)
            {
                BlogInfo blogInfo = ToBlogInfo(blogDAL.GetBlogById(blogLike.BlogId, out _));
                BlogLikeInfo B = new()
                {
                    Author = blogInfo.Author,
                    Avatar = blogInfo.Avatar,
                    BlogName = blogInfo.Title,
                    FullContent = blogInfo.Content,
                    TotalLikes = blogInfo.AgreeNum,
                    TotalComment = blogInfo.CommentNum,
                    LikeTime = blogLike.LikeTime,
                };
                blogLikeInfoList.Add(B);
            }

            return blogLikeInfoList;
        }


        public Blog GetBlogById(string id, out int status)
        {
            try
            {
                DataTable dt = OracleHelper.ExecuteTable("SELECT * FROM blog WHERE blog_id=:id",
                    new OracleParameter("id", OracleDbType.Char) { Value = id });
                if (dt.Rows.Count != 1)
                {
                    status = 2;
                    return null;
                }
                status = 0;
                DataRow dr = dt.Rows[0];
                return ToModel(dr);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                status = 1;
                return null;
            }
        }

        public Blog GetBlogRandomly()
        {
            try
            {
                DataTable dt = OracleHelper.ExecuteTable("SELECT * FROM blog ORDER BY DBMS_RANDOM.RANDOM");
                if (dt.Rows.Count != 1)
                {
                    return null;
                }
                DataRow dr = dt.Rows[0];
                return ToModel(dr);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<Blog> GetBlogByOwnerId(string id, out int status)
        {
            try
            {
                DataTable dt = OracleHelper.ExecuteTable("SELECT * FROM blog WHERE owner_id=:id",
                    new OracleParameter("id", OracleDbType.Char) { Value = id });

                status = 0;
                return ToModelList(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                status = 1;
                return null;
            }
        }

        // 获取排名（点赞数+评论数）前num位的blog，num默认为5
        public List<Blog> GetTopBlogs(int num = 5)
        {
            try
            {
                string sql = $"SELECT * FROM blog ORDER BY (comment_num+agree_num) DESC FETCH FIRST {num} ROWS ONLY";
                DataTable dt = OracleHelper.ExecuteTable(sql);
                return ToModelList(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool Insert(Blog blog, out int status)
        {
            try
            {
                if (blog.ImageUrl != "")
                {
                    string url = UploadFile(blog.ImageUrl, blog.OwnerId, out status);
                    if (status != 0)
                    {
                        status = 3;
                        return false;
                    }
                    blog.ImageUrl = url;
                }
                string sql = "INSERT INTO blog(blog_id, owner_id, title, content, image_url, release_time, agree_num, comment_num) VALUES(blog_seq.NEXTVAL, :owner_id, :title, :content, :image_url, :release_time, :agree_num, :comment_num)";
                OracleParameter[] oracleParameters = new OracleParameter[]
                {
                    new OracleParameter("owner_id", OracleDbType.Char) { Value = blog.OwnerId },
                    new OracleParameter("title", OracleDbType.Varchar2) { Value = blog.Title },
                    new OracleParameter("content", OracleDbType.Clob) { Value = blog.Content },
                    new OracleParameter("image_url", OracleDbType.Varchar2) { Value = blog.ImageUrl },
                    new OracleParameter("release_time", OracleDbType.Date) { Value = blog.ReleaseTime},
                    new OracleParameter("agree_num", OracleDbType.Int32) { Value = blog.AgreeNum },
                    new OracleParameter("comment_num", OracleDbType.Int32) { Value = blog.CommentNum }
                };
                OracleHelper.ExecuteNonQuery(sql, oracleParameters);
                OracleHelper.ExecuteNonQuery("commit;");
                status = 0;
                return true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("ORA-02185"))
                {
                    status = 0;
                    return true;
                }
                Console.WriteLine(ex.Message);
                status = 1;
                return false;
            }
        }

        public bool Delete(string id, out int status)
        {
            try
            {
                string sql = "DELETE FROM blog WHERE blog_id=:id";
                OracleParameter[] oracleParameters = new OracleParameter[]
                {
                    new OracleParameter("id", OracleDbType.Char) { Value = id }
                };
                OracleHelper.ExecuteNonQuery(sql, oracleParameters);
                OracleHelper.ExecuteNonQuery("commit;");
                status = 0;
                return true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("ORA-02185"))
                {
                    status = 0;
                    return true;
                }
                Console.WriteLine(ex.Message);
                status = 1;
                return false;
            }
        }

        public string UploadFile(string localFilename, string ownerId, out int status)
        {
            string filename = "blog/" + ownerId + "/" + DateTime.Now.ToFileTime().ToString().Replace("/", "") + Path.GetRandomFileName().Replace(".", "") + Path.GetExtension(localFilename);
            string url = "sharing-garden.oss-cn-hangzhou.aliyuncs.com/" + filename;
            if (OSSHelper.PutObjectFromLocalFile(filename, localFilename))
            {
                status = 0;
                return url;
            }
            else
            {
                status = 1;
                return null;
            }
        }


        public List<Blog> GetMoreBlogs(int startIndex, int num)
        {
            try
            {
                string sql = $"SELECT * FROM (SELECT rownum AS rn, b.* FROM blog b) WHERE rn >= {startIndex} AND rn < {startIndex + num}";
                DataTable dt = OracleHelper.ExecuteTable(sql);
                List<Blog> blogs = ToModelList(dt);

                if (blogs.Count == 0)
                {
                    // 数据库中获取结束，返回提示信息
                    Console.WriteLine("已获取所有博客数据！");
                }

                return blogs;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public string PutAgreeNum(int agreeNum, string blog_id)
        {
            try
            {
                string sql = $"UPDATE blog SET agree_num = {agreeNum} WHERE blog_id = {blog_id}";
                int rowsAffected = OracleHelper.ExecuteNonQuery(sql);

                if (rowsAffected > 0)
                {
                    // 点赞数更新成功
                    return "点赞成功！";
                }
                else
                {
                    // 没有更新任何行，可能是找不到对应的博客
                    Console.WriteLine("博客不存在或更新失败！");
                    return "提交失败";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "未连接到数据库";
            }
        }

        // 增加blog_id对应的点赞数，返回最新的点赞数，-1表示出错
        public int AddAgree(string user_id, string blog_id, int add = 1)
        {
            try
            {
                string sql = $"UPDATE blog SET agree_num = agree_num + {add} WHERE blog_id=:id";
                OracleHelper.ExecuteNonQuery(sql, new OracleParameter("id", OracleDbType.Char) { Value = blog_id });
                OracleHelper.ExecuteNonQuery("commit;");
                BlogLikeDAL.Insert(user_id, blog_id, System.DateTime.Now);
                return GetAgreeNumById(blog_id);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("ORA-02185")) 
                {
                    BlogLikeDAL.Insert(user_id, blog_id, System.DateTime.Now);
                    return GetAgreeNumById(blog_id); 
                }
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        // 增加blog_id对应的评论数，返回最新的评论数，-1表示出错
        public int AddCommentNum(string blog_id, int add = 1)
        {
            try
            {
                string sql = $"UPDATE blog SET comment_num = comment_num + {add} WHERE blog_id=:id";
                OracleHelper.ExecuteNonQuery(sql, new OracleParameter("id", OracleDbType.Char) { Value = blog_id });
                OracleHelper.ExecuteNonQuery("commit;");
                return GetAgreeNumById(blog_id);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("ORA-02185")) return GetAgreeNumById(blog_id);
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        // 根据博客ID查找出点赞数，返回-1表示出错
        public int GetAgreeNumById(string blog_id)
        {
            var dt = OracleHelper.ExecuteTable("SELECT agree_num FROM blog WHERE blog_id=:id",
                new OracleParameter("id", OracleDbType.Char) { Value = blog_id });
            if (dt.Rows.Count == 0) return -1;
            return Convert.ToInt32(dt.Rows[0]["agree_num"]);
        }

        // 根据博客ID查找出评论数，返回-1表示出错
        public int GetCommentNumById(string blog_id)
        {
            var dt = OracleHelper.ExecuteTable("SELECT comment_num FROM blog WHERE blog_id=:id",
                new OracleParameter("id", OracleDbType.Char) { Value = blog_id });
            if (dt.Rows.Count == 0) return -1;
            return Convert.ToInt32(dt.Rows[0]["comment_num"]);
        }
    }
}
