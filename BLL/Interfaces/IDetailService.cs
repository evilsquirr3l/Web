using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface IDetailService
    {
        IEnumerable<DetailModel> GetAll();

        IEnumerable<DetailModel> FindByName(string name);

        IEnumerable<DetailModel> FindByData(DateTime dateTime);

        Task<DetailModel> FindByTemplateId(int templateId);
    }
}