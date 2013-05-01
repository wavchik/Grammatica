using System;
using System.Linq;
using KakPishetsya.Common.Data.Models;
using KakPishetsya.Common.Data.Repositories;

namespace KakPishetsya.DAL.Repositories
{
    public class WordRepository : BaseRepository<Word>
    {
        public override IQueryable<Word> All
        {
            get { return _context.Words; }
        }

        public override void AddNewEntity(Word model)
        {
            _context.Words.Add(model);
        }

        public override void Delete(int Id)
        {
            var word = new Word() { Id = Id };
            _context.Entry(word).State = System.Data.EntityState.Deleted;
            Save();
        }

        public override void InsertOrUpdate(Word model)
        {
            base.InsertOrUpdate(model);

            model.DateModified = DateTime.UtcNow;
        }
    }
}