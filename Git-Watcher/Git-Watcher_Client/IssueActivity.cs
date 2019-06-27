using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using System;
using System.Collections.Generic;

namespace Git_Watcher_Client
{
    [Activity(Label = "issues")]
    public class IssueActivity : AppCompatActivity
    {

        ListView _list;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.issues);

            _list = FindViewById<ListView>(Resource.Id.issuesList);

            makeApiCall();

            fillList();
        }

        public override void OnBackPressed()
        {
            StartActivity(typeof(MainActivity));
        }
        private void fillList()
        {
            List<Resource.String> list = new List<Resource.String>();
            for (int i = 0; i < 10; i++)
            {

                list.Add(<Resource.String>("Item_0" + i));
            }

            _list.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, list);
        }
        private void makeApiCall()
        {

        }
    }
}