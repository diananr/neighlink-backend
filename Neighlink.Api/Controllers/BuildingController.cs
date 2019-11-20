using Microsoft.AspNetCore.Mvc;
using Neighlink.Entity;
using Neighlink.Service;
using System.Collections.Generic;

namespace Neighlink.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController:ControllerBase
    {
        private IBuildingService buildingService;

        public BuildingController(IBuildingService buildingService)
        {
            this.buildingService = buildingService;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Building building)
        {
            return Ok(
                buildingService.Save(building)
            );
        }

        [HttpGet("by-condominium/{condominiumId}")]
        public ActionResult<IEnumerable<Building>> GetBuildings(int condominiumId)
        {
            return Ok(buildingService.GetBuildingsByCondominium(condominiumId));
        }

        [HttpGet("byId/{id}")]
        public ActionResult<Building> Get(int id)
        {
            return Ok(buildingService.Get(id));
        }

        [HttpPut]
        public ActionResult Put([FromBody] Building building)
        {
            return Ok(buildingService.Update(building));
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(buildingService.Delete(id));
        }
    }
}