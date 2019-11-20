using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Neighlink.Api.Contracts;
using Neighlink.Entity;
using Neighlink.Repository.Utilities;
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

        [HttpGet("all")]
        public ActionResult<IEnumerable<Condominium>> GetCondominiums()
        {
            return Ok(condominiumService.GetAll());
        }
    }
}
