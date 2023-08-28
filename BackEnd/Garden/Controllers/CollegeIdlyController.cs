using Garden.BLL.Interfaces;
using Garden.Models;
using Microsoft.AspNetCore.Mvc;

namespace Garden.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollegeIdlyController : ControllerBase
    {
        private readonly ICollegeIdlyBLL _collegeIdlyBLL;

        public CollegeIdlyController(ICollegeIdlyBLL collegeIdlyBLL)
        {
            _collegeIdlyBLL = collegeIdlyBLL;
        }

        // 查询学校空闲地
        // 无输入
        // 返回状态：[闲置地ID、纬度、经度、学校位置、大小、土质]
        [HttpGet("SingleCollegeIdly")]
        public IEnumerable<CollegeIdly> GetSingleCollegeIdly()
        {
            return _collegeIdlyBLL.GetSingleCollegeIdly();
        }

        // 查询学校空闲地详细信息（单个查询）
        // 输入闲置地ID（idly_id）
        // 返回状态：[闲置地ID、纬度、经度、学校位置、大小、土质]
        [HttpGet("CollegeIdlyInfo")]
        public ActionResult<CollegeIdly> GetCollegeIdlyInfo(string idly_id)
        {
            return _collegeIdlyBLL.GetCollegeIdlyInfo(idly_id);
        }


        // 查询学校热点地图
        // 无输入
        // 返回状态：[热点地ID、人流量]
        [HttpGet("SingleHotSpots")]
        public IEnumerable<HotSpots> GetSingleHotSpots()
        {
            return _collegeIdlyBLL.GetSingleHotSpots();
        }

        // 查询闲置地已使用地段
        // 无输入
        // 返回状态：[热点地ID、闲置地ID、花园ID、剩余大小]
        [HttpGet("SingleIdlyLots")]
        public IEnumerable<IdlyLots> GetSingleIdlyLots()
        {
            return _collegeIdlyBLL.GetSingleIdlyLots();
        }

    }
}
