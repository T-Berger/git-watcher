using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Git_Watcher.DataAccess.Repositories;
using Git_Watcher.Models;
using GitWatcher.ApiModels;
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
        private readonly Guid clientInitKey = new Guid("5A3DA496-4120-4169-8373-339EEBA02B64");


        public UserBackendController(ILogger<UserBackendController> logger, IUserRepo userRepo)
        {
            _logger = logger;
            _userRepo = userRepo;
        }

        [HttpPost]
        [Route("users")]
        public ActionResult CreateUser([FromBody]NewBackendUser user)
        {
            _logger.LogInformation("Hello there");
            var key = _userRepo.Save(new User { GitUserName = user.UserName});
            return CreatedAtAction(nameof(CreateUser), new { key = key });
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