using BLL.Models;

namespace BLL.Interfaces
{
    public interface ITemplateService
    {
        DetailTemplateModel FindByComponentBaseId(int id);
    }
}