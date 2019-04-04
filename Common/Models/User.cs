using System.Collections.Generic;

namespace Common.Models
{
    public class User : Person
    {
        //Navigation property
        public HashSet<Rating> RatingMovies { get; set; }

        public User()
        {
            RatingMovies = new HashSet<Rating>();
        }
    }
}
