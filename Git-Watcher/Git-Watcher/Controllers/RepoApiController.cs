using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Git_Watcher.Models;
using Git_Watcher.DataAccess.Repositories;
using GitWatcher.ApiModels;

namespace Git_Watcher.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class RepoApiController : ControllerBase
    {
        private readonly ISubscriptionRepo _subscriptionRepo;
        private readonly IUserRepo _userRepo;
        private readonly ILogger _logger;
        private readonly IGitRepo _gitRepo;

        public RepoApiController(ISubscriptionRepo subscriptionRepo ,IUserRepo userRepo, IGitRepo gitRepo, ILogger<RepoApiController> logger)
        {
            _subscriptionRepo = subscriptionRepo;
            _userRepo = userRepo;
            _gitRepo = gitRepo;
            _logger = logger;
        }

        [HttpPost]
        [Route("subscriptions")]
        public ActionResult Subscribe([FromBody]SubscriptionApi sub)
        {
            _logger.LogInformation("Subscribe now");
            var user = _userRepo.Get(sub.ApiKey);
            var repo = _gitRepo.Get(sub.RepoId);
            var id = Guid.Empty;
            if(repo == null)
            {
                id = _gitRepo.Save(new GitRepository { RepoId = sub.RepoId, Link = "" });
            }
            else
            {
                id = repo.Id;
            }
            _subscriptionRepo.Save(new Subscription { UserId = user.Id, RepoId = id});
            return CreatedAtAction(nameof(Subscribe), new { res = "Successfully subscribed!"});
        }

        [HttpGet]
        [Route("subscriptions/{subID}")]
        public ActionResult subscriptionsByID(Guid subID)
        {
            var subscription = _subscriptionRepo.Get(subID);
            if (subscription == null)
            {
                ModelState.AddModelError("UserError", $"SubscriptionID: {subID} not found");
                return NotFound(ModelState);
            }

            return Ok(subscription);
        }


        [HttpDelete]
        [Route("subscriptions/{subID}")]
        public ActionResult Unsubscribe(Guid subID)
        {
            if (_subscriptionRepo.Get(subID) == null)
            {
                ModelState.AddModelError("SubscriptionError", $"SubscriptionID: {subID} not found");
                return NotFound(ModelState);
            }
            _subscriptionRepo.Delete(subID);
            return Ok();
        }

        [HttpGet]
        [Route("subscriptions/byUser/{userID}")]
        public ActionResult Subscriptions(Guid userID)
        {
            return Ok(_subscriptionRepo.GetByUser(userID).ToArray());
        }

        [HttpGet]
        [Route("news")]
        public ActionResult News()
        {
            return Ok("not implemented yet");
        }
    }
}