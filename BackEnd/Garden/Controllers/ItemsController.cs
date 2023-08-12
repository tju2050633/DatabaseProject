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

        // ������Ʒid(item_id)
        // ����״̬��[��Ʒid����Ʒ����������֡���桢��������]
        [HttpGet("singleitems")]
        public ActionResult<Items> GetSingleItems(string item_id)
        {
            return _ItemsBLL.GetSingleItems(item_id);
        }

        // ������Ʒ�һ���¼(redeem _id)���һ���id(redeemer)����Ʒid(item_id)
        // ����״̬��["�һ��ɹ�""�һ�ʧ��"]
        [HttpPost]
        public ActionResult<string> InsertRedeem(string redeem_id, string redeemer, string item_id)
        {
            return _ItemsBLL.InsertRedeem(redeem_id, redeemer, item_id);
        }



    }
}