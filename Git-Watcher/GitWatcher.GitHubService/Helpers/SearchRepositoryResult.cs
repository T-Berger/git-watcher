using System;
using System.Collections.Generic;
using System.Diagnostics;
using Git_Watcher_Client.Dto;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


namespace Git_Watcher_Client.GitHubRestServices.Helpers
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class SearchRepositoryResult
    {

//        public List<RepositoryDto> items;

        [JsonProperty("total_count")] public int TotalCount;

        [JsonProperty("incomplete_results")] public bool IncoompleteResults;

        
//
//        public class RepositoryDto
//        {
//            [JsonProperty("url")] public string Url { get; protected set; }
//
//            [JsonProperty("html_url")] public string HtmlUrl { get; protected set; }
//
//            [JsonProperty("clone_url")] public string CloneUrl { get; protected set; }
//
//            [JsonProperty("git_url")] public string GitUrl { get; protected set; }
//
//            [JsonProperty("id")] public long Id { get; protected set; }
//
//            [JsonProperty("owner")] public long OwnerName { get; protected set; }
//
//            [JsonProperty("name")] public string Name { get; protected set; }
//
//            [JsonProperty("full_name")] public string FullName { get; protected set; }
//
//            [JsonProperty("description")] public string Description { get; protected set; }
//
//            [JsonProperty("language")] public string Language { get; protected set; }
//
//            [JsonProperty("private")] public bool Private { get; protected set; }
//
//            [JsonProperty("open_issues_count")] public int OpenIssuesCount { get; protected set; }
//
//            [JsonProperty("pushed_at")] public DateTimeOffset? PushedAt { get; protected set; }
//
//            [JsonProperty("created_at")] public DateTimeOffset CreatedAt { get; protected set; }
//
//            [JsonProperty("updated_at")] public DateTimeOffset UpdatedAt { get; protected set; }
//        }
    }
}