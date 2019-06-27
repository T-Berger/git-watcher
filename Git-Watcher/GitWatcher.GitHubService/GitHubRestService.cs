using System;
using Git_Watcher_Client.GitHubRestServices;
using Git_Watcher_Client.GitHubRestServices.Interfaces;
using GitWatcher.GitHubService;

namespace Git_Watcher_Client
{
    public class GitHubRestService : IGitHubRestService
    {
        /// <summary>
        /// The base address for the GitHub API
        /// </summary>
        public static readonly Uri GitHubApiUrl = new Uri("https://api.github.com/");
        internal static readonly Uri GitHubDotComUrl = new Uri("https://github.com/");

        /// <summary>
        /// Create a new instance of the GitHub API v3 
        /// </summary>
        public GitHubRestService()
        {
            var apiConnection = new ApiConnection(GitHubApiUrl);
            Issue = new IssuesService(apiConnection);
            Repository = new RepositoriesService(apiConnection);
            Search = new SearchService(apiConnection);
        }
 
        
        /// <summary>
        /// The base address of the GitHub API. This defaults to https://api.github.com,
        /// but you can change it if needed (to talk to a GitHub:Enterprise server for instance).
        /// </summary>
        public Uri BaseAddress
        {
            get { return ApiConnection.BaseAddress; }
        }

        /// <summary>
        /// Provides a client connection to make rest requests to HTTP endpoints.
        /// </summary>
        public IApiConnection ApiConnection { get; private set; }

        /// <summary>
        /// Access GitHub's Issue API.
        /// </summary>
        /// <remarks>
        /// Refer to the API documentation for more information: https://developer.github.com/v3/issues/
        /// </remarks>
        public IIssuesService Issue { get; private set; }

        /// <summary>
        /// Access GitHub's Repositories API.
        /// </summary>
        /// <remarks>
        /// Refer to the API documentation for more information: https://developer.github.com/v3/repos/
        /// </remarks>
        public IRepositoriesService Repository { get; private set; }
        
        /// <summary>
        /// Access GitHub's Search API.
        /// </summary>
        /// <remarks>
        /// Refer to the API documentation for more information: https://developer.github.com/v3/repos/
        /// </remarks>
        public ISearchService Search { get; private set; }
        
    }
}