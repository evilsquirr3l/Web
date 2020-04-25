using System.Collections.Generic;
using Business.Models;

namespace Business.Abstraction
{
    public interface ITemplateService
    {
        IEnumerable<DetailTemplateModel> GetAll();

        DetailTemplateModel FindByComponentBaseId(int id);
    }
}