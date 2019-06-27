using System;
using System.Threading.Tasks;
using Git_Watcher_Client.Dto;
using Git_Watcher_Client.GitHubRestServices.Interfaces;
using ApiConnection = Git_Watcher_Client.GitHubRestServices.ApiConnection;

namespace GitWatcher.GitHubService
{
    public class SearchService: ISearchService
    {
        private ApiConnection _ApiConnection;
        public SearchService(ApiConnection apiConnection)
        {
            _ApiConnection = apiConnection;
        }
        
        /// <summary>
        /// search repos
        /// http://developer.github.com/v3/search/#search-repositories
        /// </summary>
        /// <param name="search">The given search string</param>
        /// <returns>List of repos</returns>
        public Task<SearchRepoDto> SearchRepo(string search)
        {
            
            if (string.IsNullOrEmpty(search)) throw new ArgumentNullException(search, nameof(search));

            return _ApiConnection.Get<SearchRepoDto>(ApiConnection.SearchRepositories(search));
        }

    }
}