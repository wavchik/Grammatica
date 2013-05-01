using System.Linq;
using KakPishetsya.Common.Data.Models;
using KakPishetsya.Common.Data.Repositories;

namespace KakPishetsya.DAL.Repositories
{
    public class RuleRepository : BaseRepository<Rule>
    {
        public override IQueryable<Rule> All
        {
            get { return _context.Rules; }
        }

        public override void AddNewEntity(Rule model)
        {
            _context.Rules.Add(model);
        }

        public override void Delete(int Id)
        {
            var rule = new Rule() { Id = Id };
            _context.Entry(rule).State = System.Data.EntityState.Deleted;
            Save();
        }
    }
}