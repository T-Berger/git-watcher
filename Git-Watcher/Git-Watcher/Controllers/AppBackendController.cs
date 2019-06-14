using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Git_Watcher.DataAccess.Repositories;
using Git_Watcher.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Git_Watcher.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    [Produces("application/json")]
    public class AppBackendController : ControllerBase
    {
        private readonly IUserRepo _userRepo;
        private readonly ILogger _logger;

        public AppBackendController(IUserRepo userRepo, ILogger logger)
        {
            _userRepo = userRepo;
            _logger = logger;
        }

        /// <summary>
        ///     Create a new user
        /// </summary>
        /// <param name="name">the name of the user</param>
        /// <returns>the created user</returns>
        [HttpPost]
        [Route("createUser")]
        public ActionResult CreateUser(string name)
        {
            _logger.Information("Hello there");
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
    }
}
