using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Git_Watcher_Client.ApiCaller;
using Git_Watcher_Client.Models;

namespace Git_Watcher_Client
{
    [Activity(Label = "issues")]
    public class IssueActivity : AppCompatActivity
    {
        ListView _list;
        List<Issue> _issuses;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.issues);

            _list = FindViewById<ListView>(Resource.Id.issuesList);

            var newIssues= makeApiCall();

            fillList(newIssues);
        }

        public override void OnBackPressed()
        {
            StartActivity(typeof(MainActivity));
        }
        private void fillList(Task<List<Issue>> newIssues)
        {

            _issuses = new List<Issue>();
            foreach (var issue in newIssues.Result)
            {
                _issuses.Add(issue);
            }
            
            _list.Adapter = new ArrayAdapter<Issue>(this, Android.Resource.Layout.SimpleListItem1, _issuses);
        }
        private Task<List<Issue>> makeApiCall()
        {
            WatcherBackendCalls caller = new WatcherBackendCalls(this);
            return caller.GetNewIssues();
        }
    }
}