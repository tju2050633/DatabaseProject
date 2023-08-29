using Garden.BLL.Interfaces;
using Garden.DAL;
using Garden.Models;

namespace Garden.BLL
{
    public class CollegeIdlyBLL : ICollegeIdlyBLL
    {

        CollegeIdlyDAL collegeIdlyDAL = new();
        HotSpotsDAL hotSpotsDAL = new();
        IdlyLotsDAL idlyLotsDAL = new();

        //��ȡѧУ���е�
        public List<CollegeIdly> GetSingleCollegeIdly()
        {
            return collegeIdlyDAL.GetCollegeIdly(out _);
        }

        //��ȡѧУ���е���ϸ��Ϣ��������
        public CollegeIdly GetCollegeIdlyInfo(string idly_id)
        {
            return collegeIdlyDAL.Get_CollegeIdly(idly_id, out _);
        }

        //��ȡѧУ�ȵ��ͼ
        public List<HotSpots> GetSingleHotSpots()
        {
            return hotSpotsDAL.GetHotSpots(out _);
        }

        //��ȡ���õ���ʹ�õض�
        public List<IdlyLots> GetSingleIdlyLots()
        {
            return idlyLotsDAL.GetIdlyLots(out _);
        }
    }

}