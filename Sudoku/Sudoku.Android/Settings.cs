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
using Sudoku.Droid;

namespace Sudoku.Droid
{
    /// <summary>
    /// Ecran Settings
    /// </summary>
    [Activity(Label = "Settings", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class Settings : Activity
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="savedInstanceState"></param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            ActionBar.Hide();

            SetContentView(Resource.Layout.Set);

            Switch s = FindViewById<Switch>(Resource.Id.switchM);

            s.CheckedChange += delegate (object sender, CompoundButton.CheckedChangeEventArgs e) {
                Intent myIntent = new Intent(this, typeof(MainActivity));
                myIntent.PutExtra("data",(e.IsChecked ? "Y" : "N"));
                var toast = Toast.MakeText(this, "Your change will be applied when returning to the main menu", ToastLength.Short);
                toast.Show();
                SetResult(Result.Ok, myIntent);
               
            };

        }


    }
}