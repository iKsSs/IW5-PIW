using Common.Models;

namespace Data.Repository
{
    public class ActorRepository : BaseRepository<Actor>
    {
        public ActorRepository(LocalDbContext dbContext) : base(dbContext)
        {
        }
    }
}
