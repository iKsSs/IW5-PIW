using Common.Models;

namespace Data.Repository
{
    public class GenreRepository : BaseRepository<Genre>
    {
        public GenreRepository(LocalDbContext dbContext) : base(dbContext)
        {
        }
    }
}
