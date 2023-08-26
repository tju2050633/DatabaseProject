using Garden.BLL.Interfaces;
using Garden.DAL;
using Garden.Models;

namespace Garden.BLL
{
    public class SearchBLL : ISearchBLL
    {
        static SearchDAL searchDAL = new();

        public List<MySearchResult> GetSearchResults(string searchTerm)
        {
            return searchDAL.GetResults(searchTerm, out _);
        }
    }
}