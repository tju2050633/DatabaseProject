using System;
using Garden.BLL.Interfaces;
using Garden.Models;
using Microsoft.AspNetCore.Mvc;

namespace Garden.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsBLL _ItemsBLL;

        public ItemsController(IItemsBLL ItemsBLL)
        {
            _ItemsBLL = ItemsBLL;
        }

        [HttpGet("/items/all_id")]
        public ActionResult<List<string>> GetAllItemID()
        {
            return _ItemsBLL.GetAllItemID();
        }

        [HttpGet("/items/info")]
        public ActionResult<Items> GetSingleItems(string itemId)
        {
            return _ItemsBLL.GetSingleItems(itemId);
        }

        [HttpGet("/items/cover")]
        public ActionResult<string> GetItemCover(string itemId)
        {
            return _ItemsBLL.GetItemCover(itemId);
        }

        [HttpGet("/items/images")]
        public ActionResult<List<string>> GetItemImages(string itemId)
        {
            return _ItemsBLL.GetItemImages(itemId);
        }

        [HttpPost]
        public ActionResult<string> InsertRedeem(string redeem_id, string redeemer, string item_id)
        {
            return _ItemsBLL.InsertRedeem(redeem_id, redeemer, item_id);
        }

        // item exchange

        [HttpPost("/exchange")]
        public IActionResult ExchangeItem([FromBody] ExchangeRequest request)
        {
            int status = _ItemsBLL.ItemSold(request.itemId, request.userId);

            if (status == 1)
                return Ok(new { success = false, message = "积分不足" });
            else if (status == 2)
                return Ok(new { success = false, message = "库存不足" });
            else
                return Ok(new { success = true, message = "兑换成功" });
        }

        public class ExchangeRequest
        {
            public string itemId { get; set; }
            public string userId { get; set; }
        }
    }
}