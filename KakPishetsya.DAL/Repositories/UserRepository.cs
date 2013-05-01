using System.Linq;
using KakPishetsya.Common.Data.Models;
using KakPishetsya.Common.Data.Repositories;

namespace KakPishetsya.DAL.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public override IQueryable<User> All
        {
            get { return _context.Users; }
        }

        public override void AddNewEntity(User model)
        {
            _context.Users.Add(model);
        }

        public override void Delete(int Id)
        {
            throw new System.NotImplementedException();
        }
    }
}