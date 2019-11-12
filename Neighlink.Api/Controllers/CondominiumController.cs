using Microsoft.AspNetCore.Mvc;
using Neighlink.Entity;
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


        [HttpPost]
        public ActionResult<int> Post([FromBody] Condominium condo)
        {
            return userService.SaveNewUser(user);
        }
    }
}
