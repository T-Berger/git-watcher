using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Git_Watcher_Client.Dto
{
    public class IssueDto
    {
        [JsonConstructor]
        public IssueDto()
        {
            
        }

        
        [JsonConstructor]
        public IssueDto(long id, string nodeId, Uri url, Uri repositoryUrl, string labelsUrl, Uri commentsUrl,
            Uri eventsUrl, Uri htmlUrl, long number, string state, string title, string body, Assignee user,
            Label[] labels, Assignee assignee, Assignee[] assignees, Milestone milestone, bool locked,
            string activeLockReason, long comments, PullRequest pullRequest, object closedAt, DateTimeOffset createdAt,
            DateTimeOffset updatedAt, Repository repository)
        {
            Id = id;
            NodeId = nodeId;
            Url = url;
            RepositoryUrl = repositoryUrl;
            LabelsUrl = labelsUrl;
            CommentsUrl = commentsUrl;
            EventsUrl = eventsUrl;
            HtmlUrl = htmlUrl;
            Number = number;
            State = state;
            Title = title;
            Body = body;
            User = user;
            Labels = labels;
            Assignee = assignee;
            Assignees = assignees;
            Milestone = milestone;
            Locked = locked;
            ActiveLockReason = activeLockReason;
            Comments = comments;
            PullRequest = pullRequest;
            ClosedAt = closedAt;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Repository = repository;
        }

        /// <summary>
        /// The internal Id for this issue (not the issue number)
        /// </summary>
        [JsonProperty("id")] public long Id { get; set; }

        [JsonProperty("node_id")] public string NodeId { get; set; }

        /// <summary>
        /// The URL for this issue.
        /// </summary>
        [JsonProperty("url")] public Uri Url { get; set; }

        [JsonProperty("repository_url")] public Uri RepositoryUrl { get; set; }

        [JsonProperty("labels_url")] public string LabelsUrl { get; set; }

        [JsonProperty("comments_url")] public Uri CommentsUrl { get; set; }

        [JsonProperty("events_url")] public Uri EventsUrl { get; set; }

        /// <summary>
        /// The URL for the HTML view of this issue.
        /// </summary>
        [JsonProperty("html_url")] public Uri HtmlUrl { get; set; }

        /// <summary>
        /// The issue number.
        /// </summary>
        [JsonProperty("number")] public long Number { get; set; }

        [JsonProperty("state")] public string State { get; set; }

        /// <summary>
        /// Title of the issue
        /// </summary>
        [JsonProperty("title")] public string Title { get; set; }

        /// <summary>
        /// Details about the issue.
        /// </summary>
        [JsonProperty("body")] public string Body { get; set; }

        [JsonProperty("user")] public Assignee User { get; set; }

        [JsonProperty("labels")] public Label[] Labels { get; set; }

        [JsonProperty("assignee")] public Assignee Assignee { get; set; }

        [JsonProperty("assignees")] public Assignee[] Assignees { get; set; }

        [JsonProperty("milestone")] public Milestone Milestone { get; set; }

        [JsonProperty("locked")] public bool Locked { get; set; }

        [JsonProperty("active_lock_reason")] public string ActiveLockReason { get; set; }

        /// <summary>
        /// The number of comments on the issue.
        /// </summary>
        [JsonProperty("comments")] public long Comments { get; set; }

        [JsonProperty("pull_request")] public PullRequest PullRequest { get; set; }

        /// <summary>
        /// The date the issue was closed if closed.
        /// </summary>
        [JsonProperty("closed_at")] public object ClosedAt { get; set; }

        /// <summary>
        /// The date the issue was created.
        /// </summary>
        [JsonProperty("created_at")] public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// The date the issue was last updated.
        /// </summary>
        [JsonProperty("updated_at")] public DateTimeOffset UpdatedAt { get; set; }

        /// <summary>
        /// The repository the issue comes from.
        /// </summary>
        [JsonProperty("repository")] public Repository Repository { get; set; }
    }

    public partial class Assignee
    {
        [JsonProperty("login")] public string Login { get; set; }

        [JsonProperty("id")] public long Id { get; set; }

        [JsonProperty("node_id")] public string NodeId { get; set; }

        [JsonProperty("avatar_url")] public Uri AvatarUrl { get; set; }

        [JsonProperty("gravatar_id")] public string GravatarId { get; set; }

        [JsonProperty("url")] public Uri Url { get; set; }

        [JsonProperty("html_url")] public Uri HtmlUrl { get; set; }

        [JsonProperty("followers_url")] public Uri FollowersUrl { get; set; }

        [JsonProperty("following_url")] public string FollowingUrl { get; set; }

        [JsonProperty("gists_url")] public string GistsUrl { get; set; }

        [JsonProperty("starred_url")] public string StarredUrl { get; set; }

        [JsonProperty("subscriptions_url")] public Uri SubscriptionsUrl { get; set; }

        [JsonProperty("organizations_url")] public Uri OrganizationsUrl { get; set; }

        [JsonProperty("repos_url")] public Uri ReposUrl { get; set; }

        [JsonProperty("events_url")] public string EventsUrl { get; set; }

        [JsonProperty("received_events_url")] public Uri ReceivedEventsUrl { get; set; }

        [JsonProperty("type")] public string Type { get; set; }

        [JsonProperty("site_admin")] public bool SiteAdmin { get; set; }
    }

    public partial class Label
    {
        
        [JsonConstructor]
        public Label()
        {
            
        }

        [JsonConstructor]
        public Label(long id, string nodeId, Uri url, string name, string description, string color, bool @default)
        {
            Id = id;
            NodeId = nodeId;
            Url = url;
            Name = name;
            Description = description;
            Color = color;
            Default = @default;
        }

        [JsonProperty("id")] public long Id { get; set; }

        [JsonProperty("node_id")] public string NodeId { get; set; }

        [JsonProperty("url")] public Uri Url { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("description")] public string Description { get; set; }

        [JsonProperty("color")] public string Color { get; set; }

        [JsonProperty("default")] public bool Default { get; set; }
    }

    public partial class Milestone
    {
        
        [JsonConstructor]
        public Milestone()
        {
            
        }

        [JsonConstructor]
        public Milestone(Uri url, Uri htmlUrl, Uri labelsUrl, long id, string nodeId, long number, string state, string title, string description, Assignee creator, long openIssues, long closedIssues, DateTimeOffset createdAt, DateTimeOffset updatedAt, DateTimeOffset closedAt, DateTimeOffset dueOn)
        {
            Url = url;
            HtmlUrl = htmlUrl;
            LabelsUrl = labelsUrl;
            Id = id;
            NodeId = nodeId;
            Number = number;
            State = state;
            Title = title;
            Description = description;
            Creator = creator;
            OpenIssues = openIssues;
            ClosedIssues = closedIssues;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            ClosedAt = closedAt;
            DueOn = dueOn;
        }

        [JsonProperty("url")] public Uri Url { get; set; }

        [JsonProperty("html_url")] public Uri HtmlUrl { get; set; }

        [JsonProperty("labels_url")] public Uri LabelsUrl { get; set; }

        [JsonProperty("id")] public long Id { get; set; }

        [JsonProperty("node_id")] public string NodeId { get; set; }

        [JsonProperty("number")] public long Number { get; set; }

        [JsonProperty("state")] public string State { get; set; }

        [JsonProperty("title")] public string Title { get; set; }

        [JsonProperty("description")] public string Description { get; set; }

        [JsonProperty("creator")] public Assignee Creator { get; set; }

        [JsonProperty("open_issues")] public long OpenIssues { get; set; }

        [JsonProperty("closed_issues")] public long ClosedIssues { get; set; }

        [JsonProperty("created_at")] public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")] public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("closed_at")] public DateTimeOffset ClosedAt { get; set; }

        [JsonProperty("due_on")] public DateTimeOffset DueOn { get; set; }
    }

    public partial class PullRequest
    {
        
        [JsonConstructor]
        public PullRequest()
        {
            
        }

        
        [JsonConstructor]
        public PullRequest(Uri url, Uri htmlUrl, Uri diffUrl, Uri patchUrl)
        {
            Url = url;
            HtmlUrl = htmlUrl;
            DiffUrl = diffUrl;
            PatchUrl = patchUrl;
        }

        [JsonProperty("url")] public Uri Url { get; set; }

        [JsonProperty("html_url")] public Uri HtmlUrl { get; set; }

        [JsonProperty("diff_url")] public Uri DiffUrl { get; set; }

        [JsonProperty("patch_url")] public Uri PatchUrl { get; set; }
    }

    public partial class Repository
    {
        
        [JsonConstructor]
        public Repository()
        {
            
        }
        
        [JsonProperty("id")] public long Id { get; set; }

        [JsonProperty("node_id")] public string NodeId { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("full_name")] public string FullName { get; set; }

        [JsonProperty("owner")] public Assignee Owner { get; set; }

        [JsonProperty("private")] public bool Private { get; set; }

        [JsonProperty("html_url")] public Uri HtmlUrl { get; set; }

        [JsonProperty("description")] public string Description { get; set; }

        [JsonProperty("fork")] public bool Fork { get; set; }

        [JsonProperty("url")] public Uri Url { get; set; }

        [JsonProperty("archive_url")] public string ArchiveUrl { get; set; }

        [JsonProperty("assignees_url")] public string AssigneesUrl { get; set; }

        [JsonProperty("blobs_url")] public string BlobsUrl { get; set; }

        [JsonProperty("branches_url")] public string BranchesUrl { get; set; }

        [JsonProperty("collaborators_url")] public string CollaboratorsUrl { get; set; }

        [JsonProperty("comments_url")] public string CommentsUrl { get; set; }

        [JsonProperty("commits_url")] public string CommitsUrl { get; set; }

        [JsonProperty("compare_url")] public string CompareUrl { get; set; }

        [JsonProperty("contents_url")] public string ContentsUrl { get; set; }

        [JsonProperty("contributors_url")] public Uri ContributorsUrl { get; set; }

        [JsonProperty("deployments_url")] public Uri DeploymentsUrl { get; set; }

        [JsonProperty("downloads_url")] public Uri DownloadsUrl { get; set; }

        [JsonProperty("events_url")] public Uri EventsUrl { get; set; }

        [JsonProperty("forks_url")] public Uri ForksUrl { get; set; }

        [JsonProperty("git_commits_url")] public string GitCommitsUrl { get; set; }

        [JsonProperty("git_refs_url")] public string GitRefsUrl { get; set; }

        [JsonProperty("git_tags_url")] public string GitTagsUrl { get; set; }

        [JsonProperty("git_url")] public string GitUrl { get; set; }

        [JsonProperty("issue_comment_url")] public string IssueCommentUrl { get; set; }

        [JsonProperty("issue_events_url")] public string IssueEventsUrl { get; set; }

        [JsonProperty("issues_url")] public string IssuesUrl { get; set; }

        [JsonProperty("keys_url")] public string KeysUrl { get; set; }

        [JsonProperty("labels_url")] public string LabelsUrl { get; set; }

        [JsonProperty("languages_url")] public Uri LanguagesUrl { get; set; }

        [JsonProperty("merges_url")] public Uri MergesUrl { get; set; }

        [JsonProperty("milestones_url")] public string MilestonesUrl { get; set; }

        [JsonProperty("notifications_url")] public string NotificationsUrl { get; set; }

        [JsonProperty("pulls_url")] public string PullsUrl { get; set; }

        [JsonProperty("releases_url")] public string ReleasesUrl { get; set; }

        [JsonProperty("ssh_url")] public string SshUrl { get; set; }

        [JsonProperty("stargazers_url")] public Uri StargazersUrl { get; set; }

        [JsonProperty("statuses_url")] public string StatusesUrl { get; set; }

        [JsonProperty("subscribers_url")] public Uri SubscribersUrl { get; set; }

        [JsonProperty("subscription_url")] public Uri SubscriptionUrl { get; set; }

        [JsonProperty("tags_url")] public Uri TagsUrl { get; set; }

        [JsonProperty("teams_url")] public Uri TeamsUrl { get; set; }

        [JsonProperty("trees_url")] public string TreesUrl { get; set; }

        [JsonProperty("clone_url")] public Uri CloneUrl { get; set; }

        [JsonProperty("mirror_url")] public string MirrorUrl { get; set; }

        [JsonProperty("hooks_url")] public Uri HooksUrl { get; set; }

        [JsonProperty("svn_url")] public Uri SvnUrl { get; set; }

        [JsonProperty("homepage")] public Uri Homepage { get; set; }

        [JsonProperty("language")] public object Language { get; set; }

        [JsonProperty("forks_count")] public long ForksCount { get; set; }

        [JsonProperty("stargazers_count")] public long StargazersCount { get; set; }

        [JsonProperty("watchers_count")] public long WatchersCount { get; set; }

        [JsonProperty("size")] public long Size { get; set; }

        [JsonProperty("default_branch")] public string DefaultBranch { get; set; }

        [JsonProperty("open_issues_count")] public long OpenIssuesCount { get; set; }

        [JsonProperty("topics")] public string[] Topics { get; set; }

        [JsonProperty("has_issues")] public bool HasIssues { get; set; }

        [JsonProperty("has_projects")] public bool HasProjects { get; set; }

        [JsonProperty("has_wiki")] public bool HasWiki { get; set; }

        [JsonProperty("has_pages")] public bool HasPages { get; set; }

        [JsonProperty("has_downloads")] public bool HasDownloads { get; set; }

        [JsonProperty("archived")] public bool Archived { get; set; }

        [JsonProperty("disabled")] public bool Disabled { get; set; }

        [JsonProperty("pushed_at")] public DateTimeOffset PushedAt { get; set; }

        [JsonProperty("created_at")] public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")] public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("permissions")] public Permissions Permissions { get; set; }

        [JsonProperty("allow_rebase_merge")] public bool AllowRebaseMerge { get; set; }

        [JsonProperty("allow_squash_merge")] public bool AllowSquashMerge { get; set; }

        [JsonProperty("allow_merge_commit")] public bool AllowMergeCommit { get; set; }

        [JsonProperty("subscribers_count")] public long SubscribersCount { get; set; }

        [JsonProperty("network_count")] public long NetworkCount { get; set; }
    }

    public partial class Permissions
    {
        
        [JsonConstructor]
        public Permissions()
        {
            
        }

        [JsonProperty("admin")] public bool Admin { get; set; }

        [JsonProperty("push")] public bool Push { get; set; }

        [JsonProperty("pull")] public bool Pull { get; set; }
    }
}