using System;

using UIKit;

namespace Sudoku.iOS
{
    public partial class ViewController : UIViewController
    {


        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            //App.AudioManager.PlayBackgroundMusic("neigequitombe.mp3");


        }
        public static AppDelegate App
        {
            get { return (AppDelegate)UIApplication.SharedApplication.Delegate; }
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        partial void BtnSaved_TouchUpInside(UIButton sender)
        {
            ExisteSauvegarde.get().Clickedsaved = true;
            string lien = Environment.CurrentDirectory;
            SudoKolorDataXml sauv = new SudoKolorDataXml(lien + "/" + "maSauvegarde");
            Sudokolor jeu = sauv.Charger();
            if (jeu == null)
            {

                UIAlertView alert = new UIAlertView
                {
                    Title = "Back-up",
                    Message = "You no have backup"

                };
                alert.AddButton("Ok");
                alert.Show();
            }
            else { ExisteSauvegarde.get().LeJeu = jeu; }

        }

     
    }   
}

