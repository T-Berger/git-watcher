using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Git_Watcher.DataAccess.Repositories;
using Git_Watcher.Models;
using Microsoft.AspNetCore.Mvc;

namespace Git_Watcher.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class AppBackendController : ControllerBase
    {
        private readonly IUserRepo _userRepo;

        public AppBackendController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpPost]
        [Route("createUser")]
        public ActionResult CreateUser(string name)
        {
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
