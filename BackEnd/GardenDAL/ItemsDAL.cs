using Garden.DAL.Core;
using Garden.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Garden.DAL
{
    public class ItemsDAL
    {

        private static Items ToModel(DataRow row)
        {
            Items items = new();

            items.ItemId = row["item_id"].ToString();
            items.ItemName = row["item_name"].ToString();
            items.Price = Convert.ToInt32(row["price"]);
            items.ItemStorage = row["item_storage"].ToString();
            items.Sales = Convert.ToInt32(row["sales"]);

            return items;
        }

        private static List<Items> ToModelList(DataTable dt)
        {
            List<Items> I = new();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                Items items = ToModel(dr);
                I.Add(items);
            }
            return I;
        }

        //获取商品的所有信息
        public Items GetItems(string item_id, out int status)
        {

            try
            {
                string sql = "SELECT * FROM items WHERE item_id=:id";
                DataTable dt = OracleHelper.ExecuteTable(sql,
                    new OracleParameter("id", OracleDbType.Char) { Value = item_id });
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
        //获取商品的所需积分
        public int GetPrice(string item_id, out int status)
        {

            try
            {
                string sql = "SELECT price FROM items WHERE item_id=:id";
                DataTable dt = OracleHelper.ExecuteTable(sql,
                    new OracleParameter("id", OracleDbType.Char) { Value = item_id });
                if (dt.Rows.Count != 1)
                {
                    status = 2;
                    return -1;
                }
                status = 0;
                DataRow dr = dt.Rows[0];
                int value = Convert.ToInt32(dr["price"]);
                return value;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                status = 1;
                return -1;
            }
        }
    }

}