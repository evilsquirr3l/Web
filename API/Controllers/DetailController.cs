using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Abstraction;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class DetailController : ControllerBase
    {
        private readonly IDetailService _detailService;

        public DetailController(IDetailService detailService)
        {
            _detailService = detailService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetailModel>>> GetAll()
        {
            return Ok(_detailService.GetAll());
        }

        [HttpGet("{dateTime:datetime}")]
        public async Task<ActionResult<IEnumerable<DetailModel>>> GetByDate(DateTime dateTime)
        {
            var detail = _detailService.FindByDate(dateTime);

            return Ok(detail);
        }

        [HttpGet("{detailName}")]
        public async Task<ActionResult<DetailModel>> GetByName(string detailName)
        {
            var detail = _detailService.FindByName(detailName);

            return Ok(detail);
        }

        [HttpGet("{templateId:int}")]
        public async Task<ActionResult<DetailModel>> GetByTemplateId(int templateId)
        {
            var detail = _detailService.FindByTemplateId(templateId);

            return Ok(detail);
        }

        [HttpDelete("{detailId}")]
        public async Task<ActionResult> DeleteById(int detailId)
        {
            await _detailService.DeleteById(detailId);

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Create(DetailModel detailModel)
        {
            await _detailService.Create(detailModel);

            return Ok(detailModel);
        }
    }
}