using Foundation;
using SudoKolor;
using System;
using System.Collections.Generic;
using UIKit;
using System.Runtime.Serialization;


namespace Sudoku.iOS
{
    /**
     * Classe associé ou couplé  controle l'interface de Play
     */

    public partial class PlayyController : UIViewController
    {
        private List<string> listImages;

        private Sudokolor game;
        public PlayyController(IntPtr handle) : base(handle)
        {

        }


        public override void ViewDidLoad()
        {

            base.ViewDidLoad();


            if (ExisteSauvegarde.get().LeJeu != null && ExisteSauvegarde.get().Clickedsaved)
            {
                this.game = ExisteSauvegarde.get().LeJeu;
                ExisteSauvegarde.get().Clickedsaved = false;
            }
            else { this.game = new Sudokolor(); }
            this.listImages = new List<string>();

            this.GénérerLaListeImages();
            //les paramètres de la grille (CollectionView)

            grille.RegisterClassForCell(typeof(Cellule), Cellule.cellId);       //On idique la classe associée aux cellule de notre grille
            grille.DataSource = new AdaptateurCelluleGrille(this.listImages);       //On ajoute les données de à notre grille
            grille.Delegate = new CollectionDelegate(grille, this.game);         //On Indique la classe qui gère les événements de notre grille => le controleur de notre grille

          //  App.AudioManager.PlayBackgroundMusic("shine.mp3");


        }
        public static AppDelegate App
        {
            get { return (AppDelegate)UIApplication.SharedApplication.Delegate; }
        }

        public Sudokolor Game
        {
            get { return this.game; }
            set { this.game = value; }
        }
        /**
         * Permet de remplir la liste des images à charger dans la grille en fonction des dispositions des cases du jeu sudokOlor
         */
        private void GénérerLaListeImages()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Case c = this.game.GetMatrice(i, j);

                    if (c.Modifiable)       //cas pour les cases modifiables
                    {
                        switch (c.Valeur)
                        {
                            case 0:
                                {
                                    this.listImages.Add("caseVoid");
                                    break;
                                }
                            case 1:
                                {
                                    this.listImages.Add("cm1");
                                    break;
                                }
                            case 2:
                                {
                                    this.listImages.Add("cm2");
                                    break;
                                }
                            case 3:
                                {
                                    this.listImages.Add("cm3");
                                    break;
                                }
                            case 4:
                                {
                                    this.listImages.Add("cm4");
                                    break;
                                }
                            case 5:
                                {
                                    this.listImages.Add("cm5");
                                    break;
                                }
                            case 6:
                                {
                                    this.listImages.Add("cm6");
                                    break;
                                }
                            case 7:
                                {
                                    this.listImages.Add("cm7");
                                    break;
                                }
                            case 8:
                                {
                                    this.listImages.Add("cm8");
                                    break;
                                }
                            case 9:
                                {
                                    this.listImages.Add("cm9");
                                    break;
                                }
                            default:
                                {
                                    break;
                                }
                        }
                    }
                    else //cas pour les cases non modifiables
                    {
                        switch (c.Valeur)
                        {

                            case 1:
                                {
                                    this.listImages.Add("c1");
                                    break;
                                }
                            case 2:
                                {
                                    this.listImages.Add("c2");
                                    break;
                                }
                            case 3:
                                {
                                    this.listImages.Add("c3");
                                    break;
                                }
                            case 4:
                                {
                                    this.listImages.Add("c4");
                                    break;
                                }
                            case 5:
                                {
                                    this.listImages.Add("c5");
                                    break;
                                }
                            case 6:
                                {
                                    this.listImages.Add("c6");
                                    break;
                                }
                            case 7:
                                {
                                    this.listImages.Add("c7");
                                    break;
                                }
                            case 8:
                                {
                                    this.listImages.Add("c8");
                                    break;
                                }
                            case 9:
                                {
                                    this.listImages.Add("c9");
                                    break;
                                }
                            default:
                                {
                                    break;
                                }
                        }

                    }
                }
            }




        }


        // liste des événements associés à chacun des bouttons représentant une couleur
        partial void Bt1_TouchUpInside(UIButton sender)
        {

            this.DeselectionPanel();    //on déselecte le button enciennement sélectiooné
            bt1.SetBackgroundImage(UIImage.FromFile("c1"), UIControlState.Normal); // on change l'image de fond pour indiqué qu'il s'agit du nouveau boutton sélectionné
            this.game.SelectC = 1;          // on indique au jeu que le joueur à sélectionné la couleur de valeur  1 ;

        }

        partial void Bt2_TouchUpInside(UIButton sender)
        {
            this.DeselectionPanel();
            bt2.SetBackgroundImage(UIImage.FromFile("c2"), UIControlState.Normal);
            this.game.SelectC = 2;
        }

        partial void Bt3_TouchUpInside(UIButton sender)
        {
            this.DeselectionPanel();
            bt3.SetBackgroundImage(UIImage.FromFile("c3"), UIControlState.Normal);
            this.game.SelectC = 3;
        }

        partial void Bt4_TouchUpInside(UIButton sender)
        {
            this.DeselectionPanel();
            bt4.SetBackgroundImage(UIImage.FromFile("c4"), UIControlState.Normal);
            this.game.SelectC = 4;
        }

        partial void Bt5_TouchUpInside(UIButton sender)
        {
            this.DeselectionPanel();
            bt5.SetBackgroundImage(UIImage.FromFile("c5"), UIControlState.Normal);
            this.game.SelectC = 5;
        }

        partial void Bt6_TouchUpInside(UIButton sender)
        {
            this.DeselectionPanel();
            bt6.SetBackgroundImage(UIImage.FromFile("c6"), UIControlState.Normal);
            this.game.SelectC = 6;
        }

        partial void Bt7_TouchUpInside(UIButton sender)
        {
            this.DeselectionPanel();
            bt7.SetBackgroundImage(UIImage.FromFile("c7"), UIControlState.Normal);
            this.game.SelectC = 7;
        }

        partial void Bt8_TouchUpInside(UIButton sender)
        {
            this.DeselectionPanel();
            bt8.SetBackgroundImage(UIImage.FromFile("c8"), UIControlState.Normal);
            this.game.SelectC = 8;
        }

        partial void Bt9_TouchUpInside(UIButton sender)
        {
            this.DeselectionPanel();
            bt9.SetBackgroundImage(UIImage.FromFile("c9"), UIControlState.Normal);
            this.game.SelectC = 9;
        }

        partial void BtVoid_TouchUpInside(UIButton sender)
        {
            this.DeselectionPanel();
            btVoid.SetBackgroundImage(UIImage.FromFile("caseVoidR"), UIControlState.Normal);
            this.game.SelectC = 0;
        }

        /*
         * Permet de vérifier que le joueur à gagné la partie ou non
         */
        partial void BtValider_TouchUpInside(UIButton sender)
        {


            UIAlertView alert = new UIAlertView();
            alert.Title = "Win ?";
            alert.AddButton("OK");

            if (this.game.Valider())
            {
                {
                    alert.Message = "Win !";
                };


            }
            else
            {
                alert.Message = "The grid is not correct";
            }
            alert.Show();
        }

        /**
         * Permet de remettre la couleur de base du d'un bouton de panel après qu'un autre boutton ait été sélectionné
         */
        public void DeselectionPanel()
        {
            switch (this.game.SelectC)
            {

                case 1:
                    {
                        this.bt1.SetBackgroundImage(UIImage.FromFile("cm1"), UIControlState.Normal);
                        break;
                    }
                case 2:
                    {
                        this.bt2.SetBackgroundImage(UIImage.FromFile("cm2"), UIControlState.Normal);
                        break;
                    }
                case 3:
                    {
                        this.bt3.SetBackgroundImage(UIImage.FromFile("cm3"), UIControlState.Normal);
                        break;
                    }
                case 4:
                    {
                        this.bt4.SetBackgroundImage(UIImage.FromFile("cm4"), UIControlState.Normal);
                        break;
                    }
                case 5:
                    {
                        this.bt5.SetBackgroundImage(UIImage.FromFile("cm5"), UIControlState.Normal);
                        break;
                    }
                case 6:
                    {
                        this.bt6.SetBackgroundImage(UIImage.FromFile("cm6"), UIControlState.Normal);
                        break;
                    }
                case 7:
                    {
                        this.bt7.SetBackgroundImage(UIImage.FromFile("cm7"), UIControlState.Normal);
                        break;
                    }
                case 8:
                    {
                        this.bt8.SetBackgroundImage(UIImage.FromFile("cm8"), UIControlState.Normal);
                        break;
                    }
                case 9:
                    {
                        this.bt9.SetBackgroundImage(UIImage.FromFile("cm9"), UIControlState.Normal);
                        break;
                    }
                case 0:
                    {
                        this.btVoid.SetBackgroundImage(UIImage.FromFile("caseVoid"), UIControlState.Normal);
                        break;
                    }

                default:
                    {
                        break;
                    }
            }



        }

        partial void BtSauver_TouchUpInside(UIButton sender)
        {
            string lien = Environment.CurrentDirectory;

            SudoKolorDataXml sauvegarde = new SudoKolorDataXml(lien + "/" + "maSauvegarde");
            sauvegarde.Sauver(this.game);
            UIAlertView alert = new UIAlertView
            {
                Title = "Back-up",
                Message = "Saved game"

            };
            alert.AddButton("Ok");
            alert.Show();
        }
    }

}