using System.Collections.Generic;
using Business.Models;

namespace Business.Abstraction
{
    public interface IProductionService
    {
        IEnumerable<ProductionModel> GetAll();

        ProductionModel GetProduction(int detailId);
    }
}