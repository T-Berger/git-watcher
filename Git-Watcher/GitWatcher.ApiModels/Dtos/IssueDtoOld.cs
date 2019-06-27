using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Git_Watcher_Client.Dto
{
    public class IssueDtoOld
    {
        /// <summary>
        /// The internal Id for this issue (not the issue number)
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; protected set; }

        /// <summary>
        /// The URL for this issue.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; protected set; }

        /// <summary>
        /// The URL for the HTML view of this issue.
        /// </summary>
        [JsonProperty("html_url")]
        public string HtmlUrl { get; protected set; }
        
        /// <summary>
        /// The issue number.
        /// </summary>
        [JsonProperty("number")]
        public int Number { get; protected set; }
        
        /// <summary>
        /// Title of the issue
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; protected set; }

        /// <summary>
        /// Details about the issue.
        /// </summary>
        [JsonProperty("body")]
        public string Body { get; protected set; }
        
        /// <summary>
        /// The number of comments on the issue.
        /// </summary>
        [JsonProperty("comments")]
        public int Comments { get; protected set; }
        
        /// <summary>
        /// The date the issue was closed if closed.
        /// </summary>
        [JsonProperty("closed_at")]
        public DateTimeOffset? ClosedAt { get; protected set; }

        /// <summary>
        /// The date the issue was created.
        /// </summary>
        /// 
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; protected set; }

        /// <summary>
        /// The date the issue was last updated.
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTimeOffset? UpdatedAt { get; protected set; }

        /// <summary>
        /// The repository the issue comes from.
        /// </summary>
        [JsonProperty("repository_url")]
        public string RepositoryUrl { get; protected set; }
        
    }
}