using System.Collections.Generic;

namespace Common.Models
{
    public class Country : BaseModel
    {
        public string Name { get; set; }

        public HashSet<Movie> Movies { get; set; }

        public Country()
        {
            Movies = new HashSet<Movie>();
        }
    }
}
