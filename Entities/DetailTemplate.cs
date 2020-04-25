using System.Collections.Generic;

namespace Entities
{
    public class DetailTemplate : BaseEntity
    {
        public ICollection<Detail> InputDetails { get; set; }

        public int OutputDetailId { get; set; }

        public int ProductionId { get; set; }

        public Production Production { get; set; }
    }
}