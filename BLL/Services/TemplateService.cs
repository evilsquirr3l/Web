using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Interfaces;

namespace BLL.Services
{
    public class TemplateService : ITemplateService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unit;

        public TemplateService(IMapper mapper, IUnitOfWork unit)
        {
            _mapper = mapper;
            _unit = unit;
        }

        public IEnumerable<DetailTemplateModel> GetAll()
        {
            var detailTemplates = _unit.DetailTemplateRepository.GetAll();

            return _mapper.Map<IEnumerable<DetailTemplateModel>>(detailTemplates);
        }

        public DetailTemplateModel FindByComponentBaseId(int id)
        {
            var detailTemplate = _unit.DetailTemplateRepository.GetAll().Where(d => d.OutputDetailId.Equals(id));

            return _mapper.Map<DetailTemplateModel>(detailTemplate);
        }
    }
}