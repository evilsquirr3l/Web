using BLL.Models;

namespace BLL.Interfaces
{
    public interface IRadiodetailService
    {
        ProductionModel GetProduction(DetailModel detail);
    }
}