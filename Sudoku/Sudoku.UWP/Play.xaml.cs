using NotificationsExtensions.ToastContent;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Windows.UI.Popups;
using Windows.UI.Core;
// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace Sudoku.UWP
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    [DataContract]
    public sealed partial class Play : Page
    {
        private MusicP mP = new MusicP();
        private Sudokolor game;
        [DataMember]
        public Sudokolor Game
        {
            get { return this.game; }
            set { game = value; }
        }
        /// <summary>
        /// Ce constructeur est utilisé dans la page "PLAY"
        /// </summary>
        public Play()
        {
            Game = new Sudokolor();
            this.InitializeComponent();
            this.RemplirGrid();
            
        }
        /// <summary>
        /// Ce conscruteur est utilisé dans la page "SAVE"
        /// </summary>
        /// <param name="myGame"></param>
        public Play(Sudokolor myGame)
        {
            Game = myGame;
            this.InitializeComponent();
            this.RemplirGrid();
            
        }
        /// <summary>
        /// Cette fonction à pour objectif de remplir la matrice en l'initialisant avec les couleurs.
        /// </summary>
        public void RemplirGrid()
        {
            
            for (int i = 0; i < Grille.Children.ToArray().Length; i++)
            {
                if (Grille.Children.ToArray()[i] is Image img)
                {
                    int x = Grid.GetRow(img);
                    int y = Grid.GetColumn(img);
                   
                    int couleur = Game.GetMatrice(x, y).Valeur;
                    if (Game.GetMatrice(x, y).Modifiable == false)
                    {

                        switch (couleur)
                        {
                            case 1:
                                {
                                    img.Source = new BitmapImage(new Uri("ms-appx:///Assets/c1.png"));
                                    break;
                                }
                            case 2:
                                {
                                    img.Source = new BitmapImage(new Uri("ms-appx:///Assets/c2.png"));
                                    break;
                                }
                            case 3:
                                {
                                    img.Source = new BitmapImage(new Uri("ms-appx:///Assets/c3.png"));
                                    break;
                                }
                            case 4:
                                {
                                    img.Source = new BitmapImage(new Uri("ms-appx:///Assets/c4.png"));
                                    break;
                                }
                            case 5:
                                {
                                    img.Source = new BitmapImage(new Uri("ms-appx:///Assets/c5.png"));
                                    break;
                                }
                            case 6:
                                {
                                    img.Source = new BitmapImage(new Uri("ms-appx:///Assets/c6.png"));
                                    break;
                                }
                            case 7:
                                {
                                    img.Source = new BitmapImage(new Uri("ms-appx:///Assets/c7.png"));
                                    break;
                                }
                            case 8:
                                {
                                    img.Source = new BitmapImage(new Uri("ms-appx:///Assets/c8.png"));
                                    break;
                                }
                            case 9:
                                {
                                    img.Source = new BitmapImage(new Uri("ms-appx:///Assets/c9.png"));
                                    break;
                                }
                            default:
                                {
                                    break;
                                }

                        }
                    }
                    else
                    {
                        switch (couleur)
                        {
                            case 0:
                                {
                                    img.Source = new BitmapImage(new Uri("ms-appx:///Assets/caseVoid.png"));
                                    break;
                                }
                            case 1:
                                {
                                    img.Source = new BitmapImage(new Uri("ms-appx:///Assets/cm1.png"));
                                    break;
                                }
                            case 2:
                                {
                                    img.Source = new BitmapImage(new Uri("ms-appx:///Assets/cm2.png"));
                                    break;
                                }
                            case 3:
                                {
                                    img.Source = new BitmapImage(new Uri("ms-appx:///Assets/cm3.png"));
                                    break;
                                }
                            case 4:
                                {
                                    img.Source = new BitmapImage(new Uri("ms-appx:///Assets/cm4.png"));
                                    break;
                                }
                            case 5:
                                {
                                    img.Source = new BitmapImage(new Uri("ms-appx:///Assets/cm5.png"));
                                    break;
                                }
                            case 6:
                                {
                                    img.Source = new BitmapImage(new Uri("ms-appx:///Assets/cm6.png"));
                                    break;
                                }
                            case 7:
                                {
                                    img.Source = new BitmapImage(new Uri("ms-appx:///Assets/cm7.png"));
                                    break;
                                }
                            case 8:
                                {
                                    img.Source = new BitmapImage(new Uri("ms-appx:///Assets/cm8.png"));
                                    break;
                                }
                            case 9:
                                {
                                    img.Source = new BitmapImage(new Uri("ms-appx:///Assets/cm9.png"));
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
        /// <summary>
        /// méthode associée au clic d'une case de la grille et qui permet de changer la couleur de la case(si elle est modifiable) 
        /// cliquée en celle de la couleur sélectionnée depuis la palette
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangerCouleur(object sender, TappedRoutedEventArgs e)
        {
            if (sender is Image img)
            {
                int x = Grid.GetRow(img);
                int y = Grid.GetColumn(img);

                if (this.Game.MMatrice(x, y))// si la case associé à ces cordonnées est est une case modifiable
                {
                    //on modifie la couleur de cette case pour qu'elle ait la couleur selectionnée (on recupère cette couleur sélectionnée par le joueur)
                   
                    int couleur = this.Game.SetMatrice(x, y); 

                    //Modification également du coté ihm

                    switch (couleur)
                    {
                        case 1:
                            {

                                img.Source = new BitmapImage(new Uri("ms-appx:///Assets/cm1.png"));
                                break;
                            }
                        case 2:
                            {
                                img.Source = new BitmapImage(new Uri("ms-appx:///Assets/cm2.png"));
                                break;
                            }
                        case 3:
                            {
                                img.Source = new BitmapImage(new Uri("ms-appx:///Assets/cm3.png"));
                                break;
                            }
                        case 4:
                            {
                                img.Source = new BitmapImage(new Uri("ms-appx:///Assets/cm4.png"));
                                break;
                            }
                        case 5:
                            {
                                img.Source = new BitmapImage(new Uri("ms-appx:///Assets/cm5.png"));
                                break;
                            }
                        case 6:
                            {
                                img.Source = new BitmapImage(new Uri("ms-appx:///Assets/cm6.png"));
                                break;
                            }
                        case 7:
                            {

                                img.Source = new BitmapImage(new Uri("ms-appx:///Assets/cm7.png"));
                                break;
                            }
                        case 8:
                            {
                                img.Source = new BitmapImage(new Uri("ms-appx:///Assets/cm8.png"));
                                break;
                            }
                        case 9:
                            {
                                img.Source = new BitmapImage(new Uri("ms-appx:///Assets/cm9.png"));
                                break;
                            }
                        case 0:
                            {
                                img.Source = new BitmapImage(new Uri("ms-appx:///Assets/caseVoid.png"));
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
        /// <summary>
        /// les événements associés à chaque boutton de la palette qui permettent de modifier la valeur de la propriété 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_Couleur9(object sender, RoutedEventArgs e)
        {
            ImageBrush brush1 = new ImageBrush();
            ImageBrush brush2 = new ImageBrush();
            ImageBrush brush3 = new ImageBrush();
            ImageBrush brush4 = new ImageBrush();
            ImageBrush brush5 = new ImageBrush();
            ImageBrush brush6 = new ImageBrush();
            ImageBrush brush7 = new ImageBrush();
            ImageBrush brush8 = new ImageBrush();
            ImageBrush brush9 = new ImageBrush();
            ImageBrush brush0 = new ImageBrush();
            brush1.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/c9.png"));
            bt_c9.Background = brush1;
            brush2.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm8.png"));
            bt_c8.Background = brush2;
            brush3.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm7.png"));
            bt_c7.Background = brush3;
            brush4.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm6.png"));
            bt_c6.Background = brush4;
            brush5.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm5.png"));
            bt_c5.Background = brush5;
            brush6.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm4.png"));
            bt_c4.Background = brush6;
            brush7.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm3.png"));
            bt_c3.Background = brush7;
            brush8.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm2.png"));
            bt_c2.Background = brush8;
            brush9.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm1.png"));
            b_c1.Background = brush9;
            brush0.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/caseVoid.png"));
            bt_c0.Background = brush0;
            this.Game.SelectC = 9;
        }
        /// <summary>
        /// les événements associés à chaque boutton de la palette qui permettent de modifier la valeur de la propriété 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_Couleur8(object sender, RoutedEventArgs e)
        {
            ImageBrush brush1 = new ImageBrush();
            ImageBrush brush2 = new ImageBrush();
            ImageBrush brush3 = new ImageBrush();
            ImageBrush brush4 = new ImageBrush();
            ImageBrush brush5 = new ImageBrush();
            ImageBrush brush6 = new ImageBrush();
            ImageBrush brush7 = new ImageBrush();
            ImageBrush brush8 = new ImageBrush();
            ImageBrush brush9 = new ImageBrush();
            ImageBrush brush0 = new ImageBrush();
            brush1.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm9.png"));
            bt_c9.Background = brush1;
            brush2.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/c8.png"));
            bt_c8.Background = brush2;
            brush3.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm7.png"));
            bt_c7.Background = brush3;
            brush4.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm6.png"));
            bt_c6.Background = brush4;
            brush5.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm5.png"));
            bt_c5.Background = brush5;
            brush6.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm4.png"));
            bt_c4.Background = brush6;
            brush7.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm3.png"));
            bt_c3.Background = brush7;
            brush8.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm2.png"));
            bt_c2.Background = brush8;
            brush9.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm1.png"));
            b_c1.Background = brush9;
            brush0.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/caseVoid.png"));
            bt_c0.Background = brush0;
            this.Game.SelectC = 8;

        }
        /// <summary>
        /// les événements associés à chaque boutton de la palette qui permettent de modifier la valeur de la propriété 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_Couleur7(object sender, RoutedEventArgs e)
        {
            ImageBrush brush1 = new ImageBrush();
            ImageBrush brush2 = new ImageBrush();
            ImageBrush brush3 = new ImageBrush();
            ImageBrush brush4 = new ImageBrush();
            ImageBrush brush5 = new ImageBrush();
            ImageBrush brush6 = new ImageBrush();
            ImageBrush brush7 = new ImageBrush();
            ImageBrush brush8 = new ImageBrush();
            ImageBrush brush9 = new ImageBrush();
            ImageBrush brush0 = new ImageBrush();
            brush1.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm9.png"));
            bt_c9.Background = brush1;
            brush2.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm8.png"));
            bt_c8.Background = brush2;
            brush3.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/c7.png"));
            bt_c7.Background = brush3;
            brush4.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm6.png"));
            bt_c6.Background = brush4;
            brush5.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm5.png"));
            bt_c5.Background = brush5;
            brush6.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm4.png"));
            bt_c4.Background = brush6;
            brush7.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm3.png"));
            bt_c3.Background = brush7;
            brush8.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm2.png"));
            bt_c2.Background = brush8;
            brush9.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm1.png"));
            b_c1.Background = brush9;
            brush0.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/caseVoid.png"));
            bt_c0.Background = brush0;
            this.Game.SelectC = 7;
        }
        /// <summary>
        /// les événements associés à chaque boutton de la palette qui permettent de modifier la valeur de la propriété 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_Couleur6(object sender, RoutedEventArgs e)
        {
            ImageBrush brush1 = new ImageBrush();
            ImageBrush brush2 = new ImageBrush();
            ImageBrush brush3 = new ImageBrush();
            ImageBrush brush4 = new ImageBrush();
            ImageBrush brush5 = new ImageBrush();
            ImageBrush brush6 = new ImageBrush();
            ImageBrush brush7 = new ImageBrush();
            ImageBrush brush8 = new ImageBrush();
            ImageBrush brush9 = new ImageBrush();
            ImageBrush brush0 = new ImageBrush();
            brush1.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm9.png"));
            bt_c9.Background = brush1;
            brush2.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm8.png"));
            bt_c8.Background = brush2;
            brush3.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm7.png"));
            bt_c7.Background = brush3;
            brush4.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/c6.png"));
            bt_c6.Background = brush4;
            brush5.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm5.png"));
            bt_c5.Background = brush5;
            brush6.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm4.png"));
            bt_c4.Background = brush6;
            brush7.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm3.png"));
            bt_c3.Background = brush7;
            brush8.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm2.png"));
            bt_c2.Background = brush8;
            brush9.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm1.png"));
            b_c1.Background = brush9;
            brush0.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/caseVoid.png"));
            bt_c0.Background = brush0;
            this.Game.SelectC = 6;
        }
        /// <summary>
        /// les événements associés à chaque boutton de la palette qui permettent de modifier la valeur de la propriété 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_Couleur5(object sender, RoutedEventArgs e)
        {
            ImageBrush brush1 = new ImageBrush();
            ImageBrush brush2 = new ImageBrush();
            ImageBrush brush3 = new ImageBrush();
            ImageBrush brush4 = new ImageBrush();
            ImageBrush brush5 = new ImageBrush();
            ImageBrush brush6 = new ImageBrush();
            ImageBrush brush7 = new ImageBrush();
            ImageBrush brush8 = new ImageBrush();
            ImageBrush brush9 = new ImageBrush();
            ImageBrush brush0 = new ImageBrush();
            brush1.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm9.png"));
            bt_c9.Background = brush1;
            brush2.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm8.png"));
            bt_c8.Background = brush2;
            brush3.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm7.png"));
            bt_c7.Background = brush3;
            brush4.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm6.png"));
            bt_c6.Background = brush4;
            brush5.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/c5.png"));
            bt_c5.Background = brush5;
            brush6.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm4.png"));
            bt_c4.Background = brush6;
            brush7.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm3.png"));
            bt_c3.Background = brush7;
            brush8.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm2.png"));
            bt_c2.Background = brush8;
            brush9.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm1.png"));
            b_c1.Background = brush9;
            brush0.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/caseVoid.png"));
            bt_c0.Background = brush0;
            this.Game.SelectC = 5;
        }
        /// <summary>
        /// les événements associés à chaque boutton de la palette qui permettent de modifier la valeur de la propriété 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_Couleur4(object sender, RoutedEventArgs e)
        {
            ImageBrush brush1 = new ImageBrush();
            ImageBrush brush2 = new ImageBrush();
            ImageBrush brush3 = new ImageBrush();
            ImageBrush brush4 = new ImageBrush();
            ImageBrush brush5 = new ImageBrush();
            ImageBrush brush6 = new ImageBrush();
            ImageBrush brush7 = new ImageBrush();
            ImageBrush brush8 = new ImageBrush();
            ImageBrush brush9 = new ImageBrush();
            ImageBrush brush0 = new ImageBrush();
            brush1.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm9.png"));
            bt_c9.Background = brush1;
            brush2.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm8.png"));
            bt_c8.Background = brush2;
            brush3.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm7.png"));
            bt_c7.Background = brush3;
            brush4.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm6.png"));
            bt_c6.Background = brush4;
            brush5.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm5.png"));
            bt_c5.Background = brush5;
            brush6.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/c4.png"));
            bt_c4.Background = brush6;
            brush7.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm3.png"));
            bt_c3.Background = brush7;
            brush8.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm2.png"));
            bt_c2.Background = brush8;
            brush9.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm1.png"));
            b_c1.Background = brush9;
            brush0.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/caseVoid.png"));
            bt_c0.Background = brush0;
            this.Game.SelectC = 4;
        }
        /// <summary>
        /// les événements associés à chaque boutton de la palette qui permettent de modifier la valeur de la propriété 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_Couleur3(object sender, RoutedEventArgs e)
        {
            ImageBrush brush1 = new ImageBrush();
            ImageBrush brush2 = new ImageBrush();
            ImageBrush brush3 = new ImageBrush();
            ImageBrush brush4 = new ImageBrush();
            ImageBrush brush5 = new ImageBrush();
            ImageBrush brush6 = new ImageBrush();
            ImageBrush brush7 = new ImageBrush();
            ImageBrush brush8 = new ImageBrush();
            ImageBrush brush9 = new ImageBrush();
            ImageBrush brush0 = new ImageBrush();
            brush1.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm9.png"));
            bt_c9.Background = brush1;
            brush2.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm8.png"));
            bt_c8.Background = brush2;
            brush3.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm7.png"));
            bt_c7.Background = brush3;
            brush4.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm6.png"));
            bt_c6.Background = brush4;
            brush5.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm5.png"));
            bt_c5.Background = brush5;
            brush6.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm4.png"));
            bt_c4.Background = brush6;
            brush7.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/c3.png"));
            bt_c3.Background = brush7;
            brush8.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm2.png"));
            bt_c2.Background = brush8;
            brush9.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm1.png"));
            b_c1.Background = brush9;
            brush0.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/caseVoid.png"));
            bt_c0.Background = brush0;
            this.Game.SelectC = 3;
        }
        /// <summary>
        /// les événements associés à chaque boutton de la palette qui permettent de modifier la valeur de la propriété 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_Couleur2(object sender, RoutedEventArgs e)
        {
            ImageBrush brush1 = new ImageBrush();
            ImageBrush brush2 = new ImageBrush();
            ImageBrush brush3 = new ImageBrush();
            ImageBrush brush4 = new ImageBrush();
            ImageBrush brush5 = new ImageBrush();
            ImageBrush brush6 = new ImageBrush();
            ImageBrush brush7 = new ImageBrush();
            ImageBrush brush8 = new ImageBrush();
            ImageBrush brush9 = new ImageBrush();
            ImageBrush brush0 = new ImageBrush();
            brush1.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm9.png"));
            bt_c9.Background = brush1;
            brush2.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm8.png"));
            bt_c8.Background = brush2;
            brush3.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm7.png"));
            bt_c7.Background = brush3;
            brush4.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm6.png"));
            bt_c6.Background = brush4;
            brush5.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm5.png"));
            bt_c5.Background = brush5;
            brush6.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm4.png"));
            bt_c4.Background = brush6;
            brush7.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm3.png"));
            bt_c3.Background = brush7;
            brush8.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/c2.png"));
            bt_c2.Background = brush8;
            brush9.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm1.png"));
            b_c1.Background = brush9;
            brush0.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/caseVoid.png"));
            bt_c0.Background = brush0;
            this.Game.SelectC = 2;
        }
        /// <summary>
        /// les événements associés à chaque boutton de la palette qui permettent de modifier la valeur de la propriété 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_Couleur1(object sender, RoutedEventArgs e)
        {
            ImageBrush brush1 = new ImageBrush();
            ImageBrush brush2 = new ImageBrush();
            ImageBrush brush3 = new ImageBrush();
            ImageBrush brush4 = new ImageBrush();
            ImageBrush brush5 = new ImageBrush();
            ImageBrush brush6 = new ImageBrush();
            ImageBrush brush7 = new ImageBrush();
            ImageBrush brush8 = new ImageBrush();
            ImageBrush brush9 = new ImageBrush();
            ImageBrush brush0 = new ImageBrush();
            brush1.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm9.png"));
            bt_c9.Background = brush1;
            brush2.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm8.png"));
            bt_c8.Background = brush2;
            brush3.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm7.png"));
            bt_c7.Background = brush3;
            brush4.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm6.png"));
            bt_c6.Background = brush4;
            brush5.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm5.png"));
            bt_c5.Background = brush5;
            brush6.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm4.png"));
            bt_c4.Background = brush6;
            brush7.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm3.png"));
            bt_c3.Background = brush7;
            brush8.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm2.png"));
            bt_c2.Background = brush8;
            brush9.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/c1.png"));
            b_c1.Background = brush9;
            brush0.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/caseVoid.png"));
            bt_c0.Background = brush0;
            this.Game.SelectC = 1;
        }
        /// <summary>
        /// les événements associés à chaque boutton de la palette qui permettent de modifier la valeur de la propriété 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_Couleur0(object sender, RoutedEventArgs e)
        {
            ImageBrush brush1 = new ImageBrush();
            ImageBrush brush2 = new ImageBrush();
            ImageBrush brush3 = new ImageBrush();
            ImageBrush brush4 = new ImageBrush();
            ImageBrush brush5 = new ImageBrush();
            ImageBrush brush6 = new ImageBrush();
            ImageBrush brush7 = new ImageBrush();
            ImageBrush brush8 = new ImageBrush();
            ImageBrush brush9 = new ImageBrush();
            ImageBrush brush0 = new ImageBrush();
            brush1.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm9.png"));
            bt_c9.Background = brush1;
            brush2.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm8.png"));
            bt_c8.Background = brush2;
            brush3.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm7.png"));
            bt_c7.Background = brush3;
            brush4.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm6.png"));
            bt_c6.Background = brush4;
            brush5.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm5.png"));
            bt_c5.Background = brush5;
            brush6.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm4.png"));
            bt_c4.Background = brush6;
            brush7.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm3.png"));
            bt_c3.Background = brush7;
            brush8.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm2.png"));
            bt_c2.Background = brush8;
            brush9.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/cm1.png"));
            b_c1.Background = brush9;
            brush0.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/caseVoidR.png"));
            bt_c0.Background = brush0;
            this.Game.SelectC = 0;
        }

        /// <summary>
        /// Cette fonction nous permet de sérialiser l'objet "GAME" dans un fichier de format .json
        /// </summary>
        /// <typeparam name="Sudokolor"></typeparam>
        /// <param name="ocollection"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static async Task<string> SerelizeDataToJson<Sudokolor>(Sudokolor ocollection, string filename)
        {
            try
            {
                var Folder = Windows.Storage.ApplicationData.Current.LocalFolder;
                var file = await Folder.CreateFileAsync(filename + ".json", CreationCollisionOption.ReplaceExisting);
                var data = await file.OpenStreamForWriteAsync();

                using (StreamWriter r = new StreamWriter(data))
                {
                    var serelizedfile = JsonConvert.SerializeObject(ocollection);
                    r.Write(serelizedfile);

                }
                
                return filename+" "+ Folder.Name;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// On vérifie si le joueur à gagner ou pas
        /// La sauvegarde se fait automatiquement lorsque le joueur clic sur la bouton valider
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Click_bt_VérificationAsync(object sender, RoutedEventArgs e)
        {

            if (!Game.Valider()) //le joueur n'as pas gagné
            {
                var dialog = new MessageDialog("The grid is not correct!");
                await dialog.ShowAsync();
            }
            else //le joueur a gagné
            {
                var dialog = new MessageDialog("Win !");
                await dialog.ShowAsync();

            }
        }
        /// <summary>
        /// Fonction qui se déclanche lors du clic sur le bouton "Save"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void bt_Save_Click(object sender, RoutedEventArgs e)
        {
            await SerelizeDataToJson(game, "maSauvegarde");
            var dialog = new MessageDialog("Saved game");
            await dialog.ShowAsync();

        }
        /// <summary>
        /// Action qui se passe lorsqu'on change de page.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
                var parameters = (List<Object>) e.Parameter;
                if (parameters.Count()>1) // cas ou on arrive sur cette page avec un click sur le bouton saved
                {
                    this.game = (Sudokolor)parameters[0];
                    this.RemplirGrid();

                    MusicP music = (MusicP)parameters[1];
                    this.GestionMusic(music);
                 

            }
            else
            {
                var music = (MusicP)parameters[0];
                this.GestionMusic(music);

            }
                
            

        }

        private void GestionMusic(MusicP music)
        {
           
            mP.Val = music.Val;
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible; //on affiche un boutton retour
            SystemNavigationManager.GetForCurrentView().BackRequested += Courbes_BackRequested; //Action à faire lorsqu'on click sur le boutton retour
            Music();
        }
        /// <summary>
        /// Fonction qui active le bouton de retour en arrière
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

            /**
             * Gestion du boutton retour
             */
        private void Courbes_BackRequested(object sender, BackRequestedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame == null)
                return;
            // Navigate back if possible, and if the event has not
            // already been handled .
            if (rootFrame.CanGoBack && e.Handled == false)
            {
                e.Handled = true;
                rootFrame.GoBack();
            }
        }
        /// <summary>
        /// Fonction qui gère la musique.
        /// </summary>
        public void Music()
        {
            Uri newuri = new Uri("ms-appx:///Assets/neigequitombe.mp3");
            
            myPlayer.Source = newuri;
            myPlayer.IsLooping = true;
            myPlayer.Play();
            if (mP.Val != null)
            {
                if (mP.Val.Equals("N"))
                {
                   
                    myPlayer.Stop();
                   

                }
             
            }
            
        }

       
    }
}

