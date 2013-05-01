using System.Web.Mvc;
using KakPishetsya.Common.Data.Models;
using KakPishetsya.Common.Data.Repositories;
using KakPishetsya.DAL.Controllers;

namespace KakPishetsya.Controllers
{
    public class OfferWordController : PageDataController<OfferWord>
    {
        public OfferWordController(BaseRepository<OfferWord> repository)
            : base(repository)
        {
        }

        [HttpPost]
        public JsonResult Offer(string word)
        {
            Response.ContentType = "application/json";

            _repository.AddNewEntity(new OfferWord()
            {
                Name = word
            });

            _repository.Save();

            var result = Json((new { response = true }), JsonRequestBehavior.AllowGet);
            return result;
        }
    }
}