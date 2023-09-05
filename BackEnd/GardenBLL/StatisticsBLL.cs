using Garden.BLL.Interfaces;
using Garden.DAL;
using Garden.Models;

namespace Garden.BLL
{
    public class StatisticsBLL: IStatisticsBLL
    {
        StatisticsDAL statisticsDAL = new();

        public int GetUsersCount()
        {
            return statisticsDAL.GetUsersCountBefore(string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now));
        }

        public int GetUsersCountBeforeDate(string date)
        {
            return statisticsDAL.GetUsersCountBefore(date + " 23:59:59");
        }

        public int GetActiveUsersCountBeforeDate(string date)
        {
            return statisticsDAL.GetActiveUsersCountBefore(date + " 23:59:59");
        }

        public int GetUsersCountByGrade(string grade)
        {
            return statisticsDAL.GetUsersCountByGrade(grade);
        }

        public int GetGardensCount()
        {
            return statisticsDAL.GetGardensCountBefore(string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now));
        }

        public int GetGardensCountBeforeDate(string date)
        {
            return statisticsDAL.GetGardensCountBefore(date + " 23:59:59");
        }

        public int GetGardensCountByPosition(string position)
        {
            return statisticsDAL.GetGardensCountByPosition(position);
        }

        public int GetBlogsCount()
        {
            return statisticsDAL.GetBlogsCountBefore(string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now));
        }

        public int GetBlogsCountBeforeDate(string date)
        {
            return statisticsDAL.GetBlogsCountBefore(date + " 23:59:59");
        }
    }
}
