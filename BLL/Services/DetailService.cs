using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using Data.Abstraction;

namespace BLL.Services
{
    public class DetailService : IDetailService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unit;

        public DetailService(IMapper mapper, IUnitOfWork unit)
        {
            _mapper = mapper;
            _unit = unit;
        }

        public IEnumerable<DetailModel> GetAll()
        {
            var details = _unit.DetailRepository.GetAll();

            return _mapper.Map<IEnumerable<DetailModel>>(details);
        }

        public IEnumerable<DetailModel> FindByName(string name)
        {
            var detailsWithName = _unit.DetailRepository.GetAll().Where(d => d.Name.Equals(name));

            return _mapper.Map<IEnumerable<DetailModel>>(detailsWithName);
        }

        public IEnumerable<DetailModel> FindByDate(DateTime dateTime)
        {
            var detailWithDate = _unit.DetailRepository.GetAll().Where(d => d.CreationTime.Date.Equals(dateTime.Date));

            return _mapper.Map<IEnumerable<DetailModel>>(detailWithDate);
        }

        public async Task<DetailModel> FindByTemplateId(int templateId)
        {
            var detail = await _unit.DetailTemplateRepository.GetById(templateId);

            return _mapper.Map<DetailModel>(detail);
        }
    }
}