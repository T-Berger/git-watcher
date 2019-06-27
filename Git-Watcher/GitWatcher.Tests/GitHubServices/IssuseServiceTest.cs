using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Git_Watcher_Client;
using Git_Watcher_Client.Dto;
using Git_Watcher_Client.GitHubRestServices.Interfaces;
using Git_Watcher_Client.GitHubRestServices;
using Git_Watcher_Client.Models;
using NSubstitute;
using Xunit;
using GitWatcher.ApiModels;

namespace GitWatcher.Tests.GitHubServices
{
    public class IssuseServiceTest
    {

        private readonly GitHubRestService _gitHubRestService;
        public IssuseServiceTest()
        {
            _gitHubRestService = new GitHubRestService();
            
        }
        #region UnitTest

        #endregion

        #region IntegrationTest

        #region GetMethode
        public class GetMethode
        {
            [Fact]
            public async Task CanGetIssueWithRepositoryId()
            {
                var gitHubRestService = new GitHubRestService();
                var issue = await gitHubRestService.Issue.Get(3622414, 1347);
                    
                Assert.Equal("https://api.github.com/repos/octocat/Hello-World", issue.RepositoryUrl);
                Assert.Equal("https://api.github.com/repos/octocat/Hello-World/issues/1347",issue.Url);
                Assert.Equal("I'm having a problem with this.",issue.Body);                
                Assert.Equal("Found a bug",issue.Title);
            }
        }

        #endregion

        #region GetAll

        public class TheGetAllPublicMethod
        {
            [Fact]
            public async Task ReturnsIssuesForARepository()
            {
                var gitHubRestService = new GitHubRestService();
                var issues = await gitHubRestService.Issue.GetAllForRepository("octocat", "Hello-World");

                Assert.Equal(5, issues.Count);
            }
            
            [Fact]
            public async Task ReturnsIssuesForARepositoryWithRepositoryId()
            {
   
                var gitHubRestService = new GitHubRestService();
                var issues = await gitHubRestService.Issue.GetAllForRepository(1296269);

                Assert.Equal(30, issues.Count);
            }
        }

        #endregion

        #endregion
    }
}