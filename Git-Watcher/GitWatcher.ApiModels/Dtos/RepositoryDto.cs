using System;
using Newtonsoft.Json;
using Octokit;

namespace Git_Watcher_Client.Dto
{
    public class RepositoryDto
    {
        public RepositoryDto(long id, string nodeId, string name, string fullName, bool @private, Owner owner, Uri htmlUrl,
            string description, bool fork, Uri url, Uri forksUrl, string keysUrl, string collaboratorsUrl, Uri teamsUrl,
            Uri hooksUrl, string issueEventsUrl, Uri eventsUrl, string assigneesUrl, string branchesUrl, Uri tagsUrl,
            string blobsUrl, string gitTagsUrl, string gitRefsUrl, string treesUrl, string statusesUrl,
            Uri languagesUrl, Uri stargazersUrl, Uri contributorsUrl, Uri subscribersUrl, Uri subscriptionUrl,
            string commitsUrl, string gitCommitsUrl, string commentsUrl, string issueCommentUrl, string contentsUrl,
            string compareUrl, Uri mergesUrl, string archiveUrl, Uri downloadsUrl, string issuesUrl, string pullsUrl,
            string milestonesUrl, string notificationsUrl, string labelsUrl, string releasesUrl, Uri deploymentsUrl,
            DateTimeOffset createdAt, DateTimeOffset updatedAt, DateTimeOffset pushedAt, string gitUrl, string sshUrl,
            Uri cloneUrl, Uri svnUrl, string homepage, long size, long stargazersCount, long watchersCount,
            string language, bool hasIssues, bool hasProjects, bool hasDownloads, bool hasWiki, bool hasPages,
            long forksCount, object mirrorUrl, bool archived, bool disabled, long openIssuesCount, License license,
            long forks, long openIssues, long watchers, string defaultBranch, double score)
        {
            Id = id;
            NodeId = nodeId;
            Name = name;
            FullName = fullName;
            Private = @private;
            Owner = owner;
            HtmlUrl = htmlUrl;
            Description = description;
            Fork = fork;
            Url = url;
            ForksUrl = forksUrl;
            KeysUrl = keysUrl;
            CollaboratorsUrl = collaboratorsUrl;
            TeamsUrl = teamsUrl;
            HooksUrl = hooksUrl;
            IssueEventsUrl = issueEventsUrl;
            EventsUrl = eventsUrl;
            AssigneesUrl = assigneesUrl;
            BranchesUrl = branchesUrl;
            TagsUrl = tagsUrl;
            BlobsUrl = blobsUrl;
            GitTagsUrl = gitTagsUrl;
            GitRefsUrl = gitRefsUrl;
            TreesUrl = treesUrl;
            StatusesUrl = statusesUrl;
            LanguagesUrl = languagesUrl;
            StargazersUrl = stargazersUrl;
            ContributorsUrl = contributorsUrl;
            SubscribersUrl = subscribersUrl;
            SubscriptionUrl = subscriptionUrl;
            CommitsUrl = commitsUrl;
            GitCommitsUrl = gitCommitsUrl;
            CommentsUrl = commentsUrl;
            IssueCommentUrl = issueCommentUrl;
            ContentsUrl = contentsUrl;
            CompareUrl = compareUrl;
            MergesUrl = mergesUrl;
            ArchiveUrl = archiveUrl;
            DownloadsUrl = downloadsUrl;
            IssuesUrl = issuesUrl;
            PullsUrl = pullsUrl;
            MilestonesUrl = milestonesUrl;
            NotificationsUrl = notificationsUrl;
            LabelsUrl = labelsUrl;
            ReleasesUrl = releasesUrl;
            DeploymentsUrl = deploymentsUrl;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            PushedAt = pushedAt;
            GitUrl = gitUrl;
            SshUrl = sshUrl;
            CloneUrl = cloneUrl;
            SvnUrl = svnUrl;
            Homepage = homepage;
            Size = size;
            StargazersCount = stargazersCount;
            WatchersCount = watchersCount;
            Language = language;
            HasIssues = hasIssues;
            HasProjects = hasProjects;
            HasDownloads = hasDownloads;
            HasWiki = hasWiki;
            HasPages = hasPages;
            ForksCount = forksCount;
            MirrorUrl = mirrorUrl;
            Archived = archived;
            Disabled = disabled;
            OpenIssuesCount = openIssuesCount;
            License = license;
            Forks = forks;
            OpenIssues = openIssues;
            Watchers = watchers;
            DefaultBranch = defaultBranch;
            Score = score;
        }

        [JsonProperty("id")] public long Id { get; set; }

        [JsonProperty("node_id")] public string NodeId { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("full_name")] public string FullName { get; set; }

        [JsonProperty("private")] public bool Private { get; set; }

        [JsonProperty("owner")] public Owner Owner { get; set; }

        [JsonProperty("html_url")] public Uri HtmlUrl { get; set; }

        [JsonProperty("description")] public string Description { get; set; }

        [JsonProperty("fork")] public bool Fork { get; set; }

        [JsonProperty("url")] public Uri Url { get; set; }

        [JsonProperty("forks_url")] public Uri ForksUrl { get; set; }

        [JsonProperty("keys_url")] public string KeysUrl { get; set; }

        [JsonProperty("collaborators_url")] public string CollaboratorsUrl { get; set; }

        [JsonProperty("teams_url")] public Uri TeamsUrl { get; set; }

        [JsonProperty("hooks_url")] public Uri HooksUrl { get; set; }

        [JsonProperty("issue_events_url")] public string IssueEventsUrl { get; set; }

        [JsonProperty("events_url")] public Uri EventsUrl { get; set; }

        [JsonProperty("assignees_url")] public string AssigneesUrl { get; set; }

        [JsonProperty("branches_url")] public string BranchesUrl { get; set; }

        [JsonProperty("tags_url")] public Uri TagsUrl { get; set; }

        [JsonProperty("blobs_url")] public string BlobsUrl { get; set; }

        [JsonProperty("git_tags_url")] public string GitTagsUrl { get; set; }

        [JsonProperty("git_refs_url")] public string GitRefsUrl { get; set; }

        [JsonProperty("trees_url")] public string TreesUrl { get; set; }

        [JsonProperty("statuses_url")] public string StatusesUrl { get; set; }

        [JsonProperty("languages_url")] public Uri LanguagesUrl { get; set; }

        [JsonProperty("stargazers_url")] public Uri StargazersUrl { get; set; }

        [JsonProperty("contributors_url")] public Uri ContributorsUrl { get; set; }

        [JsonProperty("subscribers_url")] public Uri SubscribersUrl { get; set; }

        [JsonProperty("subscription_url")] public Uri SubscriptionUrl { get; set; }

        [JsonProperty("commits_url")] public string CommitsUrl { get; set; }

        [JsonProperty("git_commits_url")] public string GitCommitsUrl { get; set; }

        [JsonProperty("comments_url")] public string CommentsUrl { get; set; }

        [JsonProperty("issue_comment_url")] public string IssueCommentUrl { get; set; }

        [JsonProperty("contents_url")] public string ContentsUrl { get; set; }

        [JsonProperty("compare_url")] public string CompareUrl { get; set; }

        [JsonProperty("merges_url")] public Uri MergesUrl { get; set; }

        [JsonProperty("archive_url")] public string ArchiveUrl { get; set; }

        [JsonProperty("downloads_url")] public Uri DownloadsUrl { get; set; }

        [JsonProperty("issues_url")] public string IssuesUrl { get; set; }

        [JsonProperty("pulls_url")] public string PullsUrl { get; set; }

        [JsonProperty("milestones_url")] public string MilestonesUrl { get; set; }

        [JsonProperty("notifications_url")] public string NotificationsUrl { get; set; }

        [JsonProperty("labels_url")] public string LabelsUrl { get; set; }

        [JsonProperty("releases_url")] public string ReleasesUrl { get; set; }

        [JsonProperty("deployments_url")] public Uri DeploymentsUrl { get; set; }

        [JsonProperty("created_at")] public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")] public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("pushed_at")] public DateTimeOffset PushedAt { get; set; }

        [JsonProperty("git_url")] public string GitUrl { get; set; }

        [JsonProperty("ssh_url")] public string SshUrl { get; set; }

        [JsonProperty("clone_url")] public Uri CloneUrl { get; set; }

        [JsonProperty("svn_url")] public Uri SvnUrl { get; set; }

        [JsonProperty("homepage")] public string Homepage { get; set; }

        [JsonProperty("size")] public long Size { get; set; }

        [JsonProperty("stargazers_count")] public long StargazersCount { get; set; }

        [JsonProperty("watchers_count")] public long WatchersCount { get; set; }

        [JsonProperty("language")] public string Language { get; set; }

        [JsonProperty("has_issues")] public bool HasIssues { get; set; }

        [JsonProperty("has_projects")] public bool HasProjects { get; set; }

        [JsonProperty("has_downloads")] public bool HasDownloads { get; set; }

        [JsonProperty("has_wiki")] public bool HasWiki { get; set; }

        [JsonProperty("has_pages")] public bool HasPages { get; set; }

        [JsonProperty("forks_count")] public long ForksCount { get; set; }

        [JsonProperty("mirror_url")] public object MirrorUrl { get; set; }

        [JsonProperty("archived")] public bool Archived { get; set; }

        [JsonProperty("disabled")] public bool Disabled { get; set; }

        [JsonProperty("open_issues_count")] public long OpenIssuesCount { get; set; }

        [JsonProperty("license")] public License License { get; set; }

        [JsonProperty("forks")] public long Forks { get; set; }

        [JsonProperty("open_issues")] public long OpenIssues { get; set; }

        [JsonProperty("watchers")] public long Watchers { get; set; }

        [JsonProperty("default_branch")] public string DefaultBranch { get; set; }

        [JsonProperty("score")] public double Score { get; set; }
        
        public override string ToString()
        {
            return "Title:" + Name + "\n Id:" + Id + "\n Von:" + Owner.Login +"\n Beschreibung:" + Description ;
        }
    }
}