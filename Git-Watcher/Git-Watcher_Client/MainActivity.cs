using System;
using System.Threading.Tasks;
using Android;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Octokit;
using PCLStorage;

namespace Git_Watcher_Client
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            Button loginBtn = FindViewById<Button>(Resource.Id.loginBtn);
            loginBtn.Click += OnLoginBtnClick;

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);
            drawer.AddDrawerListener(toggle);
            toggle.SyncState();

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this);
        }



        public override void OnBackPressed()
        {
            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            if(drawer.IsDrawerOpen(GravityCompat.Start))
            {
                drawer.CloseDrawer(GravityCompat.Start);
            }
            else
            {
                base.OnBackPressed();
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }


        private async void OnLoginBtnClick(object sender, EventArgs eventArgs)
        {
            EditText email = FindViewById<EditText>(Resource.Id.emailTxt);
            EditText password = FindViewById<EditText>(Resource.Id.passwordTxt);
            if (string.IsNullOrEmpty(email.Text))
            {
                return;
            }
            GitHubClient gitHubClient = new GitHubClient(new ProductHeaderValue("Git-Watcher"));
            Credentials cred = new Credentials(email.Text, password.Text);
            gitHubClient.Connection.Credentials = cred;
            try
            {
                var user = await gitHubClient.User.Current();
                //var res = await gitHubClient.GitHubApps.CreateInstallationToken(42);
                //SaveUserData(res.Token, user.Login);
                View view = (View)sender;
                Snackbar.Make(view, $"Authentication Successfull!! Welcome {user.Login}", Snackbar.LengthLong)
                    .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
            } catch(Exception e)
            {
                View view = (View)sender;
                Snackbar.Make(view, "Could not authenticate user", Snackbar.LengthLong)
                    .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
            }
        }
        private async void SaveUserData(string token, string username)
        {
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder folder = await rootFolder.CreateFolderAsync("UserData",
                CreationCollisionOption.OpenIfExists);
            IFile file = await folder.CreateFileAsync("answer.txt",
                CreationCollisionOption.ReplaceExisting);
            await file.WriteAllTextAsync($"user:{username};token:{token}");
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            int id = item.ItemId;

            if (id == Resource.Id.nav_notification)
            {
                // Handle the camera action
            }
            else if (id == Resource.Id.nav_myrepo)
            {

            }
            else if (id == Resource.Id.nav_watching)
            {

            }
            else if (id == Resource.Id.nav_issues)
            {

            }
            else if (id == Resource.Id.nav_logout)
            {

            }

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            drawer.CloseDrawer(GravityCompat.Start);
            return true;
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

