using Common.Models;

namespace Data.Repository
{
    public class RatingRepository : BaseRepository<Rating>
    {
        public RatingRepository(LocalDbContext dbContext) : base(dbContext)
        {
        }
    }
}
