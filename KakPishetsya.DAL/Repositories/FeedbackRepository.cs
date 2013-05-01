using System.Linq;
using KakPishetsya.Common.Data.Models;
using KakPishetsya.Common.Data.Repositories;

namespace KakPishetsya.DAL.Repositories
{
    public class FeedbackRepository : BaseRepository<Feedback>
    {
        public override IQueryable<Feedback> All
        {
            get { return _context.Feedbacks; }
        }

        public override void AddNewEntity(Feedback model)
        {
            _context.Feedbacks.Add(model);
        }

        public override void Delete(int id)
        {
            var feedback = new Feedback() { Id = id };
            _context.Entry(feedback).State = System.Data.EntityState.Deleted;
            Save();
        }
    }
}