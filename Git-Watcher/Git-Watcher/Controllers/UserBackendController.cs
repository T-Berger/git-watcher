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
        [Route("users")]
        public ActionResult CreateUser([FromBody]User user)
        {
            _logger.LogInformation("Hello there");
            _userRepo.Save(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id });
        }

        [HttpGet]
        [Route("users/{id}")]
        public ActionResult GetUser(Guid id)
        {
            var user = _userRepo.Get(id);
            if (user == null)
                return NotFound("User not found!");
            return Ok($"Username: {user.GitUserName}");
        }

        [HttpDelete]
        [Route("users/{id}")]
        public ActionResult DeleteUser(Guid id)
        {
            _userRepo.Delete(id);
            return Ok("User deleted");
        }
    }
}