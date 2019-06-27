using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Android.Content;
using Android.Preferences;
using Git_Watcher_Client.Models;
using GitWatcher.ApiModels;
using Newtonsoft.Json;


namespace Git_Watcher_Client.ApiCaller
{
    public class WatcherBackendCalls
    {
        private readonly string baseUrl = "http://git-watcher-backend.azurewebsites.net/api/";
        private readonly HttpClient _client;
        private readonly Guid clientInitKey = new Guid("5A3DA496-4120-4169-8373-339EEBA02B64");
        private readonly Context _context;

        public WatcherBackendCalls(Context context)
        {
            _client = new HttpClient();
            _context = context;
        }

        public async Task<bool> CreateUser(string userName)
        {
                var newUser = new NewBackendUser { UserName = userName, Key = clientInitKey };
                string userString = newUser.ToString();
                var userJson = new StringContent(userString, Encoding.UTF8, "application/json");
                var uri = new Uri(string.Concat(baseUrl, "UserBackend/v1/users", string.Empty));
                var res = await _client.PostAsync(uri, userJson);
                if (res.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    var content = await res.Content.ReadAsStringAsync();
                    content = Regex.Match(content, @"(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}").Value;
                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(_context);
                    ISharedPreferencesEditor editor = prefs.Edit();
                    editor.PutString("ApiKey", content);
                    editor.Apply();
                    return true;
                }
           return false;
        }

        public async Task<List<Issue>> GetNewIssues()
        {
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(_context);
            Guid apiKey = Guid.Empty;
            if (!prefs.Contains("ApiKey"))
                apiKey = Guid.Parse(prefs.GetString("ApiKey", Guid.Empty.ToString()));
            if (apiKey != Guid.Empty)
            {
                var res = await _client.GetAsync(baseUrl + $"RepoApi/v1/Issues?key={apiKey}");
                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string json = await res.Content.ReadAsStringAsync();
                    var issueList = JsonConvert.DeserializeObject<List<Issue>>(json);
                    return issueList;
                }
                return null;
            }
            return null;
        }

        public async Task<bool> Subscribe(string repoID)
        {
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(_context);
            Guid apiKey = Guid.Empty;
            if (prefs.Contains("ApiKey"))
            {
                var apiKeyString = prefs.GetString("ApiKey", Guid.Empty.ToString());
                apiKey = Guid.Parse(apiKeyString);

                if (apiKey != Guid.Empty)
                {
                    var uri = new Uri(string.Concat(baseUrl, "RepoApi/v1/subscriptions"));
                    var subscriptionModel = new SubscriptionApi { ApiKey = apiKey, RepoId = repoID };
                    var content = new StringContent(subscriptionModel.ToString(), Encoding.UTF8, "application/json");
                    var res = await _client.PostAsync(uri, content);
                    if (res.StatusCode == System.Net.HttpStatusCode.Created)
                    {
                        ISharedPreferencesEditor editor = prefs.Edit();
                        var subs = prefs.GetStringSet("Subscriptions", new List<string>());
                        subs.Add(await res.Content.ReadAsStringAsync());
                        editor.PutStringSet("Subscriptions", subs);
                        editor.Apply();
                        return true;
                    }
                }
            }
            return false;
        }

        public async Task<bool> Unsubscribe(Guid subId)
        {
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(_context);
            Guid apiKey = Guid.Empty;
            if (!prefs.Contains("ApiKey"))
                apiKey = Guid.Parse(prefs.GetString("ApiKey", Guid.Empty.ToString()));
            if (apiKey != Guid.Empty)
            {
                var res = await _client.DeleteAsync(baseUrl + $"subscriptions/{subId}");
                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    ISharedPreferencesEditor editor = prefs.Edit();
                    var subs = prefs.GetStringSet("Subscriptions", new List<string>());
                    subs.Remove(subId.ToString());
                    editor.PutStringSet("Subscriptions", subs);
                    editor.Apply();
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}