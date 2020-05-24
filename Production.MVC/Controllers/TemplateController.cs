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
    public class TemplateController : ControllerBase
    {
        private readonly ITemplateService _templateService;

        public TemplateController(ITemplateService templateService)
        {
            _templateService = templateService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetailTemplateModel>>> GetAll()
        {
            return Ok(_templateService.GetAll());
        }

        [HttpGet("{componentBaseId}")]
        public async Task<ActionResult<DetailTemplateModel>> ComponentBaseId(int id)
        {
            var detailTemplate = _templateService.FindByComponentBaseId(id);

            return Ok(detailTemplate);
        }
    }
}