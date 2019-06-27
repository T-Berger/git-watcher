using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Git_Watcher_Client.ApiCaller;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Git_Watcher_Client
{
    [Activity(Label = "event_selection")]
    public class EventSelectionActivity : AppCompatActivity
    {
        string _repo;
        private string repoId;
        private long id;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.event_selection);

            _repo = Intent.GetStringExtra("Repo") ?? string.Empty;

            Regex regex = new Regex("Id:(.*)\n");
            var regexSting = regex.Match(_repo);
            //Daniel hier ist deine Id
            repoId = regexSting.Groups[1].ToString();
            
            TextView text = FindViewById<TextView>(Resource.Id.eventSelectionRepo);
            text.Text = _repo;
            
            
            Button back = FindViewById<Button>(Resource.Id.eventBackButton);
            Button watch = FindViewById<Button>(Resource.Id.eventWatchButton);

            back.Click += OnBackPressed;
            watch.Click += onWatchClicked;
        }

        public void OnBackPressed(object sender, EventArgs eventArgs)
        {
            StartActivity(typeof(ReposSearchActivity));
        }

        public async void onWatchClicked(object sender, EventArgs eventArgs)
        {
            CheckBox commitBtn = FindViewById<CheckBox>(Resource.Id.eventSelectionCommit);
            bool trackCommit = commitBtn.Checked;

            CheckBox mergeBtn = FindViewById<CheckBox>(Resource.Id.eventSelectionMerge);
            bool trackMerges = mergeBtn.Checked;

            CheckBox issueBtn = FindViewById<CheckBox>(Resource.Id.eventSelectionIssue);
            bool trackIssues = issueBtn.Checked;

            bool res = await callApi(trackIssues, trackCommit, trackMerges);

            if(res)
            {
                StartActivity(typeof(MainActivity));
            }
            else
            {
                //show error message
            }
        }

        private async void onBackClicked(object sender, EventArgs eventArgs)
        {
            StartActivity(typeof(MainActivity));
        }

        private async Task<bool> callApi(bool issue, bool commit, bool merge)
        {
            //TODO: get Repo name
            WatcherBackendCalls caller = new WatcherBackendCalls(this);
            return await caller.Subscribe(_repo);
        }
    }


}