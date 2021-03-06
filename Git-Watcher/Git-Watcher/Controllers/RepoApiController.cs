﻿using System;
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
using GitWatcher.ApiModels;
using System.Text;

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

        /// <summary>
        /// start watching a repository
        /// </summary>
        /// <param name="sub">the subscription with the data</param>
        /// <returns>the subscription item</returns>
        [HttpPost]
        [Route("subscriptions")]
        public ActionResult Subscribe([FromBody]SubscriptionApi sub)
        {
            try
            {
                var user = _userRepo.Get(sub.ApiKey);
                var repo = _gitRepo.Get(sub.RepoId);
                var id = Guid.Empty;
                if (repo == null)
                {
                    id = _gitRepo.Save(new GitRepository { RepoId = sub.RepoId, Link = "" });
                }
                else
                {
                    id = repo.Id;
                }
                if (user == null)
                    return BadRequest("User not found!");
                var subId = _subscriptionRepo.Save(new Subscription { UserId = user.ApiKey, RepoId = id });
                return CreatedAtAction(nameof(Subscribe), new { res = subId.ToString() });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Get the subscription by the id
        /// </summary>
        /// <param name="subID">the id of the subscritption</param>
        /// <returns>the subscription item</returns>
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

        /// <summary>
        /// End a subscription to a repository
        /// </summary>
        /// <param name="subID">the subscription</param>
        /// <returns>the result of the delete action</returns>
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
        /// <summary>
        /// update a subscription
        /// </summary>
        /// <param name="sub">the new sbscription item</param>
        /// <param name="subID">the id of the old subscription</param>
        /// <returns>the result of the update</returns>
        [HttpPut]
        [Route("subscriptions/{subID}")]
        public ActionResult Update([FromBody]SubscriptionApi sub, Guid subID)
        {
            if (_subscriptionRepo.Get(subID) == null)
            {
                ModelState.AddModelError("SubscriptionError", $"SubscriptionID: {subID} not found");
                return NotFound(ModelState);
            }
            _subscriptionRepo.Update(new Subscription { Id = subID, RepoId = new Guid(sub.RepoId), UserId = sub.ApiKey });
            return CreatedAtAction(nameof(Subscribe), new { res = "Successfully updated!" });
        }

        /// <summary>
        /// get all subscriptions of an user
        /// </summary>
        /// <param name="userID">the id of the user</param>
        /// <returns>list of all subscription from the user</returns>
        [HttpGet]
        [Route("subscriptions/byUser/{apiKey}")]
        public ActionResult Subscriptions(Guid apiKey)
        {
            var user = _userRepo.Get(apiKey);
            var subs = _subscriptionRepo.GetByUser(user.Id);
            var watchedRepos = new List<string>();
            subs.ForEach(x => watchedRepos.Add(_gitRepo.Get(x.RepoId).RepoId));
            var res = watchedRepos.Aggregate(new StringBuilder(), (sb, a) => sb.AppendLine(String.Join(";", a)), sb => sb.ToString());
            return Ok(res);
            return Ok(_subscriptionRepo.GetByUser(userID).Aggregate(new StringBuilder(), (sb, a) => sb.AppendLine(String.Join(";", a)), sb => sb.ToString()));
        }

        /// <summary>
        /// get the issues for an user of the subscribed repositories
        /// </summary>
        /// <param name="userID">the id of the user</param>
        /// <returns>list of all issues</returns>
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