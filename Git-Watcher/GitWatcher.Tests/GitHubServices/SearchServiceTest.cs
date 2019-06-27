using System.Threading.Tasks;
using Git_Watcher_Client;
using Git_Watcher_Client.Dto;
using Git_Watcher_Client.GitHubRestServices.Helpers;
using Xunit;

namespace GitWatcher.Tests.GitHubServices
{
    public class SearchServiceTest
    {
        #region IntegrationTest

        #region GetMethode
        public class GetMethode
        {
            [Fact]
            public async Task GetSearchResponseWithRepositoryName()
            {                
                var gitHubRestService = new GitHubRestService();
                var repository = await gitHubRestService.Search.SearchRepo("Tour of Heroes");
            
                Assert.IsType<SearchRepositoryResult>(repository);
                Assert.True(repository.TotalCount > 2);
            }
            
        }
        #endregion
        #endregion
    }
}