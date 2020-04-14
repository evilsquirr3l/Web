using System;

namespace BLL.Models
{
    public class DetailModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreationTime { get; set; }

        public int DetailTemplateId { get; set; }

        public DetailTemplateModel DetailTemplate { get; set; }
    }
}