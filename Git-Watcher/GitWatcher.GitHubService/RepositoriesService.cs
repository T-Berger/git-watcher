using System.Collections.Generic;
using System.Threading.Tasks;
using Git_Watcher_Client.Dto;
using Git_Watcher_Client.GitHubRestServices.Interfaces;
using GitWatcher.ApiModels;
using GitWatcher.GitHubService.Helpers;
using IApiConnection = Git_Watcher_Client.GitHubRestServices.Interfaces.IApiConnection;


namespace Git_Watcher_Client.GitHubRestServices
{
    public class RepositoriesService: ApiConnection, IRepositoriesService
    {
        private ApiConnection _ApiConnection;
        
        public RepositoriesService(ApiConnection apiConnection)
        {
            _ApiConnection = apiConnection;
        }
        
        /// <summary>
        /// Gets the specified repository.
        /// </summary>
        /// <remarks>
        /// See the <a href="http://developer.github.com/v3/repos/#get">API documentation</a> for more information.
        /// </remarks>
        /// <param name="owner">The owner of the repository</param>
        /// <param name="name">The name of the repository</param>  
        public Task<RepositoryDto> Get(string owner, string name)
        {
            return _ApiConnection.Get<RepositoryDto>(UriHelper.Repository(owner, name));
        }

        /// <summary>
        /// Gets the specified repository.
        /// </summary>
        /// <remarks>
        /// See the <a href="http://developer.github.com/v3/repos/#get">API documentation</a> for more information.
        /// </remarks>
        public Task<RepositoryDto> Get(long repositoryId)
        {
            return _ApiConnection.Get<RepositoryDto>(UriHelper.Repository(repositoryId));
        }
        
        /// <summary>
        /// Gets all public repositories.
        /// </summary>
        /// <remarks>
        /// See the <a href="https://developer.github.com/v3/repos/#list-all-public-repositories">API documentation</a> for more information.
        /// The default page size on GitHub.com is 30.
        /// </remarks>
        public Task<IReadOnlyList<RepositoryDto>> GetAllPublic()
        {
            return _ApiConnection.GetAll<RepositoryDto>(UriHelper.AllPublicRepositories());
        }
    }
}