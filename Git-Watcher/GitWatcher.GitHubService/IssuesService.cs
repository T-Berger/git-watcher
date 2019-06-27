using System.Collections.Generic;
using System.Threading.Tasks;
using Git_Watcher_Client.Dto;
using Git_Watcher_Client.GitHubRestServices.Interfaces;
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
//            var owner = _ApiConnection.GetRepoWithUserName<RepositoryDto>(ApiConnection.Repository(repositoryId));
            var repo = _ApiConnection.Get<RepositoryDto>(ApiConnection.Repository(repositoryId)).Result;
            return _ApiConnection.Get<IssueDto>(ApiConnection.Issue(repo.Owner.Login, repo.Name, number));
        }
        
        // <summary>
        /// Gets all open issues assigned to the authenticated user across all the authenticated user’s visible
        /// repositories including owned repositories, member repositories, and organization repositories.
        /// </summary>
        /// <remarks>
        /// Issues are sorted by the create date descending.
        /// http://developer.github.com/v3/issues/#list-issues
        /// </remarks>
        public Task<IReadOnlyList<IssueDto>> GetAllForCurrent()
        {
            return _ApiConnection.GetAll<IssueDto>(ApiConnection.Issues());
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
            return _ApiConnection.GetAll<IssueDto>(ApiConnection.Issues(owner, name));
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
//            ApiConnection.Repository()
//            string owner = _ApiConnection.Get<RepositoryDto>(ApiConnection.Repository(repositoryId)).Result.Owner.Name;

            var repo = _ApiConnection.Get<RepositoryDto>(ApiConnection.Repository(repositoryId)).Result;
            
            
            return _ApiConnection.GetAll<IssueDto>(ApiConnection.Issues(repo.Owner.Login, repo.Name));
        }
    }
}