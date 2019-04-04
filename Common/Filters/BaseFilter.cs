using System;

namespace Common.Filters
{
    public abstract class BaseFilter
    {
        public Guid? Id { get; set; }

        protected BaseFilter(Guid? id)
        {
            Id = id;
        }
    }
}
