using System;
using System.ComponentModel.DataAnnotations;

namespace Common.Filters
{
    public class MovieFilter : BaseFilter
    {
        public string Name { get; set; }
        public int? Rating { get; set; }
        public int? Year { get; set; }

        public MovieFilter() : base(null)
        {
            Name = null;
            Rating = null;
            Year = null;
        }

        public MovieFilter(Guid? id, string name = null, int? rating = null, int? year = null) : base(id)
        {
            Name = name;
            Rating = rating;
            Year = year;
        }
    }
}
