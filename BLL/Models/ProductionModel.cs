using System.Collections.Generic;
using DAL.Entities;

namespace BLL.Models
{
    public class ProductionModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public int CategoryId { get; set; }
        
        public CategoryModel Category { get; set; }

        public ICollection<DetailModel> Details { get; set; }

    }
}