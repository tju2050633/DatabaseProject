using Garden.DAL.Core;
using Garden.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Garden.DAL
{
    public class VolunteerRecruitDAL
    {
        private VolunteerRecruit ToModel(DataRow row)
        {
            VolunteerRecruit recruit = new();
            recruit.RecruitmentId = row["recruitement_id"].ToString();
            recruit.GardenId = row["garden_id"].ToString();
            recruit.RecruiterId = row["recruiter_id"].ToString();
            recruit.RecruitTime = Convert.ToDateTime(row["recruit_time"]);
            recruit.RecruitContent = row["recruit_content"].ToString();
            return recruit;
        }

        private List<VolunteerRecruit> ToModelList(DataTable dt)
        {
            List<VolunteerRecruit> rl = new();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                VolunteerRecruit recruit = ToModel(dr);
                rl.Add(recruit);
            }
            return rl;
        }

        public VolunteerRecruit GetRecruitById(string recruitement_id, out int status)
        {
            try
            {
                string sql = "SELECT * FROM volunteer_recruit WHERE recruitement_id=:id";
                DataTable dt = OracleHelper.ExecuteTable(sql,
                                       new OracleParameter("id", OracleDbType.Char) { Value = recruitement_id });
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

        public VolunteerRecruit GetRecruitRandomly()
        {
              try
            {
                string sql = "SELECT * FROM volunteer_recruit ORDER BY DBMS_RANDOM.VALUE";
                DataTable dt = OracleHelper.ExecuteTable(sql);
                if (dt.Rows.Count == 0)
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

        public List<VolunteerRecruit> GetRecruitByGardenId(string garden_id, out int status)
        {
            try
            {
                string sql = "SELECT * FROM volunteer_recruit WHERE garden_id=:id";
                DataTable dt = OracleHelper.ExecuteTable(sql,
                    new OracleParameter("id", OracleDbType.Char) { Value = garden_id });
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

        public bool Insert(VolunteerRecruit recruit, out int status)
        {
            try
            {
                string sql = "INSERT INTO volunteer_recruit(recruitement_id, garden_id, recruiter_id, recruit_time, recruit_content) VALUES(volunteer_recruitement_seq.NEXTVAL,:garden_id,:recruiter_id,:recruit_time,:recruit_content)";
                OracleParameter[] oracleParameters = new OracleParameter[]
                {
                    new OracleParameter("recruitement_id", OracleDbType.Char) { Value = recruit.RecruitmentId },
                    new OracleParameter("garden_id", OracleDbType.Char) { Value = recruit.GardenId },
                    new OracleParameter("recruiter_id", OracleDbType.Char) { Value = recruit.RecruiterId },
                    new OracleParameter("recruit_time", OracleDbType.Date) { Value = recruit.RecruitTime },
                    new OracleParameter("recruit_content", OracleDbType.Clob) { Value = recruit.RecruitContent }
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

        public bool Delete(string recruitement_id, out int status)
        {
            try
            {
                string sql = "DELETE FROM volunteer_recruit WHERE recruitement_id=:id";
                OracleParameter[] oracleParameters = new OracleParameter[]
                {
                    new OracleParameter("id", OracleDbType.Char) { Value = recruitement_id }
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

        public bool Update(VolunteerRecruit recruit, out int status)
        {
            try
            {
                string sql = "UPDATE volunteer_recruit SET recruit_time=:recruit_time, recruit_content=:recruit_content WHERE recruitement_id=:id";
                OracleParameter[] oracleParameters = new OracleParameter[]
                {
                    new OracleParameter("recruit_time", OracleDbType.Date) { Value = recruit.RecruitTime },
                    new OracleParameter("recruit_content", OracleDbType.Clob) { Value = recruit.RecruitContent },
                    new OracleParameter("id", OracleDbType.Char) { Value = recruit.RecruitmentId }
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
    }
}
