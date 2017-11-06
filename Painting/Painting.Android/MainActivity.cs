using System;
using System.IO;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using static Android.Views.View;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;

namespace Painting.Droid
{
	[Activity (Label = "Painting.Android", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
    {
        XData data = new XData();
        DrawerLayout drawerLayout;
        NavigationView navigationView;

        protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Drawing);
            FindViewById<DrawView>(Resource.Id.drawFiheld).data = data;
            SetToolbar();
            //SetSpinnersListeners();       
        }


        private void SetToolbar()
        {
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            ActionBar.Title = "";
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menus, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch(item.TitleFormatted.ToString())
            {
                case "Save":
                    try
                    {
                        FileSO.Save();
                        Toast.MakeText(this, "Saved", ToastLength.Short).Show();
                    }
                    catch (Exception e)
                    {
                        Toast.MakeText(this, "Saving failed ", ToastLength.Short).Show();
                    }
                    break;
                case "Load":
                    try
                    {
                        FileSO.Load();
                        Toast.MakeText(this, "Loaded succesfully", ToastLength.Short).Show();
                    }
                    catch (Exception e)
                    {
                        Toast.MakeText(this, "Loading failed ", ToastLength.Short).Show();
                    }
                    break;
                case "Settings":
                    try
                    {
                       StartActivity(typeof(SettingsActivity));
                    }
                    catch (Exception e)
                    {
                        Toast.MakeText(this, e.ToString(), ToastLength.Short).Show();
                    }
                    break;
                default:
                    Toast.MakeText(this, "Coming soon: " + item.TitleFormatted,ToastLength.Short).Show();
                    break;
            }
            return base.OnOptionsItemSelected(item);
        }

        private void Save()
        {
            try
            {
                var documents = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
                var filePath = System.IO.Path.Combine(documents, DateTime.UtcNow + ".txt");
                if (!System.IO.File.Exists(filePath))
                {
                    using (System.IO.StreamWriter write = new System.IO.StreamWriter(filePath, true))
                    {
                        write.Write(data.Color.ToString() + data.Type.ToString() + data.Width.ToString());
                    }
                }
                Toast.MakeText(this, "Saved", ToastLength.Short).Show();
            }
            catch (Exception e)
            {
                Toast.MakeText(this, "Saving failed " + e.ToString(), ToastLength.Short).Show();
            }
        }

        /*private void SetSpinnersListeners()
        {
            Spinner spColor = FindViewById<Spinner>(Resource.Id.spColor);
            Spinner spWidth = FindViewById<Spinner>(Resource.Id.spWidth);
            Spinner spType = FindViewById<Spinner>(Resource.Id.spType);
         
            var adapterC = ArrayAdapter.CreateFromResource(this, Resource.Array.color_array, Android.Resource.Layout.SimpleSpinnerItem);
            adapterC.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spColor.Adapter = adapterC;

            var adapterW = ArrayAdapter.CreateFromResource(this, Resource.Array.width_array, Android.Resource.Layout.SimpleSpinnerItem);
            adapterW.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spWidth.Adapter = adapterW;

            var adapterT = ArrayAdapter.CreateFromResource(this, Resource.Array.type_array, Android.Resource.Layout.SimpleSpinnerItem);
            adapterT.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spType.Adapter = adapterT;

            spColor.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            spType.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            spWidth.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
        }*/

        

        /*private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            if(spinner.Id == Resource.Id.spColor)
            {
                switch(spinner.SelectedItem.ToString())
                {
                    case "Red": data.Color = Color.Red; break;
                    case "Blue": data.Color = Color.Blue; break;
                    case "Black": data.Color = Color.Black; break;
                }
            }
            else if (spinner.Id == Resource.Id.spWidth)
            {
                data.Width = Convert.ToInt32(spinner.SelectedItem.ToString());
            }
            else if (spinner.Id == Resource.Id.spType)
            {
                switch (spinner.SelectedItem.ToString())
                {
                    case "Curve": data.Type = Figure.FType.Curve; break;
                    case "Rect": data.Type = Figure.FType.Rect; break;
                    case "Ellipse": data.Type = Figure.FType.Ellipse; break;
                    case "Line": data.Type = Figure.FType.Line; break;
                }
            }
        }*/
    }
}


