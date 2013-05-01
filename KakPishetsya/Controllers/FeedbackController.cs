using System.Web.Mvc;
using KakPishetsya.Common.Data.Models;
using KakPishetsya.Common.Data.Repositories;
using KakPishetsya.DAL.Controllers;
using KakPishetsya.Models;

namespace KakPishetsya.Controllers
{
    public class FeedbackController : PageDataController<Feedback>
    {
        public FeedbackController(BaseRepository<Feedback> repository)
            : base(repository)
        {
        }

        [HttpPost]
        public JsonResult Create(FeedbackInput input)
        {
            Response.ContentType = "application/json";

            _repository.AddNewEntity(new Feedback()
            {
                Name = input.Name,
                Email = input.Email,
                Text = input.Text
            });

            _repository.Save();

            var result = Json((new { response = true }), JsonRequestBehavior.AllowGet);
            return result;
        }
    }
}