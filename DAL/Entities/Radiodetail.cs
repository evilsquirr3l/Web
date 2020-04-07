using System.Collections.Generic;

namespace DAL.Entities
{
    public class Radiodetail : BaseEntity //компонентна база = радиодетали
    {
        public ICollection<DetailTemplate> Details { get; set; }
    }
}