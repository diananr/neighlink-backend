using Microsoft.AspNetCore.Mvc;
using Neighlink.Entity;
using Neighlink.Service;

namespace Neighlink.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CondominiumController:ControllerBase
    {
    private ICondominiumService condominiumService;

    public CondominiumController(ICondominiumService condominiumService)
    {
        this.condominiumService = condominiumService;
    }

    [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                condominiumService.GetAll()
            );
        }

        [HttpPost]
        public ActionResult Post([FromBody] Condominium condominium)
        {
            return Ok(
                condominiumService.Save(condominium)
            );
        }

        [HttpPut]
        public ActionResult Put([FromBody] Condominium condominium)
        {
            return Ok(
                condominiumService.Update(condominium)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                condominiumService.Delete(id)
            );
        }
        
    }
}