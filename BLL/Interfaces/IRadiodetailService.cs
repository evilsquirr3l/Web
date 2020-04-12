using BLL.Models;

namespace BLL.Interfaces
{
    public interface IProductionService
    {
        ProductionModel GetProduction(DetailModel detail);
    }
}