using System.Collections.Generic;

namespace Common.Models
{
    public class Genre : BaseModel
    {
        public string Name { get; set; }

        public HashSet<Movie> Movies { get; set; }

        public Genre()
        {
            Movies = new HashSet<Movie>();
        }
    }
}
