using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionController : ControllerBase
    {
        private readonly IProductionService _productionService;

        public ProductionController(IProductionService productionService)
        {
            _productionService = productionService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductionModel>> GetAll()
        {
            return Ok(_productionService.GetAll());
        }
        
        [HttpGet("{detailId}")]
        public ActionResult<DetailModel> GetDetailByDate(int detailId)
        {
            var production = _productionService.GetProduction(detailId);

            return Ok(production);
        }
    }
}