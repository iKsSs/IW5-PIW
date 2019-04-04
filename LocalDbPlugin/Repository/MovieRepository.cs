using Common.Models;

namespace Data.Repository
{
    public class MovieRepository : BaseRepository<Movie>
    {
        public MovieRepository(LocalDbContext dbContext) : base(dbContext)
        {
        }
    }
}
