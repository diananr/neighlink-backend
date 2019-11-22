using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Neighlink.Entity.Entity;
using Neighlink.Service;

namespace Neighlink.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollController:ControllerBase
    {

    private IPollService pollService;
    public PollController(IPollService pollService)
    {
        this.pollService = pollService;
    }

    [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                pollService.GetAll()
            );
        }

     [HttpPost]
        public ActionResult Post([FromBody] Poll poll)
        {
            return Ok(
                pollService.Save(poll)
            );
        }

    [HttpPut]
        public ActionResult Put([FromBody] Poll poll)
        {
            return Ok(
                pollService.Update(poll)
            );
        }

    [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                pollService.Delete(id)
            );
        }

        [HttpGet("by-condominium/{condominiumId}")]
        public ActionResult<IEnumerable<Poll>> GetNews(int condominiumId)
        {
            return Ok(pollService.GetNewsByCondominium(condominiumId));
        }

    }
}