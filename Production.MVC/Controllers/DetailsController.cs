using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Abstraction;
using Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Production.MVC.Controllers
{
    public class DetailsController : Controller
    {
        private readonly IDetailService _detailService;

        public DetailsController(IDetailService detailService)
        {
            _detailService = detailService;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetailModel>>> GetAll()
        {
            return View(_detailService.GetAll());
        }

        [HttpGet("{dateTime:datetime}")]
        public async Task<ActionResult<IEnumerable<DetailModel>>> GetByDate(DateTime dateTime)
        {
            var detail = _detailService.FindByDate(dateTime);

            return View(detail);
        }

        [HttpGet("{detailName}")]
        public async Task<ActionResult<DetailModel>> GetByName(string detailName)
        {
            var detail = _detailService.FindByName(detailName);

            return View(detail);
        }

        [HttpGet("{templateId:int}")]
        public async Task<ActionResult<DetailModel>> GetByTemplateId(int templateId)
        {
            var detail = await _detailService.FindByTemplateId(templateId);

            return View(detail);
        }

        [HttpDelete("{detailId}")]
        public async Task<ActionResult> DeleteById(int detailId)
        {
            await _detailService.DeleteById(detailId);

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(DetailModel detailModel)
        {
            await _detailService.Create(detailModel);

            return View(detailModel);
        }

        [HttpPut]
        public async Task<ActionResult> Update(DetailModel detailModel)
        {
            await _detailService.UpdateAsync(detailModel);

            return View(detailModel);
        }
    }
}