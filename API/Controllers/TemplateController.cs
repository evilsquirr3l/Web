using System.Collections.Generic;
using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
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
        public ActionResult<IEnumerable<DetailTemplateModel>> GetAll()
        {
            return Ok(_templateService.GetAll());
        }

        [HttpGet("{componentBaseId}")]
        public ActionResult<DetailTemplateModel> ComponentBaseId(int id)
        {
            var detailTemplate = _templateService.FindByComponentBaseId(id);

            return Ok(detailTemplate);
        }
    }
}