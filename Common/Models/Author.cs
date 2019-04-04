using System.Collections.Generic;
using System.Linq;

namespace Common.Models
{
    public class Author : Person
    {
        
    }

    public class Director : Author
    {
        //Navigation property
        public HashSet<Movie> Movies { get; set; }

        public Director()
        {
            Movies = new HashSet<Movie>();
        }
    }

    public class Actor : Author
    {
        //Navigation property
        public HashSet<Movie> Movies { get; set; }

        public Actor()
        {
            Movies = new HashSet<Movie>();
        }
    }
}
