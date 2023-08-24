using Garden.BLL.Interfaces;
using Garden.DAL;
using Garden.Models;

namespace Garden.BLL
{
    public class SearchBLL : ISearchBLL
    {
        public List<MySearchResult> GetSearchResults(string searchTerm)
        {
            return SearchDAL.GetResults(searchTerm, out _);
        }
    }
}