using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using Data.Abstraction;

namespace BLL.Services
{
    public class ProductionService : IProductionService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unit;

        public ProductionService(IMapper mapper, IUnitOfWork unit)
        {
            _mapper = mapper;
            _unit = unit;
        }

        public IEnumerable<ProductionModel> GetAll()
        {
            var productions = _unit.ProductionRepository.GetAll();

            return _mapper.Map<IEnumerable<ProductionModel>>(productions);
        }

        public ProductionModel GetProduction(int detailId)
        {
            var productionWithDetail =
                _unit.DetailTemplateRepository.GetAll().Where(t => t.OutputDetailId.Equals(detailId));

            return _mapper.Map<ProductionModel>(productionWithDetail);
        }
    }
}