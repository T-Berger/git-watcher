using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using System;
using System.Threading.Tasks;

namespace Git_Watcher_Client
{
    [Activity(Label = "event_selection")]
    public class EventSelectionActivity : AppCompatActivity
    {
        string _repo;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.event_selection);

            _repo = Intent.GetStringExtra("Repo") ?? string.Empty;

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

            bool res = await callApi(trackIssues, trackCommit, trackCommit);

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

        private async Task<Boolean> callApi(bool issue, bool commit, bool merge)
        {
            //TODO: get Repo name
            string repo = _repo;
            //TODO: post to api

            return true;
        }
    }


}