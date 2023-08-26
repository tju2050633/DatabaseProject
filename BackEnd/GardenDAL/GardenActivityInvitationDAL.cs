using Garden.DAL.Core;
using Garden.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Diagnostics;

namespace Garden.DAL
{
    public class GardenActivityInvitationDAL
    {
        private GardenActivityInvitation ToModel(DataRow row)
        {
            GardenActivityInvitation invitation = new()
            {
                InvitationId = row["invitation_id"].ToString(),
                InvitorId = row["invitor_id"].ToString(),
                InviteeId = row["invitee_id"].ToString(),
                ActivityId = row["activity_id"].ToString()
            };
            return invitation;
        }

        private List<GardenActivityInvitation> ToModelList(DataTable dt)
        {
            List<GardenActivityInvitation> il = new();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                GardenActivityInvitation invitation = ToModel(dr);
                il.Add(invitation);
            }
            return il;
        }

        public List<GardenActivityInvitation> GetInvitationsByActivityId(string activity_id)
        {
            try
            {
                string sql = "SELECT * FROM garden_activity_invitation WHERE activity_id=:id";
                DataTable dt = OracleHelper.ExecuteTable(sql,
                    new OracleParameter("id", OracleDbType.Char) { Value = activity_id });
                return ToModelList(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public int GetInvitationsCountByInviteeIdAndActivityId(string invitee_id, string activity_id)
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM garden_activity_invitation WHERE invitee_id=:id AND activity_id=:activity_id";
                OracleParameter[] sp = new[]
                {
                    new OracleParameter("id", OracleDbType.Char) { Value = invitee_id },
                    new OracleParameter("activity_id", OracleDbType.Char) { Value = activity_id }
                };
                return (int)OracleHelper.ExecuteScalar(sql, sp);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        public bool Insert(GardenActivityInvitation invitation)
        {
            try
            {
                string sql = "INSERT INTO garden_activity_invitation VALUES(GARDEN_ACTIVITY_INVITATION_SEQ.NEXTVAL, :invitor_id, :invitee_id, :garden_id)";
                OracleParameter[] sp = new[]
                {
                    new OracleParameter("invitor_id", OracleDbType.Char) { Value = invitation.InvitorId },
                    new OracleParameter("invitee_id", OracleDbType.Char) { Value = invitation.InviteeId },
                    new OracleParameter("activity_id", OracleDbType.Char) { Value = invitation.ActivityId }
                };
                OracleHelper.ExecuteNonQuery(sql, sp);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
