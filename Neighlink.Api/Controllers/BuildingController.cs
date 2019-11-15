using Microsoft.AspNetCore.Mvc;
using Neighlink.Entity;
using Neighlink.Service;

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

     [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                buildingService.GetAll()
            );
        }

        [HttpPost]
        public ActionResult Post([FromBody] Building building)
        {
            return Ok(
                buildingService.Save(building)
            );
        }

        [HttpPut]
        public ActionResult Put([FromBody] Building building)
        {
            return Ok(
                buildingService.Update(building)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                buildingService.Delete(id)
            );
        }



    }
}