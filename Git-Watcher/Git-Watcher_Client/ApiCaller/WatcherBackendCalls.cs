using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
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
        //private readonly string baseUrl = "https://git-watcher-backend.azurewebsites.net/api/";
        private readonly string baseUrl = "https://localhost:44329/api/";
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
            var userJson = new StringContent(newUser.ToString(), Encoding.UTF8, "application/json");
            string reqUrl = baseUrl+"UserBackend/v1/createUser";
            var res = await _client.PostAsync(reqUrl, userJson);
            if(res.StatusCode == System.Net.HttpStatusCode.Created)
            {
                var content = res.Content.ToString();
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
            if (!prefs.Contains("UserLogin"))
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
    }
}