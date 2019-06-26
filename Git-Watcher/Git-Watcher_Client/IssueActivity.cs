using Android.App;
using Android.OS;
using Android.Support.V7.App;

namespace Git_Watcher_Client
{
    [Activity(Label = "issues")]
    public class IssueActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.issues);
        }

        public override void OnBackPressed()
        {
            StartActivity(typeof(MainActivity));
        }
    }
}