using Garden.Models;

namespace Garden.BLL.Interfaces
{
    public interface IItemsBLL
    {
        public Items GetSingleItems(string item_id);
        public string GetItemCover(string item_id);
        public List<string> GetItemImages(string item_id);

        public List<string> GetAllItemID();

        public int ItemSold(string item_id, string user_id);

        public string InsertRedeem(string redeem_id, string redeemer, string item_id);

    }
}