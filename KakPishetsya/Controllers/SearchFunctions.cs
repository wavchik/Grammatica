using System.Linq;
using System.Web.Mvc;
using KakPishetsya.Common.Data.Models;
using KakPishetsya.Common.Data.Repositories;

namespace KakPishetsya.Controllers
{
    public static class SearchFunctions
    {
        public static IQueryable<Word> GetSearchByWordQuery(string name)
        {
            var repository = DependencyResolver.Current.GetService<BaseRepository<Word>>();
            return repository.QueryBy(
                x =>
                x.Name.ToLower().StartsWith(name) ||
                (!string.IsNullOrEmpty(x.InvalidDescription) && x.InvalidDescription.ToLower().StartsWith(name)));
        }
    }
}