using Garden.BLL;
using Garden.BLL.Interfaces;
using Garden.Models;
using Microsoft.AspNetCore.Mvc;

namespace Garden.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsBLL _statisticsBLL;

        public StatisticsController(IStatisticsBLL statisticsBLL)
        {
            _statisticsBLL = statisticsBLL;
        }

        // 查询
        // 无输入
        // 返回：int，用户总数
        [HttpGet("usercount")]
        public ActionResult<int> GetUsersCount()
        {
            return _statisticsBLL.GetUsersCount();
        }

        // 查询
        // 输入：string，日期，格式为"YYYY-MM-DD"
        // 返回：int，截止到该日期晚上12点的用户总数
        [HttpGet("usercount/date")]
        public ActionResult<int> GetUsersCountBeforeDate(string date)
        {
            return _statisticsBLL.GetUsersCountBeforeDate(date);
        }

        // 查询
        // 输入：string，日期，格式为"YYYY-MM-DD"
        // 返回：int，截止到该日期晚上12点的活跃用户总数
        [HttpGet("activeusercount/date")]
        public ActionResult<int> GetActiveUsersCountBeforeDate(string date)
        {
            return _statisticsBLL.GetActiveUsersCountBeforeDate(date);
        }

        // 查询
        // 输入：string，用户年级，包括"大一"、"大二"、"大三"、"大四"、"大五"、"硕士"、"博士"、"其他"
        // 返回：int，该年级的用户总数
        [HttpGet("usercount/grade")]
        public ActionResult<int> GetUsersCountByGrade(string grade)
        {
            return _statisticsBLL.GetUsersCountByGrade(grade);
        }

        // 查询
        // 无输入
        // 返回：int，花园总数
        [HttpGet("gardencount")]
        public ActionResult<int> GetGardensCount()
        {
            return _statisticsBLL.GetGardensCount();
        }

        // 查询
        // 输入：string，日期，格式为"YYYY-MM-DD"
        // 返回：int，截止到该日期晚上12点的花园总数
        [HttpGet("gardencount/date")]
        public ActionResult<int> GetGardensCountBeforeDate(string date)
        {
            return _statisticsBLL.GetGardensCountBeforeDate(date);
        }

        // 查询
        // 输入：string，花园校区位置，包括"四平路校区"、"嘉定校区"等
        // 返回：int，该校区的花园总数
        [HttpGet("gardencount/position")]
        public ActionResult<int> GetGardensCountByPosition(string position)
        {
            return _statisticsBLL.GetGardensCountByPosition(position);
        }

        // 查询
        // 无输入
        // 返回：int，博客总数
        [HttpGet("blogcount")]
        public ActionResult<int> GetBlogsCount()
        {
            return _statisticsBLL.GetBlogsCount();
        }

        // 查询
        // 输入：string，日期，格式为"YYYY-MM-DD"
        // 返回：int，截止到该日期晚上12点的博客总数
        [HttpGet("blogcount/date")]
        public ActionResult<int> GetBlogsCountBeforeDate(string date)
        {
            return _statisticsBLL.GetBlogsCountBeforeDate(date);
        }
    }
}
