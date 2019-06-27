using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using System;
using System.Collections.Generic;
using Git_Watcher_Client.Dto;

namespace Git_Watcher_Client
{
    [Activity(Label = "reposearch")]
    public class ReposSearchActivity : AppCompatActivity
    {

        ListView _list;
        List<Item> _items;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.reposearch);

            _list = FindViewById<ListView>(Resource.Id.searchRepoList);

            _list.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs e)
            {
                _list.SetItemChecked(e.Position, true);
                object o = _list.GetItemAtPosition(e.Position);
                Console.WriteLine(o.ToString());
                
                var activity = new Intent(this, typeof(EventSelectionActivity));
                activity.PutExtra("Repo", o.ToString());
                StartActivity(activity);
            };

            Button search = FindViewById<Button>(Resource.Id.searchButton);
            search.Click += OnSearchClicked;

//            _items = new List<string>();
        }

        public override void OnBackPressed()
        {
            StartActivity(typeof(MainActivity));
        }

        private async void OnSearchClicked(object sender, EventArgs eventArgs)
        {
            Android.Support.Design.Widget.TextInputEditText field 
                = FindViewById<Android.Support.Design.Widget.TextInputEditText>(Resource.Id.searchRepoInput);
            string text = field.Text;
            makeApiCall(text);
//            fillList();
        }

        private void onItemClicked(object sender, EventArgs eventArgs)
        {
            string item = Convert.ToString(_list.SelectedItem);
            
            StartActivity(typeof(EventSelectionActivity));
        }

//        private void fillList()
//        {
//            _items = new List<string>();
//            for (int i = 0; i < 10; i++)
//            {
//                _items.Add("Item_0" + i);
//            }
//            _list.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, _items);
//        }

        private async void makeApiCall(string reponame)
        {
            var gitHubRestService = new GitHubRestService();
            var searchRepo = await gitHubRestService.Search.SearchRepo(reponame);
            
            _items = new List<Item>();
            foreach (var searchRepoItem in searchRepo.Items)
            {
//                _items.Add("Title:" + searchRepoItem.Name + "\n Description:" +  searchRepoItem.Description + "\n Id:" + searchRepoItem.Id);
                _items.Add(searchRepoItem);
            }
//            for (int i = 0; i < 10; i++)
//            {
//                _items.Add(searchRepo.Items.);
//            }
            _list.Adapter = new ArrayAdapter<Item>(this, Android.Resource.Layout.SimpleListItem1, _items);
        }
    }
}