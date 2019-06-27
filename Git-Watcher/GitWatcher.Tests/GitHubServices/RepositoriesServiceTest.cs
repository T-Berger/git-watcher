

using System.Threading.Tasks;
using Git_Watcher_Client;
using Git_Watcher_Client.Dto;
using Git_Watcher_Client.GitHubRestServices;
using Xunit;

namespace GitWatcher.Tests.GitHubServices
{
    public class RepositoriesServiceTest
    {
        public class TheGetMethod
        {
            #region UnitTest



            #endregion
            
            #region IntegrationTest

                #region GetMethode
                public class GetMethode
                {
                    [Fact]
                    public async Task GetSpecifiedRepositoryWithOwnerAndNameTestCloneUrl()
                    {                
                        var gitHubRestService = new GitHubRestService();
                        var repository = await gitHubRestService.Repository.Get("haacked", "seegit");
            
                        Assert.IsType<RepositoryDto>(repository);
                        Assert.Equal("https://github.com/haacked/SeeGit.git", repository.CloneUrl);
                        Assert.False(repository.Private);
                    }

                    [Fact]
                    public async Task ReturnsSpecifiedRepositoryWithRepositoryId()
                    {
                        var gitHubRestService = new GitHubRestService();
                        var repository = await gitHubRestService.Repository.Get(3622414);

                        Assert.Equal("https://github.com/haacked/SeeGit.git", repository.CloneUrl);
                        Assert.Equal("SeeGit", repository.Name);
                        Assert.Equal("https://api.github.com/repos/haacked/SeeGit",repository.Url);
                        Assert.False(repository.Private);
                    }
                    
                }
                #endregion

                #region GetAll

                public class TheGetAllPublicMethod
                {
                    [Fact]
                    public async Task ReturnsAllPublicRepositories()
                    {
                        
                        var gitHubRestService = new GitHubRestService();
                        var repositories = await gitHubRestService.Repository.GetAllPublic();
                        Assert.True(repositories.Count > 80);
                    }
                }


                #endregion

            #endregion
        }
    }
}