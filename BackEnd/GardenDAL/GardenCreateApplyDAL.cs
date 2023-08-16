using Garden.DAL.Core;
using Garden.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Garden.DAL
{
    public class GardenCreateApplyDAL
    {
        private GardenCreateApply ToModel(DataRow row)
        {
            GardenCreateApply apply = new()
            {
                ApplyId = row["apply_id"].ToString(),
                ApplicantId = row["applicant_id"].ToString(),
                GardenId = row["garden_id"].ToString(),
                ApplyTime = Convert.ToDateTime(row["apply_time"])
            };
            return apply;
        }

        private List<GardenCreateApply> ToModelList(DataTable dt)
        {
            List<GardenCreateApply> al = new();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                GardenCreateApply apply = ToModel(dr);
                al.Add(apply);
            }
            return al;
        }
    }
}
