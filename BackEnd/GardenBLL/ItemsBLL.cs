using Garden.BLL.Interfaces;
using Garden.DAL;
using Garden.Models;

namespace Garden.BLL
{
    public class ItemsBLL : IItemsBLL
    {
        ItemsDAL itemsDAL = new();
        RedeemsDAL redeemsDAL = new();
        AccountDAL accountDAL = new();

        public Items GetSingleItems(string item_id)
        {
            return itemsDAL.GetItems(item_id, out _);
        }

        
        public string InsertRedeem(string redeem_id, string redeemer, string item_id)
        {
            Redeems redeems_info = new()
            {
                RedeemId = redeem_id,
                Redeemer = redeemer,
                ItemId = item_id,
                RedeemTime = DateTime.Now
            };

            int item_value = itemsDAL.GetPrice(item_id, out _);
            int user_value = accountDAL.GetPoints(redeemer, out _);
            if (item_value > user_value)
            {
                return "积分不足，无法兑换。";
            }
            else
            {
                bool Ins = redeemsDAL.Insert_Redeems(redeems_info);
                if (Ins)
                {
                    return "兑换成功。";
                }
                else
                {
                    return "兑换失败，请重试。";
                }
            }
        }


    }

}
