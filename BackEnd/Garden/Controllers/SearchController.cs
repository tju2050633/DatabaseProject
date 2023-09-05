using Garden.BLL.Interfaces;
using Garden.Models;
using Microsoft.AspNetCore.Mvc;

namespace Garden.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class SearchController : ControllerBase
  {
    private readonly ISearchBLL _searchBLL;

    public SearchController(ISearchBLL searchBLL)
    {
      _searchBLL = searchBLL;
    }

    // 获取搜索结果
    // 输入搜索关键字searchTerm
    // 返回状态：
    /*  "searchResults": [
        {
          "type": "blog",
          "data": [
          ]
        },
        {
          "type": "garden",
          "data": [
          ]
        },
        {
          "type": "activity",
          "data": [
          ]
        },
        {
          "type": "volunteer",
          "data": [
          ]
        }
      ]*/
    [HttpGet]
    public List<MySearchResult> GetSearchResults(string searchTerm)
    {
      return _searchBLL.GetSearchResults(searchTerm);
    }
  }
}
