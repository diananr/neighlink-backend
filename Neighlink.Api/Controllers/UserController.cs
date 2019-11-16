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
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(userService.GetAll());
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
                PhotoUrl = request.PhotoUrl
            };

            return Ok(userService.Save(user));
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
