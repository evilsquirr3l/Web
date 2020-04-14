using System.Collections.Generic;

namespace DAL.Entities
{
    public class Production : BaseEntity
    {
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<Detail> Details { get; set; }
    }
}