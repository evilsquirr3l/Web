using System.Collections.Generic;

namespace Business.Models
{
    public class DetailTemplateModel
    {
        public int Id { get; set; }

        public ICollection<DetailModel> InputDetails { get; set; }

        public int DetailId { get; set; }

        public int ProductionId { get; set; }

        public ProductionModel Production { get; set; }
    }
}