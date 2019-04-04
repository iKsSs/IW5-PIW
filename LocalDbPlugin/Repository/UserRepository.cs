using Common.Models;

namespace Data.Repository
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(LocalDbContext dbContext) : base(dbContext)
        {
        }
    }
}
