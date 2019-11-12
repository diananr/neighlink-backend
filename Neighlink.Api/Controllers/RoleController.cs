using Microsoft.AspNetCore.Mvc;
using Neighlink.Api.Contracts;
using Neighlink.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neighlink.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private IRoleService roleService;

        public RoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        [HttpPost]
        public ActionResult<int> Post([FromBody] CreateRoleRequest request)
        {
            return roleService.SaveNewRole(request.Role, request.CondominiumId);
        }
    }
}
