using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Git_Watcher.Models;
using Git_Watcher.DataAccess.Repositories;
using Git_Watcher_Client.Models;
using Git_Watcher_Client.GitHubRestServices.Interfaces;
using Git_Watcher_Client.Dto;

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
        private readonly IGitHubRestService _githubService;

        public RepoApiController(ISubscriptionRepo subscriptionRepo ,IUserRepo userRepo, IGitRepo gitRepo, ILogger<RepoApiController> logger)
        {
            _subscriptionRepo = subscriptionRepo;
            _userRepo = userRepo;
            _gitRepo = gitRepo;
            _logger = logger;
            _githubService = new Git_Watcher_Client.GitHubRestService();
        }

        [HttpPost]
        [Route("subscriptions")]
        public ActionResult Subscribe([FromBody]Subscription sub)
        {
            _logger.LogInformation("Subscribe now");
            _subscriptionRepo.Save(sub);
            return CreatedAtAction(nameof(subscriptionsByID), new { subID = sub.Id });
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

        [HttpGet]
        [Route("issues/byUser/{userID}")]
        public ActionResult Issues(Guid userID)
        {
            List<Subscription> subscriptions = _subscriptionRepo.GetByUser(userID);

            if(subscriptions.Count == 0)
            {
                return BadRequest("You are not subscribed to any issues");
            }

            List<Issue> issues = new List<Issue>();

            subscriptions.ForEach((Subscription sub) =>
            {
                Guid repo = sub.RepoId;
                Task<IReadOnlyList<IssueDto>>  subsIssues = _githubService.Issue.GetAllForRepository(Convert.ToInt64(repo));
                IssueDto[] issueArr = subsIssues.Result.ToArray<IssueDto>();
                
                for(int i=0; i < issueArr.Count<IssueDto>(); i++)
                {
                    IssueDto dto = issueArr.ElementAt<IssueDto>(i);
                    issues.Add(new Issue(dto.User.ToString(), dto.Title, dto.CreatedAt.UtcDateTime, dto.Url.ToString(), false));
                }
            });

            if(issues.Count == 0)
            {
                return BadRequest("No Issues found for subscription");
            }

            return Ok(issues);
        }
    }
}