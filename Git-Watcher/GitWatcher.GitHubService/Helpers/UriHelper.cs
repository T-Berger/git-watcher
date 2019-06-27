using System;

namespace GitWatcher.GitHubService.Helpers
{
    public static class UriHelper
    {
        #region Uris
        /// <param name="owner">The owner of the repository</param>
        /// <param name="name">The name of the repository</param>
        public static Uri Repository(string owner, string name)
        {
            return new Uri($"repos/{owner}/{name}", UriKind.Relative);
        }

        /// <param name="id">The id of the repository</param>
        public static Uri Repository(long id)
        {
            return new Uri($"repositories/{id}", UriKind.Relative);
        }
        
        public static Uri AllPublicRepositories()
        {
            return new Uri("repositories", UriKind.Relative);
        }

        public static Uri Issues()
        {
            return new Uri("issues", UriKind.Relative);
        }
        
        /// <param name="owner">The owner of the repository</param>
        /// <param name="name">The name of the repository</param>
        /// <returns>The <see cref="Uri"/> that returns all of the issues for the currently user specific to the repository.</returns>
        public static Uri Issues(string owner, string name)
        {
            return new Uri($"repos/{owner}/{name}/issues", UriKind.Relative);
        }

        /// <param name="owner">The owner of the repository</param>
        /// <param name="name">The name of the repository</param>
        /// <returns>The <see cref="Uri"/> that returns the issues for the given repository.</returns>
        public static Uri Issue(string owner,string repositoryName, long number)
        {
            return new Uri($"repos/{owner}/{repositoryName}/issues/{number}", UriKind.Relative);
        }

        public static Uri SearchRepositories(string repoName)
        {
            return new Uri($"search/repositories?q={repoName}in:name", UriKind.Relative);
        }
        #endregion
    }
}