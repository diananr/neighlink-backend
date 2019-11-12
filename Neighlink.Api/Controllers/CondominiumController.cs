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
    public class CondominiumController : ControllerBase
    {
        private ICondominiumService condominiumService;

        public CondominiumController(ICondominiumService condominiumService)
        {
            this.condominiumService = condominiumService;
        }

        [HttpPost]
        public ActionResult<int> Post([FromBody] CreateCondominiumRequest request)
        {
            return condominiumService.SaveNewCondominium(request.Condominium, request.PlanId);
        }
    }
}
