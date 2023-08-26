using Garden.Models;

namespace Garden.BLL.Interfaces
{
    public interface IStatisticsBLL
    {
        public int GetUsersCount();

        public int GetUsersCountBeforeDate(string date);

        public int GetActiveUsersCountBeforeDate(string date);

        public int GetUsersCountByGrade(string grade);

        public int GetGardensCount();

        public int GetGardensCountBeforeDate(string date);

        public int GetGardensCountByPosition(string position);

        public int GetBlogsCount();

        public int GetBlogsCountBeforeDate(string date);
    }
}
