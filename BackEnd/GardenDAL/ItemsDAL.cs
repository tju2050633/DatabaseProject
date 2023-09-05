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

            items.itemId = row["item_id"].ToString();
            items.itemName = row["item_name"].ToString();
            items.price = Convert.ToInt32(row["price"]);
            items.sales = Convert.ToInt32(row["sales"]);
            items.storage = Convert.ToInt32(row["item_storage"]);
            items.image = row["image"].ToString();

            return items;
        }

        public static List<Items> ToModelList(DataTable dt)
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

        // get single item info
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

        // get all item id
        public List<string> GetAllItemID()
        {
            try
            {
                string sql = "SELECT item_id FROM items";
                DataTable dt = OracleHelper.ExecuteTable(sql);
                List<string> list = new();
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(dr["item_id"].ToString());
                }
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        // storage -=1, sales +=1
        public void ItemSold(string item_id)
        {
            try
            {
                string sql1 = "UPDATE items SET sales = sales + 1 WHERE item_id=:id";
                string sql2 = "UPDATE items SET item_storage = item_storage - 1 WHERE item_id=:id";
                OracleHelper.ExecuteNonQuery(sql1,
                    new OracleParameter("id", OracleDbType.Char) { Value = item_id });
                OracleHelper.ExecuteNonQuery(sql2,
                    new OracleParameter("id", OracleDbType.Char) { Value = item_id });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //��ȡ��Ʒ���������
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

        public int GetStorage(string item_id, out int status)
        {
            try
            {
                string sql = "SELECT * FROM items WHERE item_id=:id";
                DataTable dt = OracleHelper.ExecuteTable(sql,
                    new OracleParameter("id", OracleDbType.Char) { Value = item_id });
                if (dt.Rows.Count != 1)
                {
                    status = 2;
                    return -1;
                }
                status = 0;
                DataRow dr = dt.Rows[0];
                int value = Convert.ToInt32(dr["item_storage"]);
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