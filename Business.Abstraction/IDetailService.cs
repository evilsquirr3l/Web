using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;

namespace Business.Abstraction
{
    public interface IDetailService
    {
        IEnumerable<DetailModel> GetAll();

        IEnumerable<DetailModel> FindByName(string name);

        IEnumerable<DetailModel> FindByDate(DateTime dateTime);

        Task<DetailModel> FindByTemplateId(int templateId);

        Task DeleteById(int detailId);

        Task Create(DetailModel detailModel);
    }
}