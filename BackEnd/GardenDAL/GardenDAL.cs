using Garden.DAL.Core;
using Garden.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Garden.DAL
{
    public class GardenDAL
    {

        private static GardenEntity ToModel(DataRow row)
        {
            GardenEntity garden = new()
            {
                GardenId = row["garden_id"].ToString(),
                OwnerId = row["owner_id"].ToString(),
                Name = row["name"].ToString(),
                Pictures = row["pictures"].ToString(),
                CreateTime = Convert.ToDateTime(row["create_time"]),
                Description = row["description"].ToString(),
                Position = row["position"].ToString(),
                Stars = Convert.ToInt32(row["stars"]),
                Status = Convert.ToInt32(row["status"])
            };

            return garden;
        }

        public static List<GardenEntity> ToModelList(DataTable dt)
        {
            List<GardenEntity> G = new();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                GardenEntity garden = ToModel(dr);
                G.Add(garden);
            }
            return G;
        }

        // 转化为简略的GardenInfo形式，需要查Account表得到用户名
        public static GardenInfo ToGardenInfo(GardenEntity ge)
        {
            Account ac = AccountDAL.GetAccountById(ge.OwnerId, out _);

            GardenInfo gi = new()
            {
                GardenId = ge.GardenId,
                Title = ge.Name,
                Stars = ge.Stars,
                Cover = ge.Pictures,
                Author = ac.AccountName
            };
            return gi;
        }

        public static List<GardenInfo> ToGardenInfoList(List<GardenEntity> gel)
        {
            List<GardenInfo> G = new();
            foreach (GardenEntity ge in gel)
            {
                GardenInfo gi = ToGardenInfo(ge);
                G.Add(gi);
            }
            return G;
        }

        public static List<GardenInfo> DtToGardenInfoList(DataTable dt)
        {
            return ToGardenInfoList(ToModelList(dt));
        }

        public GardenEntity GetGardenById(string garden_id, out int status)
        {
            try
            {
                string sql = "SELECT * FROM garden WHERE garden_id=:id";
                DataTable dt = OracleHelper.ExecuteTable(sql,
                    new OracleParameter("id", OracleDbType.Char) { Value = garden_id });
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

        public GardenEntity GetGardenRandomly()
        {
            try
            {
                string sql = "SELECT * FROM garden WHERE status=0 ORDER BY DBMS_RANDOM.VALUE() FETCH NEXT 1 ROWS ONLY";
                DataTable dt = OracleHelper.ExecuteTable(sql);
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

        public List<GardenEntity> GetGardensByOwnerId(string owner_id)
        {
            try
            {
                string sql = "SELECT * FROM garden WHERE owner_id=:id";
                DataTable dt = OracleHelper.ExecuteTable(sql,
                    new OracleParameter("id", OracleDbType.Char) { Value = owner_id });
                return ToModelList(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<GardenEntity> GetPopularGardens(int offset)
        {
            try
            {
                string sql = "SELECT * FROM garden WHERE status=0 ORDER BY stars DESC OFFSET :offset ROWS FETCH NEXT 10 ROWS ONLY";
                DataTable dt = OracleHelper.ExecuteTable(sql,
                    new OracleParameter("offset", OracleDbType.Int32) { Value = offset });
                return ToModelList(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<GardenEntity> GetRecentGardens(int offset)
        {
            try
            {
                string sql = "SELECT * FROM garden WHERE status=0 ORDER BY create_time DESC OFFSET :offset ROWS FETCH NEXT 10 ROWS ONLY";
                DataTable dt = OracleHelper.ExecuteTable(sql,
                    new OracleParameter("offset", OracleDbType.Int32) { Value = offset });
                return ToModelList(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        // 获取Star数前num位的garden
        public List<GardenEntity> GetTopGardens(int num = 10)
        {
            try
            {
                string sql = $"SELECT * FROM garden WHERE status=0 ORDER BY stars DESC FETCH FIRST {num} ROWS ONLY";
                DataTable dt = OracleHelper.ExecuteTable(sql);
                return ToModelList(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool Insert(GardenEntity garden)
        {
            try
            {
                string sql = "INSERT INTO garden(garden_id, owner_id, name, pictures, create_time, description, position, stars, status) VALUES(garden_seq.NEXTVAL, :owner_id, :name, :pictures, :create_time, :description, :position, :stars, :status)";
                OracleParameter[] oracleParameters = new OracleParameter[]
                {
                    new OracleParameter("owner_id", OracleDbType.Char) { Value = garden.OwnerId },
                    new OracleParameter("name", OracleDbType.Varchar2) { Value = garden.Name },
                    new OracleParameter("pictures", OracleDbType.Varchar2) { Value = garden.Pictures },
                    new OracleParameter("create_time", OracleDbType.Date) { Value = garden.CreateTime},
                    new OracleParameter("description", OracleDbType.Clob) { Value = garden.Description },
                    new OracleParameter("position", OracleDbType.Varchar2) { Value =  garden.Position },
                    new OracleParameter("stars", OracleDbType.Int32) { Value = garden.Stars },
                    new OracleParameter("status", OracleDbType.Int32) { Value = garden.Status }
                };
                OracleHelper.ExecuteNonQuery(sql, oracleParameters);
                OracleHelper.ExecuteNonQuery("commit;");
                return true;
            }

            catch (Exception ex)
            {
                if (ex.Message.Contains("ORA-02185"))
                {
                    return true;
                }
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // 通过用户ID返回前端需要的历史点赞花园的记录
        public static List<GardenLikeInfo> GetGardenLikeInfo(string user_id)
        {
            List<GardenLikeInfo> ret = new();
            var gardenLikeList = GardenLikeDAL.GetAllLikes(user_id); // 获取全部点赞花园记录
            GardenDAL gardenDAL = new();
            foreach (var g in gardenLikeList)
            {
                GardenEntity garden = gardenDAL.GetGardenById(g.GardenId, out _);
                Account ac = AccountDAL.GetAccountById(garden.OwnerId, out _);
                GardenLikeInfo G = new()
                {
                    Author = ac.AccountName,
                    Avatar = ac.Portrait,
                    Title = garden.Name,
                    GardenId = g.GardenId,
                    Stars = garden.Stars,
                    Imageurl = garden.Pictures,
                    LikeTime = g.LikeTime
                };
                ret.Add(G);
            }

            return ret;
        }

        // 通过用户ID返回前端需要的历史评论花园的记录
        public static List<GardenCommentInfo> GetGardenCommentInfo(string user_id)
        {
            List<GardenCommentInfo> ret = new();
            GardenDAL gardenDAL = new();
            GardenCommentsDAL gardenCommentsDAL = new();
            var gardenCommentList = gardenCommentsDAL.GetCommentsByUserId(user_id); // 获取全部评论花园记录
            foreach (var g in gardenCommentList)
            {
                GardenEntity garden = gardenDAL.GetGardenById(g.GardenId, out _);
                Account ac = AccountDAL.GetAccountById(garden.OwnerId, out _);
                GardenCommentInfo G = new()
                {
                    Author = ac.AccountName,
                    Avatar = ac.Portrait,
                    Title = garden.Name,
                    GardenId = g.GardenId,
                    Stars = garden.Stars,
                    Imageurl = garden.Pictures,
                    Comment = g.Content,
                    CommentTime = g.ReleaseTime
                };
                ret.Add(G);
            }

            return ret;
        }
    }
}
