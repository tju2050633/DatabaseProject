using Garden.DAL.Core;
using Garden.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Garden.DAL
{
    public class RedeemsDAL
    {

        private static Redeems ToModel(DataRow row)
        {
            Redeems redeems = new();

            redeems.RedeemId = row["redeem_id"].ToString();
            redeems.Redeemer = row["redeemer"].ToString();
            redeems.ItemId = row["item_id"].ToString();
            redeems.RedeemTime = Convert.ToDateTime(row["create_time"]); ;

            return redeems;
        }

        private static List<Redeems> ToModelList(DataTable dt)
        {
            List<Redeems> R = new();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                Redeems redeems = ToModel(dr);
                R.Add(redeems);
            }
            return R;
        }

        //²åÈë¶Ò»»¼ÇÂ¼
        public bool Insert_Redeems(Redeems redeems)
        {
            try
            {
                string sql = "INSERT INTO redeems(redeem_id, redeemer, item_id, redeem_time) VALUES(redeems_seq.NEXTVAL, :redeem_id, :redeemer, :item_id, :redeem_time)";
                OracleParameter[] oracleParameters = new OracleParameter[]
                {
                    new OracleParameter("redeem_id", OracleDbType.Char) { Value = redeems.RedeemId },
                    new OracleParameter("redeemer", OracleDbType.Char) { Value = redeems.Redeemer },
                    new OracleParameter("item_id", OracleDbType.Char) { Value = redeems.ItemId },
                    new OracleParameter("redeem_time", OracleDbType.Date) { Value = redeems.RedeemTime},
                };
                OracleHelper.ExecuteNonQuery(sql, oracleParameters);
                OracleHelper.ExecuteNonQuery("commit;");
                return true;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (ex.Message.Contains("ORA-02185"))
                {
                    return true;
                }
                return false;
            }
        }
    }
}