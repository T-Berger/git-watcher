using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Git_Watcher.DataAccess.Repositories;
using Git_Watcher.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Git_Watcher.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class UserBackendController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IUserRepo _userRepo;

        public UserBackendController(ILogger<UserBackendController> logger, IUserRepo userRepo)
        {
            _logger = logger;
            _userRepo = userRepo;
        }

        [HttpPost]
        [Route("createUser")]
        public ActionResult CreateUser(string name)
        {
            _logger.LogInformation("Hello there");
            if (name.Length > 39)
            {
                ModelState.AddModelError("UserError", "User name cannot be longer than 39 characters!");
                return BadRequest(ModelState);
            }
            if (_userRepo.Get(name) != null)
            {
                ModelState.AddModelError("UserError", $"User: {name} already exists!");
                return BadRequest(ModelState);
            }
            var u = new User { GitUserName = name };
            _userRepo.Save(u);
            return CreatedAtAction(nameof(CreateUser), new { key = u.ApiKey });
        }

        [HttpGet]
        [Route("getUser")]
        public ActionResult GetUser(Guid id)
        {
            var user = _userRepo.Get(id);
            if (user == null)
                return NotFound("User not found!");
            return Ok($"Username: {user.GitUserName}");
        }

        [HttpDelete]
        [Route("deleteUser")]
        public ActionResult DeleteUser(Guid id)
        {
            _userRepo.Delete(id);
            return Ok("User deleted");
        }
    }
}