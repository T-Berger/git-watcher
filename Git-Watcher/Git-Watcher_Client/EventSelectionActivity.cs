using Android.App;
using Android.OS;
using Android.Support.V7.App;

namespace Git_Watcher_Client
{
    [Activity(Label = "event_selection")]
    public class EventSelectionActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.event_selection);
        }

        public override void OnBackPressed()
        {
            StartActivity(typeof(MainActivity));
        }
    }
}