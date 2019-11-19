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
    public class UserController : ControllerBase
    {
        private IUserService userService;
        private IBuildingService buildingService;

        public UserController(IUserService userService, IBuildingService buildingService)
        {
            this.userService = userService;
            this.buildingService = buildingService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]LoginRequest loginRequest)
        {
            var user = userService.Authenticate(loginRequest.Email, loginRequest.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [HttpPost]
        public ActionResult Post([FromBody] RegisterUserRequest request)
        {
            byte[] salt = CustomLoginProviderUtils.GenerateSalt();

            User user = new User()
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Salt = salt,
                Gender = request.Gender,
                PhoneNumber = request.PhoneNumber,
                SaltedAndHashedPassword = CustomLoginProviderUtils.Hash(request.Password, salt),
                PhotoUrl = request.PhotoUrl,
                Role = request.Role,
            };

            bool saveUser = false;

            if (request.Role == Entity.Entity.Role.Administrator) 
            {
                saveUser = userService.RegisterAdmin(user, request.CondominiumId);
            }

            if (request.Role == Entity.Entity.Role.Owner)
            {
                saveUser = userService.RegisterOwner(user, request.BuildingId);
            }

            return Ok(saveUser);
        }

        [HttpGet("by-condominium/{condominiumId}")]
        public ActionResult<IEnumerable<User>> GetUsers(int condominiumId)
        {
            return Ok(userService.GetUsersByCondominium(condominiumId));
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            return Ok(userService.Get(id));
        }

        [HttpPut]
        public ActionResult Put([FromBody] User user)
        {
            return Ok(userService.Update(user));
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(userService.Delete(id));
        }
    }
}
