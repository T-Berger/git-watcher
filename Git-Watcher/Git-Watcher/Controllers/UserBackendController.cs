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
        [Route("createUser")]
        public ActionResult CreateUser(NewBackendUser newUser)
        {
            try
            {
                if (newUser.Key != clientInitKey)
                {
                    ModelState.AddModelError("ClientError", "Clientkey not recognized!");
                    return BadRequest(ModelState);
                }
                if (newUser.UserName.Length > 39)
                {
                    ModelState.AddModelError("UserError", "User name cannot be longer than 39 characters!");
                    return BadRequest(ModelState);
                }
                if (_userRepo.Get(newUser.UserName) != null)
                {
                    ModelState.AddModelError("UserError", $"User: {newUser.UserName} already exists!");
                    return BadRequest(ModelState);
                }
                var u = new User { GitUserName = newUser.UserName };

                _userRepo.Save(u);
                return CreatedAtAction(nameof(CreateUser), new { key = u.ApiKey });

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e);
            }
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