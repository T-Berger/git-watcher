using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Git_Watcher_Client.GitHubRestServices.Interfaces
{
    public interface IApiConnection
    {
        Uri BaseAddress { get; }
//
//        /// <summary>
//        /// Gets the API resource at the specified URI.
//        /// </summary>
//        /// <typeparam name="T">Type of the API resource in the list.</typeparam>
//        /// <param name="uri">URI of the API resource to get</param>
//        /// <returns>The API resource.</returns>
//        Task<T> Get<T>(Uri uri);
//
//        /// <summary>
//        /// Gets all API resources in the list at the specified URI.
//        /// </summary>
//        /// <typeparam name="T">Type of the API resource in the list.</typeparam>
//        /// <param name="uri">URI of the API resource to get</param>
//        /// <returns><see cref="IReadOnlyList{T}"/> of the The API resources in the list.</returns>
//        Task<IReadOnlyList<T>> GetAll<T>(Uri uri);
        
    }
}