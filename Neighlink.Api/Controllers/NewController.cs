using Microsoft.AspNetCore.Mvc;
using Neighlink.Entity;
using Neighlink.Service;
using System.Collections.Generic;

namespace Neighlink.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewController : ControllerBase
    {
        private INewService newService;
    public NewController(INewService newService)
    {
        this.newService = newService;
    }

     [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                newService.GetAll()
            );
        }

        [HttpPost]
        public ActionResult Post([FromBody] News news)
        {
            return Ok(
                newService.Save(news)
            );
        }

        [HttpPut]
        public ActionResult Put([FromBody] News news)
        {
            return Ok(
                newService.Update(news)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                newService.Delete(id)
            );
        }

        [HttpGet("by-condominium/{condominiumId}")]
        public ActionResult<IEnumerable<News>> GetNews(int condominiumId)
        {
            return Ok(newService.GetNewsByCondominium(condominiumId));
        }

        
        
    }
}