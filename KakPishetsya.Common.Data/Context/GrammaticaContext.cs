using System.Data.Entity;
using KakPishetsya.Common.Data.Models;

namespace KakPishetsya.Common.Data.Context
{
    public class GrammaticaContext : DbContext
    {
        public DbSet<Word> Words { get; set; }

        public DbSet<Rule> Rules { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<OfferWord> OfferWords { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }

        public DbSet<UnregSearchWord> UnregSearchWords { get; set; }
    }
}
