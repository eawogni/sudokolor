using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Sudoku.Droid;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.IO;
using Android.Media;

namespace Sudoku.Droid
{
    /// <summary>
    /// Classe du menu principale
    /// </summary>
    [Activity(Label = "SudoKolor", MainLauncher = true, Icon = "@drawable/logo", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : Activity
    {
        protected MediaPlayer player;
        /// <summary>
        /// constructeur
        /// </summary>
        /// <param name="bundle"></param>
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            ActionBar.Hide();

            SetContentView(Resource.Layout.Main);
            Button buttonPlay = FindViewById<Button>(Resource.Id.buttonPlay);
            Button buttonSettings = FindViewById<Button>(Resource.Id.buttonSettings);
            Button buttonHelps = FindViewById<Button>(Resource.Id.buttonHelps);
            Button buttonSaved = FindViewById<Button>(Resource.Id.buttonSaved);

            buttonPlay.Click += Play;
            buttonSettings.Click += Settings;
            buttonHelps.Click += Helps;
            buttonSaved.Click += Saved;

            StartPlayer();
        }

        public void StartPlayer()
        {
            if (player == null)
            {
                player = MediaPlayer.Create(this, Resource.Raw.neigequitombe);
                player.Looping = true;
                player.Start();
            }
            else
            {
                
            }
        }

        public static Object sharedObject;
        private void Saved(object sender, EventArgs e)
        {

            if (FichierExiste("maSauvegarde.xml") != false)
            {
                var second = new Intent(this, typeof(Play));
                second.PutExtra("Existe", "Oui");
               
                StartActivity(second);
            }
            else
            {
               
                var second = new Intent(this, typeof(Play));
                second.PutExtra("Existe", "Non");
                StartActivity(second);
             

            }

        }

        private void Helps(object sender, EventArgs e)
        {
            StartActivity(typeof(Helps));
        }
        public bool FichierExiste(string filepath)
        {
            bool newInstance = false;
            string RootPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            XmlSerializer serializer = new XmlSerializer(typeof(Sudokolor));// initialise le sérialiser
            System.IO.Stream reader = new FileStream(RootPath + "/" + filepath, FileMode.OpenOrCreate); //initialise le reader           
            if (reader.Length > 0)
            {
                newInstance = true;
            }

            reader.Close(); //ferme le reader

            return newInstance;
        }
        private void Settings(object sender, EventArgs e)
        {
            var myIntent = new Intent(this, typeof(Settings));
            StartActivityForResult(myIntent,0);
            
        }

        private void Play(object sender, EventArgs e)
        {
            StartActivity(typeof(Play));
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (resultCode == Result.Ok)
            {
                if (data.GetStringExtra("data") == "N")
                {
                    player.Pause();
                   
                }
                else if ((data.GetStringExtra("data") == "Y"))
                {
                    player.Start();
                }
            }
        }
    }
}


