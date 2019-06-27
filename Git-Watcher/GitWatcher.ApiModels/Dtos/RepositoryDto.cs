using System;
using Newtonsoft.Json;
using Octokit;

namespace Git_Watcher_Client.Dto
{
    public class RepositoryDto
    {
        public RepositoryDto() { }

        public RepositoryDto(long id)
        {
            Id = id;
        }

        public RepositoryDto(string url, string htmlUrl, string cloneUrl, string gitUrl, long id, User owner, string name, string fullName, string description, string language, bool @private, int openIssuesCount, DateTimeOffset? pushedAt, DateTimeOffset createdAt, DateTimeOffset updatedAt)
        {
            Url = url;
            HtmlUrl = htmlUrl;
            CloneUrl = cloneUrl;
            GitUrl = gitUrl;
            Id = id;
//            Owner = owner;
            Name = name;
            FullName = fullName;
            Description = description;
            Language = language;
            Private = @private;
            OpenIssuesCount = openIssuesCount;
            PushedAt = pushedAt;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        [JsonProperty("url")]
        public string Url { get; protected set; }

        [JsonProperty("html_url")]
        public string HtmlUrl { get; protected set; }

        [JsonProperty("clone_url")]
        public string CloneUrl { get; protected set; }

        [JsonProperty("git_url")]
        public string GitUrl { get; protected set; }
        
        [JsonProperty("id")]
        public long Id { get; protected set; }
        
//        [JsonProperty("owner")]
//        public User Owner { get; protected set; }

        [JsonProperty("owner")]
        public long OwnerName { get; protected set; }

        [JsonProperty("name")]
        public string Name { get; protected set; }

        [JsonProperty("full_name")]
        public string FullName { get; protected set; }

        [JsonProperty("description")]
        public string Description { get; protected set; }

        [JsonProperty("language")]
        public string Language { get; protected set; }

        [JsonProperty("private")]
        public bool Private { get; protected set; }

        [JsonProperty("open_issues_count")]
        public int OpenIssuesCount { get; protected set; }

        [JsonProperty("pushed_at")]
        public DateTimeOffset? PushedAt { get; protected set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; protected set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; protected set; }
        
        public OwnerDto OwnerDto { get; set; }

    }
}