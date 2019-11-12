using Microsoft.AspNetCore.Mvc;
using Neighlink.Api.Contracts;
using Neighlink.Entity;
using Neighlink.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neighlink.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private IBuildingService buildingService;

        public BuildingController(IBuildingService buildingService)
        {
            this.buildingService = buildingService;
        }

        [HttpGet]
        [Route("get-all-for-user")]
        public ActionResult<IEnumerable<Building>> GetBuildingsForUser(int userId)
        {
            return buildingService.GetAllBuildingsForUser(userId);
        }

        [HttpGet]
        [Route("get-building-at-condo")]
        public ActionResult<IEnumerable<Building>> GetBuildingsForCondo(int condoId)
        {
            return buildingService.GetAllBuildingsAtCondo(condoId);
        }

        [HttpPost]
        public ActionResult<int> Post([FromBody] CreateBuildingRequest request)
        {
            return buildingService.SaveBuildingToCondominium(request.Building,request.CondominiumId);
        }
    }
}
