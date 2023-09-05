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

        // ������Ʒid(item_id)
        // ����״̬��[��Ʒid����Ʒ����������֡���桢��������]
        [HttpGet("/items")]
        public ActionResult<Items> GetSingleItems(string itemId)
        {
            return _ItemsBLL.GetSingleItems(itemId);
        }

        // ������Ʒ�һ���¼(redeem _id)���һ���id(redeemer)����Ʒid(item_id)
        // ����״̬��["�һ��ɹ�""�һ�ʧ��"]
        [HttpPost]
        public ActionResult<string> InsertRedeem(string redeem_id, string redeemer, string item_id)
        {
            return _ItemsBLL.InsertRedeem(redeem_id, redeemer, item_id);
        }

        [HttpPost("/exchange")]
        public IActionResult ExchangeItem(int itemId, int userId)
        {

            int status = _ItemsBLL.ItemSold(itemId.ToString(), userId.ToString());

            if (status == 1)
                return BadRequest(new { success = false, message = "积分不足" });
            else if (status == 2)
                return BadRequest(new { success = false, message = "库存不足" });
            else
                return Ok(new { success = true, message = "兑换成功" });
        }
    }
}