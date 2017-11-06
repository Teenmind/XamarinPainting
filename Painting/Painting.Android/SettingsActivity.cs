using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Painting.Droid
{
    [Activity(Label = "Settings", MainLauncher = false)]
    public class SettingsActivity: Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Preferences);
            var back = FindViewById<Button>(Resource.Id.btnBack);
            back.Click += delegate { StartActivity(typeof(MainActivity)); };
            //ActionBar.SetHomeButtonEnabled(true);
            //ActionBar.SetDisplayHomeAsUpEnabled(true);
        }       
    }
}