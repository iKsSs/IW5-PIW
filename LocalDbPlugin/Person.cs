using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace LocalDbPlugin
{
    internal class Person : BaseModel, IPerson
    {
        public string Address { get; set; }
        public string Name { get; set; }
        public DateTime Born { get; set; }
        public byte[] Portrait { get; set; }

        public override string ToString()
        {
            return $"ID: {base.Id}, Name: {Name}";
        }
    }
}
