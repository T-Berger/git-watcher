using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using System;
using System.Collections.Generic;

namespace Git_Watcher_Client
{
    [Activity(Label = "watching_repos")]
    public class WatchingActivity : AppCompatActivity
    {
        ListView _list;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.watching_repos);

            _list = FindViewById<ListView>(Resource.Id.watchingList);

            makeApiCall();
            fillList();
        }

        public override void OnBackPressed()
        {
            StartActivity(typeof(MainActivity));
        }

        private void fillList()
        {
            List<string> list = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                list.Add("Item_0" + i);
            }

            _list.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, list);
        }

        private void makeApiCall()
        {

        }
    }
}