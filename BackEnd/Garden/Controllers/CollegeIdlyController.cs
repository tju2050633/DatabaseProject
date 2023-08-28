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

        // ��ѯѧУ���е�
        // ������
        // ����״̬��[���õ�ID��γ�ȡ����ȡ�ѧУλ�á���С������]
        [HttpGet("SingleCollegeIdly")]
        public IEnumerable<CollegeIdly> GetSingleCollegeIdly()
        {
            return _collegeIdlyBLL.GetSingleCollegeIdly();
        }

        // ��ѯѧУ���е���ϸ��Ϣ��������ѯ��
        // �������õ�ID��idly_id��
        // ����״̬��[���õ�ID��γ�ȡ����ȡ�ѧУλ�á���С������]
        [HttpGet("CollegeIdlyInfo")]
        public ActionResult<CollegeIdly> GetCollegeIdlyInfo(string idly_id)
        {
            return _collegeIdlyBLL.GetCollegeIdlyInfo(idly_id);
        }


        // ��ѯѧУ�ȵ��ͼ
        // ������
        // ����״̬��[�ȵ��ID��������]
        [HttpGet("SingleHotSpots")]
        public IEnumerable<HotSpots> GetSingleHotSpots()
        {
            return _collegeIdlyBLL.GetSingleHotSpots();
        }

        // ��ѯ���õ���ʹ�õض�
        // ������
        // ����״̬��[�ȵ��ID�����õ�ID����԰ID��ʣ���С]
        [HttpGet("SingleIdlyLots")]
        public IEnumerable<IdlyLots> GetSingleIdlyLots()
        {
            return _collegeIdlyBLL.GetSingleIdlyLots();
        }

    }
}
