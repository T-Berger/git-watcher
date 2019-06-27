using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Git_Watcher_Client.Dto;
using Git_Watcher_Client.GitHubRestServices.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Octokit.Internal;

namespace Git_Watcher_Client.GitHubRestServices
{
    public class ApiConnection : IApiConnection
    {
        public Uri BaseAddress { get; }


        private static readonly HttpClient Client = new HttpClient();

        public ApiConnection()
        {
            Client.DefaultRequestHeaders.Add("User-Agent", "T-Berger");

        }
        
        public ApiConnection(Uri gitHubApiUrl)
        {
            BaseAddress = gitHubApiUrl;
            Client.DefaultRequestHeaders.Add("User-Agent", "T-Berger");
        }
        
        /// <summary>
        /// For getting a single item from a web api using GET
        /// </summary>
        /// <param name="apiUrl">Added to the base address to make the full url of the 
        ///     api get method, e.g. "products/1" to get a product with an id of 1</param>
        public async Task<T> Get<T>(Uri uri)
        {
            var result = default(T);
            var response = await Client.GetAsync(new Uri(BaseAddress,uri), CancellationToken.None).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                await response.Content.ReadAsStringAsync().ContinueWith(x =>
                {
                    if (typeof(T).Namespace != "System")
                    {
                        result = JsonConvert.DeserializeObject<T>(x?.Result);
                    }
                    else result = (T) Convert.ChangeType(x?.Result, typeof(T));
                },CancellationToken.None);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                response.Content?.Dispose();
                throw new HttpRequestException($"{response.StatusCode}:{content}");
            }
            return result;
        }
        
        
        /// For getting a single item from a web api using GET
        /// </summary>
        /// <param name="apiUrl">Added to the base address to make the full url of the 
        ///     api get method, e.g. "products/1" to get a product with an id of 1</param>
        public async Task<RepositoryDto> GetRepoWithUserName<RepositoryDto>(Uri uri)
        {
            var result = default(RepositoryDto);
            var response = await Client.GetAsync(new Uri(BaseAddress,uri), CancellationToken.None).ConfigureAwait(true);
            if (response.IsSuccessStatusCode)
            {
                await response.Content.ReadAsStringAsync().ContinueWith(x =>
                {
                    if (typeof(RepositoryDto).Namespace != "System")
                    {
                        result = JsonConvert.DeserializeObject<RepositoryDto>(x?.Result);
                        
                    }
                    else result = (RepositoryDto) Convert.ChangeType(x?.Result, typeof(RepositoryDto));
                },CancellationToken.None);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                response.Content?.Dispose();
                throw new HttpRequestException($"{response.StatusCode}:{content}");
            }
            return result;
        }

        /// <summary>
        /// For getting multiple (or all) items from a web api using GET
        /// </summary>
        /// <param name="apiUrl">Added to the base address to make the full url of the 
        ///     api get method, e.g. "products?page=1" to get page 1 of the products</param>
        /// <returns>The items requested</returns>
        public async Task<IReadOnlyList<T>> GetAll<T>(Uri uri)
        {
            IReadOnlyList<T> result = null;
            var response = await Client.GetAsync(new Uri(BaseAddress,uri), CancellationToken.None).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
                {
                    result = JsonConvert.DeserializeObject<T[]>(x.Result);
                }, CancellationToken.None);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                response.Content?.Dispose();
                throw new HttpRequestException($"{response.StatusCode}:{content}");
            }
            return result;
        }
        
        
        
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
        /// <returns></returns>
        public static Uri Issues(string owner, string name)
        {
            return new Uri("repos/{owner}/{name}/issues", UriKind.Relative);
        }

        /// <param name="repositoryId">The Id of the repository</param>
        /// <returns>The <see cref="Uri"/> that returns all of the issues for the currently logged in user specific to the repository.</returns>
        public static Uri Issues(string owner,long repositoryId)
        {
            return new Uri($"{owner}/repositories/{repositoryId}/issues", UriKind.Relative);
        }
        
        /// <param name="repositoryId">The Id of the repository</param>
        /// <param name="number">The issue number</param>
        /// <returns>The <see cref="Uri"/> that returns the issues for the given repository.</returns>
        public static Uri Issue(string owner,long repositoryId, long number)
        {
            return new Uri($"{owner}/repositories/{repositoryId}/issues/{number}", UriKind.Relative);
        }

        public static Uri SearchRepositories(string repoName)
        {
            return new Uri($"search/repositories?q={repoName}in:name", UriKind.Relative);
        }
        
        #endregion
    }
}