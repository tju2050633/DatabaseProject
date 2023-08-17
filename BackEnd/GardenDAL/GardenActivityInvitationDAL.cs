using Garden.DAL.Core;
using Garden.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;

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
                GardenId = row["garden_id"].ToString()
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

        public List<GardenActivityInvitation> GetInvitationsByGardenId(string garden_id)
        {
            try
            {
                string sql = "SELECT * FROM garden_activity_invitation WHERE garden_id=:id";
                DataTable dt = OracleHelper.ExecuteTable(sql,
                    new OracleParameter("id", OracleDbType.Char) { Value = garden_id });
                return ToModelList(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
