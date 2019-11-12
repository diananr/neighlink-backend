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
    public class UsersController : ControllerBase
    {
        private IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserInformation>> Get()
        {
            return userService.GetAllUserForAdministrator(2);
        }

        [HttpPost]
        public ActionResult<int> Post([FromBody] User user)
        {
            return userService.SaveNewUser(user);
        }

        [HttpPost]
        [Route("create-with-type")]
        public ActionResult<int> Post([FromBody] CreateUserRequest request)
        {
            return userService.SaveNewUser(request.User, request.RoleId);
        }

        [HttpPost]
        [Route("create-owner")]
        public ActionResult<int> Post([FromBody] CreateDefaultUserRequest request)
        {
            return userService.SaveNewDefaultCondoUser(request.User, request.CondominiumId);
        }
    }
}
