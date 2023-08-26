using Garden.DAL.Core;
using Garden.Models;
using Oracle.ManagedDataAccess.Client;
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
    }
}
