using Garden.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Garden.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountBLL _accountBLL;

        public AccountController(IAccountBLL accountBLL)
        {
            _accountBLL = accountBLL;   
        }

        [HttpGet]
        public ActionResult<string> Get(int id, string pwd) 
        {
            return _accountBLL.Login(id, pwd);

        }

    }
}
