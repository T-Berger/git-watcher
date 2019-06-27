namespace Git_Watcher_Client.GitHubRestServices.Interfaces
{
    public interface IGitHubRestService
    { 
        /// <summary>
        /// Provides a client connection to make rest requests to HTTP endpoints.
        /// </summary>
        IApiConnection ApiConnection { get; }

        /// <summary>
        /// Access GitHub's Issue API.
        /// </summary>
        /// <remarks>
        /// Refer to the API documentation for more information: https://developer.github.com/v3/issues/
        /// </remarks>
        IIssuesService Issue { get; }

        /// <summary>
        /// Access GitHub's Repositories API.
        /// Access GitHub's Repositories API.
        /// </summary>
        /// <remarks>
        /// Refer to the API documentation for more information: https://developer.github.com/v3/repos/
        /// </remarks>
        IRepositoriesService Repository { get; }

    }
}