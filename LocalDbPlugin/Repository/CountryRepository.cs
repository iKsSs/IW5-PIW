using Common.Models;

namespace Data.Repository
{
    public class CountryRepository : BaseRepository<Country>
    {
        public CountryRepository(LocalDbContext dbContext) : base(dbContext)
        {
        }
    }
}
