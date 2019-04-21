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

namespace Sudoku.Droid
{
    /// <summary>
    /// Classe qui gère l'écran d'aide
    /// </summary>
    [Activity(Label = "Helps", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    class Helps : Activity
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="savedInstanceState"></param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            ActionBar.Hide();

            SetContentView(Resource.Layout.Help);

        }
    }
}