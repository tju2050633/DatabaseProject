using Garden.BLL.Interfaces;
using Garden.Models;
using Microsoft.AspNetCore.Mvc;

namespace Garden.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsBLL _ItemsBLL;

        public ItemsController(IItemsBLL ItemsBLL)
        {
            _ItemsBLL = ItemsBLL;
        }

        // 输入商品id(item_id)
        // 返回状态：[商品id、商品名、所需积分、库存、已售数量]
        [HttpGet("singleitems")]
        public ActionResult<Items> GetSingleItems(string item_id)
        {
            return _ItemsBLL.GetSingleItems(item_id);
        }

        // 输入商品兑换记录(redeem _id)、兑换者id(redeemer)、商品id(item_id)
        // 返回状态：["兑换成功""兑换失败"]
        [HttpPost]
        public ActionResult<string> InsertRedeem(string redeem_id, string redeemer, string item_id)
        {
            return _ItemsBLL.InsertRedeem(redeem_id, redeemer, item_id);
        }



    }
}