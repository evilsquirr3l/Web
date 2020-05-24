using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Abstraction;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace Production.MVC.Controllers
{
    [Produces("application/json")]
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
        public async Task<ActionResult<IEnumerable<ProductionModel>>> GetAll()
        {
            return Ok(_productionService.GetAll());
        }

        [HttpGet("{detailId}")]
        public async Task<ActionResult<DetailModel>> GetDetailByDate(int detailId)
        {
            var production = _productionService.GetProduction(detailId);

            return Ok(production);
        }
    }
}