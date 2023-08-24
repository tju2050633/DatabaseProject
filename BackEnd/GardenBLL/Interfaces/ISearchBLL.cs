using System.DirectoryServices;
using Garden.Models;

namespace Garden.BLL.Interfaces
{
    public interface ISearchBLL
    {
        public List<MySearchResult> GetSearchResults(string searchTerm);
    }
}