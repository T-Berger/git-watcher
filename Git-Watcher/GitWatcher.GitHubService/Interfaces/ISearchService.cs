using System.Threading.Tasks;
using Git_Watcher_Client.GitHubRestServices.Helpers;

namespace Git_Watcher_Client.GitHubRestServices.Interfaces
{
    public interface ISearchService
    {
        /// <summary>
        /// search repos
        /// http://developer.github.com/v3/search/#search-repositories
        /// </summary>
        /// <param name="repoName">A Substring from RepoName</param>
        /// <returns>List of repos</returns>
        Task<SearchRepositoryResult> SearchRepo(string repoName);

//        /// <summary>
//        /// Queue an indexing job for all the issues in a repository (must be Site Admin user).
//        /// </summary>
//        /// <remarks>
//        /// https://developer.github.com/v3/enterprise/search_indexing/#queue-an-indexing-job
//        /// </remarks>
//        /// <param name="owner">A user or organization account</param>
//        /// <param name="repository">A repository</param>
//        /// <returns>The <see cref="SearchIndexingResponse"/> message.</returns>
//        Task<SearchIndexingResponse> QueueAllIssues(string owner, string repository);
    }
}