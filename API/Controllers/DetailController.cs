using System;
using System.Collections.Generic;
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
        public ActionResult<IEnumerable<DetailModel>> GetAll()
        {
            return Ok(_detailService.GetAll());
        }

        [HttpGet("{date}")]
        public ActionResult<DetailModel> GetDetailByDate(DateTime dateTime)
        {
            var detail = _detailService.FindByDate(dateTime);

            return Ok(detail);
        }

        [HttpGet("{name}")]
        public ActionResult<DetailModel> GetDetailByName(string name)
        {
            var detail = _detailService.FindByName(name);

            return Ok(detail);
        }

        [HttpGet("{templateId}")]
        public ActionResult<DetailModel> GetDetailByName(int id)
        {
            var detail = _detailService.FindByTemplateId(id);

            return Ok(detail);
        }
    }
}