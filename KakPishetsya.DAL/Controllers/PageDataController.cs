using KakPishetsya.Common.Data.Controllers;
using KakPishetsya.Common.Data.Models;
using KakPishetsya.Common.Data.Repositories;

namespace KakPishetsya.DAL.Controllers
{
    public abstract class PageDataController<T> : PageController
        where T : BaseModel
    {
        protected readonly BaseRepository<T> _repository;

        protected PageDataController(BaseRepository<T> repository)
        {
            _repository = repository;
        }
    }
}