using Microsoft.AspNetCore.Mvc;
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
    public class PlanController : ControllerBase
    {
        private IPlanService planService;

        public PlanController(IPlanService planService)
        {
            this.planService = planService;
        }

        [HttpPost]
        public ActionResult<int> Post([FromBody] Plan plan)
        {
            return planService.AddNewPlan(plan);
        }
    }
}
