using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Neighlink.Entity;
using Neighlink.Service;

namespace Neighlink.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionController:ControllerBase
    {
     private IOptionService optionService;
    public OptionController(IOptionService optionService)
    {
        this.optionService = optionService;
    }

    [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                optionService.GetAll()
            );
        }

    [HttpPost]
        public ActionResult Post([FromBody] Option option)
        {
            return Ok(
                optionService.Save(option)
            );
        }

    [HttpPut]
        public ActionResult Put([FromBody] Option option)
        {
            return Ok(
                optionService.Update(option)
            );
        }

     [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                optionService.Delete(id)
            );
        }   

        [HttpGet("by-condominium/{condominiumId}")]
        public ActionResult<IEnumerable<Option>> GetNews(int condominiumId)
        {
            return Ok(optionService.GetOptionByPoll(condominiumId));
        }
    }
}