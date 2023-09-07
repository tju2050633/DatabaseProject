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

        public List<string> GetAllItemID()
        {
            return itemsDAL.GetAllItemID();
        }

        // 完成交易
        public int ItemSold(string itemId, string userId)
        {
            // get storage and price
            int storage = itemsDAL.GetStorage(itemId, out _);
            int price = itemsDAL.GetPrice(itemId, out _);
            int point = AccountDAL.GetAccountById(userId, out _).Points;

            if (point < price)
            {
                // point not enough
                return 1;
            }
            else if(storage <= 0)
            {
                // storage not enough
                return 2;
            }
            else
            {
                // storage -=1, sales +=1
                itemsDAL.ItemSold(itemId);

                // point -= price
                accountDAL.SetPoint(userId, point - price);

                return 0;
            }
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
            int user_value = AccountDAL.GetAccountById(redeemer, out _).Points;
            if (item_value > user_value)
            {
                return "���ֲ��㣬�޷��һ���";
            }
            else
            {
                bool Ins = redeemsDAL.Insert_Redeems(redeems_info);
                if (Ins)
                {
                    return "�һ��ɹ���";
                }
                else
                {
                    return "�һ�ʧ�ܣ������ԡ�";
                }
            }
        }
    }

}
