using Common.Models;

namespace Data.Repository
{
    public class DirectorRepository : BaseRepository<Director>
    {
        public DirectorRepository(LocalDbContext dbContext) : base(dbContext)
        {
        }
    }
}
