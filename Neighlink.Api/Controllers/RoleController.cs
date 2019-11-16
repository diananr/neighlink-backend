using Microsoft.AspNetCore.Mvc;
using Neighlink.Entity;
using Neighlink.Service;

namespace Neighlink.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController:ControllerBase
    {
        private IRoleService roleService;
        public RoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }
    
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                roleService.GetAll()
            );
        }

        [HttpPost]
        public ActionResult Post([FromBody] Role role)
        {
            return Ok(
                roleService.Save(role)
            );
        }

        [HttpPut]
        public ActionResult Put([FromBody] Role role)
        {
            return Ok(
                roleService.Update(role)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                roleService.Delete(id)
            );
        }
    }
}