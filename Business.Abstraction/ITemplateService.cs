using System.Collections.Generic;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface ITemplateService
    {
        IEnumerable<DetailTemplateModel> GetAll();

        DetailTemplateModel FindByComponentBaseId(int id);
    }
}