using System.Collections.Generic;
using System.Threading.Tasks;
using Git_Watcher_Client.Dto;
using Git_Watcher_Client.GitHubRestServices.Interfaces;
using GitWatcher.GitHubService.Helpers;
using IApiConnection = Git_Watcher_Client.GitHubRestServices.Interfaces.IApiConnection;

namespace Git_Watcher_Client.GitHubRestServices
{
    public class IssuesService: ApiConnection, IIssuesService
    {
        private ApiConnection _ApiConnection;
        public IssuesService(ApiConnection apiConnection)
        {
            _ApiConnection = apiConnection;
        }

        /// <summary>
        /// Gets a single Issue by number.
        /// </summary>
        /// <remarks>
        /// http://developer.github.com/v3/issues/#get-a-single-issue
        /// </remarks>
        /// <param name="repositoryId">The Id of the repository</param>
        /// <param name="number">The issue number</param>
        public Task<IssueDto> Get(long repositoryId, int number)
        {
            var repo = _ApiConnection.Get<RepositoryDto>(UriHelper.Repository(repositoryId)).Result;
            return _ApiConnection.Get<IssueDto>(UriHelper.Issue(repo.Owner.Login, repo.Name, number));
        }
        
        /// <summary>
        /// Gets all open issues assigned to the authenticated user across all the authenticated user’s visible
        /// repositories including owned repositories, member repositories, and organization repositories.
        /// </summary>
        /// <remarks>
        /// Issues are sorted by the create date descending.
        /// http://developer.github.com/v3/issues/#list-issues
        /// </remarks>
        public Task<IReadOnlyList<IssueDto>> GetAllForCurrent()
        {
            return _ApiConnection.GetAll<IssueDto>(UriHelper.Issues());
        }

        /// <summary>
        /// Gets all open issues assigned to the authenticated user for the repository.
        /// </summary>
        /// <remarks>
        /// http://developer.github.com/v3/issues/#list-issues-for-a-repository
        /// </remarks>
        /// <param name="owner">The owner of the repository</param>
        /// <param name="name">The name of the repository</param>
        public Task<IReadOnlyList<IssueDto>> GetAllForRepository(string owner, string name)
        {
            return _ApiConnection.GetAll<IssueDto>(UriHelper.Issues(owner, name));
        }

        /// <summary>
        /// Gets all open issues assigned to the authenticated user for the repository.
        /// </summary>
        /// <remarks>
        /// http://developer.github.com/v3/issues/#list-issues-for-a-repository
        /// </remarks>
        /// <param name="repositoryId">The Id of the repository</param>
        public Task<IReadOnlyList<IssueDto>> GetAllForRepository(long repositoryId)
        {
            var repo = _ApiConnection.Get<RepositoryDto>(UriHelper.Repository(repositoryId)).Result;
            return _ApiConnection.GetAll<IssueDto>(UriHelper.Issues(repo.Owner.Login, repo.Name));
        }
    }
}