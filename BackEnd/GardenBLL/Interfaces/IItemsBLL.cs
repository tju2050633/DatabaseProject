using Garden.Models;

namespace Garden.BLL.Interfaces
{
    public interface IItemsBLL
    {
        public Items GetSingleItems(string item_id);

        public string InsertRedeem(string redeem_id, string redeemer, string item_id);

    }
}