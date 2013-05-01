using System.Linq;
using KakPishetsya.Common.Data.Models;
using KakPishetsya.Common.Data.Repositories;

namespace KakPishetsya.DAL.Repositories
{
    public class UnregSearchWordRepository : BaseRepository<UnregSearchWord>
    {
        public override IQueryable<UnregSearchWord> All
        {
            get { return _context.UnregSearchWords; }
        }

        public override void AddNewEntity(UnregSearchWord model)
        {
            _context.UnregSearchWords.Add(model);
        }

        public override void Delete(int id)
        {
            var word = new UnregSearchWord() { Id = id };
            _context.Entry(word).State = System.Data.EntityState.Deleted;
            Save();
        }
    }
}