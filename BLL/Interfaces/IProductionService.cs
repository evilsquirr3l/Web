using System.Collections.Generic;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface IProductionService
    {
        IEnumerable<ProductionModel> GetAll();
        
        ProductionModel GetProduction(DetailModel detail);
    }
}