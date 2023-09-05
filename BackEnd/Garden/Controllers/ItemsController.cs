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
        public IActionResult ExchangeItem(int itemId)
        {

            // 数据库库存减1
            _ItemsBLL.ItemSold(itemId.ToString());

            // 用户积分减少
            // 

            bool success = true;

            if (!success)
                return BadRequest(new { success = false, message = "兑换失败" });
            return Ok(new { success = true, message = "兑换成功" });
        }
    }
}