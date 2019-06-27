using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Git_Watcher_Client;
using Git_Watcher_Client.Dto;
using Git_Watcher_Client.GitHubRestServices.Helpers;
using GitWatcher.GitHubService.Helpers.JsonSerializeRootObject;
using Newtonsoft.Json;
using Xunit;

namespace GitWatcher.Tests.GitHubServices
{
    public class SearchServiceTest
    {
        #region JsonTest

        public class JsonTest
        {
            #region JsonString

            private const string json = @"{
            ""total_count"": 1,
            ""incomplete_results"": false,
            ""items"": [
                {
                    ""id"": 154739983,
                    ""node_id"": ""MDEwOlJlcG9zaXRvcnkxNTQ3Mzk5ODM="",
                    ""name"": ""UnofficialCrusaderPatch"",
                    ""full_name"": ""Sh0wdown/UnofficialCrusaderPatch"",
                    ""private"": false,
                    ""owner"": {
                        ""login"": ""Sh0wdown"",
                        ""id"": 9576090,
                        ""node_id"": ""MDQ6VXNlcjk1NzYwOTA="",
                        ""avatar_url"": ""https://avatars0.githubusercontent.com/u/9576090?v=4"",
                        ""gravatar_id"": """",
                        ""url"": ""https://api.github.com/users/Sh0wdown"",
                        ""html_url"": ""https://github.com/Sh0wdown"",
                        ""followers_url"": ""https://api.github.com/users/Sh0wdown/followers"",
                        ""following_url"": ""https://api.github.com/users/Sh0wdown/following{/other_user}"",
                        ""gists_url"": ""https://api.github.com/users/Sh0wdown/gists{/gist_id}"",
                        ""starred_url"": ""https://api.github.com/users/Sh0wdown/starred{/owner}{/repo}"",
                        ""subscriptions_url"": ""https://api.github.com/users/Sh0wdown/subscriptions"",
                        ""organizations_url"": ""https://api.github.com/users/Sh0wdown/orgs"",
                        ""repos_url"": ""https://api.github.com/users/Sh0wdown/repos"",
                        ""events_url"": ""https://api.github.com/users/Sh0wdown/events{/privacy}"",
                        ""received_events_url"": ""https://api.github.com/users/Sh0wdown/received_events"",
                        ""type"": ""User"",
                        ""site_admin"": false
                    },
                    ""html_url"": ""https://github.com/Sh0wdown/UnofficialCrusaderPatch"",
                    ""description"": ""Unofficial balancing patch installer for Stronghold Crusader 1"",
                    ""fork"": false,
                    ""url"": ""https://api.github.com/repos/Sh0wdown/UnofficialCrusaderPatch"",
                    ""forks_url"": ""https://api.github.com/repos/Sh0wdown/UnofficialCrusaderPatch/forks"",
                    ""keys_url"": ""https://api.github.com/repos/Sh0wdown/UnofficialCrusaderPatch/keys{/key_id}"",
                    ""collaborators_url"": ""https://api.github.com/repos/Sh0wdown/UnofficialCrusaderPatch/collaborators{/collaborator}"",
                    ""teams_url"": ""https://api.github.com/repos/Sh0wdown/UnofficialCrusaderPatch/teams"",
                    ""hooks_url"": ""https://api.github.com/repos/Sh0wdown/UnofficialCrusaderPatch/hooks"",
                    ""issue_events_url"": ""https://api.github.com/repos/Sh0wdown/UnofficialCrusaderPatch/issues/events{/number}"",
                    ""events_url"": ""https://api.github.com/repos/Sh0wdown/UnofficialCrusaderPatch/events"",
                    ""assignees_url"": ""https://api.github.com/repos/Sh0wdown/UnofficialCrusaderPatch/assignees{/user}"",
                    ""branches_url"": ""https://api.github.com/repos/Sh0wdown/UnofficialCrusaderPatch/branches{/branch}"",
                    ""tags_url"": ""https://api.github.com/repos/Sh0wdown/UnofficialCrusaderPatch/tags"",
                    ""blobs_url"": ""https://api.github.com/repos/Sh0wdown/UnofficialCrusaderPatch/git/blobs{/sha}"",
                    ""git_tags_url"": ""https://api.github.com/repos/Sh0wdown/UnofficialCrusaderPatch/git/tags{/sha}"",
                    ""git_refs_url"": ""https://api.github.com/repos/Sh0wdown/UnofficialCrusaderPatch/git/refs{/sha}"",
                    ""trees_url"": ""https://api.github.com/repos/Sh0wdown/UnofficialCrusaderPatch/git/trees{/sha}"",
                    ""statuses_url"": ""https://api.github.com/repos/Sh0wdown/UnofficialCrusaderPatch/statuses/{sha}"",
                    ""languages_url"": ""https://api.github.com/repos/Sh0wdown/UnofficialCrusaderPatch/languages"",
                    ""stargazers_url"": ""https://api.github.com/repos/Sh0wdown/UnofficialCrusaderPatch/stargazers"",
                    ""contributors_url"": ""https://api.github.com/repos/Sh0wdown/UnofficialCrusaderPatch/contributors"",
                    ""subscribers_url"": ""https://api.github.com/repos/Sh0wdown/UnofficialCrusaderPatch/subscribers"",
                    ""subscription_url"": ""https://api.github.com/repos/Sh0wdown/UnofficialCrusaderPatch/subscription"",
                    ""commits_url"": ""https://api.github.com/repos/Sh0wdown/UnofficialCrusaderPatch/commits{/sha}"",
                    ""git_commits_url"": ""https://api.github.com/repos/Sh0wdown/UnofficialCrusaderPatch/git/commits{/sha}"",
                    ""comments_url"": ""https://api.github.com/repos/Sh0wdown/UnofficialCrusaderPatch/comments{/number}"",
                    ""issue_comment_url"": ""https://api.github.com/repos/Sh0wdown/UnofficialCrusaderPatch/issues/comments{/number}"",
                    ""contents_url"": ""https://api.github.com/repos/Sh0wdown/UnofficialCrusaderPatch/contents/{+path}"",
                    ""compare_url"": ""https://api.github.com/repos/Sh0wdown/UnofficialCrusaderPatch/compare/{base}...{head}"",
                    ""merges_url"": ""https://api.github.com/repos/Sh0wdown/UnofficialCrusaderPatch/merges"",
                    ""archive_url"": ""https://api.github.com/repos/Sh0wdown/UnofficialCrusaderPatch/{archive_format}{/ref}"",
                    ""downloads_url"": ""https://api.github.com/repos/Sh0wdown/UnofficialCrusaderPatch/downloads"",
                    ""issues_url"": ""https://api.github.com/repos/Sh0wdown/UnofficialCrusaderPatch/issues{/number}"",
                    ""pulls_url"": ""https://api.github.com/repos/Sh0wdown/UnofficialCrusaderPatch/pulls{/number}"",
                    ""milestones_url"": ""https://api.github.com/repos/Sh0wdown/UnofficialCrusaderPatch/milestones{/number}"",
                    ""notifications_url"": ""https://api.github.com/repos/Sh0wdown/UnofficialCrusaderPatch/notifications{?since,all,participating}"",
                    ""labels_url"": ""https://api.github.com/repos/Sh0wdown/UnofficialCrusaderPatch/labels{/name}"",
                    ""releases_url"": ""https://api.github.com/repos/Sh0wdown/UnofficialCrusaderPatch/releases{/id}"",
                    ""deployments_url"": ""https://api.github.com/repos/Sh0wdown/UnofficialCrusaderPatch/deployments"",
                    ""created_at"": ""2018-10-25T21:28:41Z"",
                    ""updated_at"": ""2019-06-12T18:29:58Z"",
                    ""pushed_at"": ""2019-05-19T11:55:27Z"",
                    ""git_url"": ""git://github.com/Sh0wdown/UnofficialCrusaderPatch.git"",
                    ""ssh_url"": ""git@github.com:Sh0wdown/UnofficialCrusaderPatch.git"",
                    ""clone_url"": ""https://github.com/Sh0wdown/UnofficialCrusaderPatch.git"",
                    ""svn_url"": ""https://github.com/Sh0wdown/UnofficialCrusaderPatch"",
                    ""homepage"": null,
                    ""size"": 11791,
                    ""stargazers_count"": 106,
                    ""watchers_count"": 106,
                    ""language"": ""C#"",
                    ""has_issues"": true,
                    ""has_projects"": true,
                    ""has_downloads"": true,
                    ""has_wiki"": true,
                    ""has_pages"": false,
                    ""forks_count"": 16,
                    ""mirror_url"": null,
                    ""archived"": false,
                    ""disabled"": false,
                    ""open_issues_count"": 211,
                    ""license"": {
                        ""key"": ""mit"",
                        ""name"": ""MIT License"",
                        ""spdx_id"": ""MIT"",
                        ""url"": ""https://api.github.com/licenses/mit"",
                        ""node_id"": ""MDc6TGljZW5zZTEz""
                    },
                    ""forks"": 16,
                    ""open_issues"": 211,
                    ""watchers"": 106,
                    ""default_branch"": ""master"",
                    ""score"": 100.10059
                }
            ]
        }";

            #endregion

            [Fact]
            public async Task JsonTestWithReadAsAsync()
            {
                var result = default(SearchRepoJsonRoot.RootResult);
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("C# App");
                var response = await httpClient.GetAsync("https://api.github.com/search/repositories?q=UnofficialCrusaderPatchin:name");
                response.EnsureSuccessStatusCode();
//                var result = await response.Content.ReadAsAsync<SearchRepoJsonRoot.RootResult>();
                if (response.IsSuccessStatusCode)
                {
                    await response.Content.ReadAsStringAsync().ContinueWith(x =>
                    {
                        if (typeof(SearchRepoJsonRoot.RootResult).Namespace != "System")
                        {
                            result = JsonConvert.DeserializeObject<SearchRepoJsonRoot.RootResult>(x?.Result);
//                            Assert.Equal(json, x?.Result);

                        }
                        else
                            result = (SearchRepoJsonRoot.RootResult) Convert.ChangeType(x?.Result,
                                typeof(SearchRepoJsonRoot.RootResult));
                    }, CancellationToken.None);
                }

                Assert.Equal("git://github.com/Sh0wdown/UnofficialCrusaderPatch.git", result.Items.First().GitUrl);
                Assert.Equal("UnofficialCrusaderPatch", result.Items.First().Name);
                Assert.Equal("Sh0wdown", result.Items.First().Owner.Login);
                Assert.Equal(9576090, result.Items.First().Owner.Id);
            }

            
            [Fact]
            public async Task JsonTestWithDtoRootResult()
            {
                var result = default(SearchRepoDto);
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("C# App");
                var response = await httpClient.GetAsync("https://api.github.com/search/repositories?q=UnofficialCrusaderPatchin:name");
                response.EnsureSuccessStatusCode();
//                var result = await response.Content.ReadAsAsync<SearchRepoJsonRoot.RootResult>();
                if (response.IsSuccessStatusCode)
                {
                    await response.Content.ReadAsStringAsync().ContinueWith(x =>
                    {
                        if (typeof(SearchRepoDto).Namespace != "System")
                        {
                            result = JsonConvert.DeserializeObject<SearchRepoDto>(x?.Result);
//                            Assert.Equal(json, x?.Result);

                        }
                        else
                            result = (SearchRepoDto) Convert.ChangeType(x?.Result,
                                typeof(SearchRepoDto));
                    }, CancellationToken.None);
                }

                Assert.Equal("git://github.com/Sh0wdown/UnofficialCrusaderPatch.git", result.Items.First().GitUrl);
                Assert.Equal("UnofficialCrusaderPatch", result.Items.First().Name);
                Assert.Equal("Sh0wdown", result.Items.First().Owner.Login);
                Assert.Equal(9576090, result.Items.First().Owner.Id);
            }
                
        }

        #endregion

        #region IntegrationTest

        #region GetMethode

        public class GetMethode
        {
            [Fact]
            public async Task GetSearchResponseWithRepositoryName()
            {
                var gitHubRestService = new GitHubRestService();
                var searchRepo = await gitHubRestService.Search.SearchRepo("Tour of Heroes");

                Assert.IsType<SearchRepoDto>(searchRepo);
                Assert.True(searchRepo.TotalCount > 2);
            }
        }

        #endregion

        #endregion
    }
}