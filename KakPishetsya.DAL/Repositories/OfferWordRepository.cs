using System.Linq;
using KakPishetsya.Common.Data.Models;
using KakPishetsya.Common.Data.Repositories;

namespace KakPishetsya.DAL.Repositories
{
    public class OfferWordRepository : BaseRepository<OfferWord>
    {
        public override IQueryable<OfferWord> All
        {
            get { return _context.OfferWords; }
        }

        public override void AddNewEntity(OfferWord model)
        {
            _context.OfferWords.Add(model);
        }

        public override void Delete(int id)
        {
            var offerWord = new OfferWord() { Id = id };
            _context.Entry(offerWord).State = System.Data.EntityState.Deleted;
            Save();
        }
    }
}