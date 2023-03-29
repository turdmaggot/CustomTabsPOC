using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.Snackbar;
using Android.Content;

namespace CustomTabsPOC
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            Android.Widget.Button btnTest = FindViewById<Android.Widget.Button>(Resource.Id.btnTest);
            btnTest.Click += TestOnClick;
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

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (View.IOnClickListener)null).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void TestOnClick(object sender, EventArgs eventArgs)
        {
            try
            {
                Uri uri = new Uri("https://www.youtube.com/watch?v=gZGmDKxEp-I");
                //Uri uri = new Uri("https://www.reinertupaz.com/");
                Android.Net.Uri androidUri = Android.Net.Uri.Parse(uri.ToString());
                var i = new Intent(Intent.ActionView, androidUri);
                i.AddCategory(Intent.CategoryBrowsable);
                i.AddFlags(ActivityFlags.NewTask | ActivityFlags.RequireNonBrowser);
                StartActivity(i);
            }
            catch (Exception ex)
            {
                View view = (View)sender;
                Snackbar.Make(view, "Error!", Snackbar.LengthLong)
                .SetAction("Action", (View.IOnClickListener)null).Show();
            }
        }
    }
}

