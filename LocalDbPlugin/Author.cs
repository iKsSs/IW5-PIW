using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace LocalDbPlugin
{
    public class Author : BaseModel, IPerson
    {
        public string Address { get; set; }
        public string Name { get; set; }
        public DateTime Born { get; set; }
        public byte[] Portrait { get; set; }
        public HashSet<IMovie> Movies { get; set; }

        public Author()
        {
            Movies = new HashSet<IMovie>();
        }
    }
}
