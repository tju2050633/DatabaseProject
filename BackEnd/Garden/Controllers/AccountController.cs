using Garden.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Garden.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountBLL _accountBLL;

        public AccountController(IAccountBLL accountBLL)
        {
            _accountBLL = accountBLL;
        }

        [HttpGet]
        public ActionResult<string> Get(string id, string pwd)
        {
            return _accountBLL.Login(id, pwd);
        }
    }
}
