using System;

namespace Data.Entities
{
    public class Detail : BaseEntity
    {
        public string Name { get; set; }

        public DateTime CreationTime { get; set; }

        public int DetailTemplateId { get; set; }

        public DetailTemplate DetailTemplate { get; set; }
    }
}