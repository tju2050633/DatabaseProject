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
            return statisticsDAL.GetUsersCountBefore(DateTime.Now);
        }

        public int GetUsersCountBeforeDate(string date)
        {
            DateTime dateValue;
            if (!DateTime.TryParse(date + " 23:59:59", out dateValue))
            {
                return -1;
            }
            return statisticsDAL.GetUsersCountBefore(dateValue);
        }

        public int GetActiveUsersCountBeforeDate(string date)
        {
            DateTime dateValue;
            if (!DateTime.TryParse(date + " 23:59:59", out dateValue))
            {
                return -1;
            }
            return statisticsDAL.GetActiveUsersCountBefore(dateValue);
        }

        public int GetUsersCountByGrade(string grade)
        {
            return statisticsDAL.GetUsersCountByGrade(grade);
        }

        public int GetGardensCount()
        {
            return statisticsDAL.GetGardensCountBefore(DateTime.Now);
        }

        public int GetGardensCountBeforeDate(string date)
        {
            DateTime dateValue;
            if (!DateTime.TryParse(date + " 23:59:59", out dateValue))
            {
                return -1;
            }
            return statisticsDAL.GetGardensCountBefore(dateValue);
        }

        public int GetGardensCountByPosition(string position)
        {
            return statisticsDAL.GetGardensCountByPosition(position);
        }

        public int GetBlogsCount()
        {
            return statisticsDAL.GetBlogsCountBefore(DateTime.Now);
        }

        public int GetBlogsCountBeforeDate(string date)
        {
            DateTime dateValue;
            if (!DateTime.TryParse(date + " 23:59:59", out dateValue))
            {
                return -1;
            }
            return statisticsDAL.GetBlogsCountBefore(dateValue);
        }
    }
}
