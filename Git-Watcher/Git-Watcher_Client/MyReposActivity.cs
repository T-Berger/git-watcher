using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using System.Collections.Generic;
using System.Threading.Tasks;
using Git_Watcher_Client.Dto;

namespace Git_Watcher_Client
{
    [Activity(Label = "my_repos")]
    public class MyReposActivity : AppCompatActivity
    {
        ListView _list;
        List<RepositoryDto> _items;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.my_repos);

            _list = FindViewById<ListView>(Resource.Id.myRepoList);

            // Give Repos
            long[] repoIds = new long[]{154739983, 154739983};
            makeApiCall(repoIds);
        }

        public override void OnBackPressed()
        {
            StartActivity(typeof(MainActivity));
        }

        
        private async void makeApiCall(long[] repoIds)
        {
            var gitHubRestService = new GitHubRestService();
            
            _items = new List<RepositoryDto>();
            foreach (var id in repoIds)
            {
                var item = gitHubRestService.Repository.Get(id);
                _items.Add(item.Result);
            }

            _list.Adapter = new ArrayAdapter<RepositoryDto>(this, Android.Resource.Layout.SimpleListItem1, _items);
        }
    }
}