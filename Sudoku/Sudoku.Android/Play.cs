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
using Android.Graphics;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace Sudoku.Droid
{
    /// <summary>
    /// Classe qui gère le jeu
    /// </summary>
    [Activity(Label = "Play", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class Play : Activity
    {
        Sudokolor game = new Sudokolor();

        private int[] tabImage = new int[81];
        private GridView gridview;
        private int wScreen;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="savedInstanceState"></param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            string result = "N";
            base.OnCreate(savedInstanceState);
            result = Intent.GetStringExtra("Existe") ?? "Aucun donnée !";
           
            if (result == "Oui")
            {
                game = Deserialiser("maSauvegarde.xml");
            }else
                if (result == "Non")
            {
                Toast.MakeText(this, "You no have backup",ToastLength.Long).Show();
            }
           
            ActionBar.Hide();

            SetContentView(Resource.Layout.LPlay);

            RemplirGrid();

            var metrics = Resources.DisplayMetrics;
            int w = (int)(metrics.WidthPixels);
            this.wScreen = w;

            gridview = FindViewById<GridView>(Resource.Id.grille);
            gridview.Adapter = new ImageAdapter(this, this.tabImage, w);
            gridview.ItemClick += Gridview_ItemClick;

            ImageButton b1 = FindViewById<ImageButton>(Resource.Id.b1);
            ImageButton b2 = FindViewById<ImageButton>(Resource.Id.b2);
            ImageButton b3 = FindViewById<ImageButton>(Resource.Id.b3);
            ImageButton b4 = FindViewById<ImageButton>(Resource.Id.b4);
            ImageButton b5 = FindViewById<ImageButton>(Resource.Id.b5);
            ImageButton b6 = FindViewById<ImageButton>(Resource.Id.b6);
            ImageButton b7 = FindViewById<ImageButton>(Resource.Id.b7);
            ImageButton b8 = FindViewById<ImageButton>(Resource.Id.b8);
            ImageButton b9 = FindViewById<ImageButton>(Resource.Id.b9);
            ImageButton b0 = FindViewById<ImageButton>(Resource.Id.b0);// changer les bouton en f(x) de celui actif

            Button bV = FindViewById<Button>(Resource.Id.Valider);
            Button bS = FindViewById<Button>(Resource.Id.Save);

            b1.Click += delegate 
            {
                b1.SetImageResource(Resource.Drawable.c1);
                b2.SetImageResource(Resource.Drawable.cm2);
                b3.SetImageResource(Resource.Drawable.cm3);
                b4.SetImageResource(Resource.Drawable.cm4);
                b5.SetImageResource(Resource.Drawable.cm5);
                b6.SetImageResource(Resource.Drawable.cm6);
                b7.SetImageResource(Resource.Drawable.cm7);
                b8.SetImageResource(Resource.Drawable.cm8);
                b9.SetImageResource(Resource.Drawable.cm9);
                b0.SetImageResource(Resource.Drawable.caseVoid);
                game.SelectC = 1;
            };
            b2.Click += delegate 
            {
                b1.SetImageResource(Resource.Drawable.cm1);
                b2.SetImageResource(Resource.Drawable.c2);
                b3.SetImageResource(Resource.Drawable.cm3);
                b4.SetImageResource(Resource.Drawable.cm4);
                b5.SetImageResource(Resource.Drawable.cm5);
                b6.SetImageResource(Resource.Drawable.cm6);
                b7.SetImageResource(Resource.Drawable.cm7);
                b8.SetImageResource(Resource.Drawable.cm8);
                b9.SetImageResource(Resource.Drawable.cm9);
                b0.SetImageResource(Resource.Drawable.caseVoid);
                game.SelectC = 2;
            };
            b3.Click += delegate 
            {
                b1.SetImageResource(Resource.Drawable.cm1);
                b2.SetImageResource(Resource.Drawable.cm2);
                b3.SetImageResource(Resource.Drawable.c3);
                b4.SetImageResource(Resource.Drawable.cm4);
                b5.SetImageResource(Resource.Drawable.cm5);
                b6.SetImageResource(Resource.Drawable.cm6);
                b7.SetImageResource(Resource.Drawable.cm7);
                b8.SetImageResource(Resource.Drawable.cm8);
                b9.SetImageResource(Resource.Drawable.cm9);
                b0.SetImageResource(Resource.Drawable.caseVoid);
                game.SelectC = 3;
            };
            b4.Click += delegate 
            {
                b1.SetImageResource(Resource.Drawable.cm1);
                b2.SetImageResource(Resource.Drawable.cm2);
                b3.SetImageResource(Resource.Drawable.cm3);
                b4.SetImageResource(Resource.Drawable.c4);
                b5.SetImageResource(Resource.Drawable.cm5);
                b6.SetImageResource(Resource.Drawable.cm6);
                b7.SetImageResource(Resource.Drawable.cm7);
                b8.SetImageResource(Resource.Drawable.cm8);
                b9.SetImageResource(Resource.Drawable.cm9);
                b0.SetImageResource(Resource.Drawable.caseVoid);
                game.SelectC = 4;
            };
            b5.Click += delegate 
            {
                b1.SetImageResource(Resource.Drawable.cm1);
                b2.SetImageResource(Resource.Drawable.cm2);
                b3.SetImageResource(Resource.Drawable.cm3);
                b4.SetImageResource(Resource.Drawable.cm4);
                b5.SetImageResource(Resource.Drawable.c5);
                b6.SetImageResource(Resource.Drawable.cm6);
                b7.SetImageResource(Resource.Drawable.cm7);
                b8.SetImageResource(Resource.Drawable.cm8);
                b9.SetImageResource(Resource.Drawable.cm9);
                b0.SetImageResource(Resource.Drawable.caseVoid);
                game.SelectC = 5;
            };
            b6.Click += delegate 
            {
                b1.SetImageResource(Resource.Drawable.cm1);
                b2.SetImageResource(Resource.Drawable.cm2);
                b3.SetImageResource(Resource.Drawable.cm3);
                b4.SetImageResource(Resource.Drawable.cm4);
                b5.SetImageResource(Resource.Drawable.cm5);
                b6.SetImageResource(Resource.Drawable.c6);
                b7.SetImageResource(Resource.Drawable.cm7);
                b8.SetImageResource(Resource.Drawable.cm8);
                b9.SetImageResource(Resource.Drawable.cm9);
                b0.SetImageResource(Resource.Drawable.caseVoid);
                game.SelectC = 6; };
            b7.Click += delegate 
            {
                b1.SetImageResource(Resource.Drawable.cm1);
                b2.SetImageResource(Resource.Drawable.cm2);
                b3.SetImageResource(Resource.Drawable.cm3);
                b4.SetImageResource(Resource.Drawable.cm4);
                b5.SetImageResource(Resource.Drawable.cm5);
                b6.SetImageResource(Resource.Drawable.cm6);
                b7.SetImageResource(Resource.Drawable.c7);
                b8.SetImageResource(Resource.Drawable.cm8);
                b9.SetImageResource(Resource.Drawable.cm9);
                b0.SetImageResource(Resource.Drawable.caseVoid);
                game.SelectC = 7;
            };
            b8.Click += delegate 
            {
                b1.SetImageResource(Resource.Drawable.cm1);
                b2.SetImageResource(Resource.Drawable.cm2);
                b3.SetImageResource(Resource.Drawable.cm3);
                b4.SetImageResource(Resource.Drawable.cm4);
                b5.SetImageResource(Resource.Drawable.cm5);
                b6.SetImageResource(Resource.Drawable.cm6);
                b7.SetImageResource(Resource.Drawable.cm7);
                b8.SetImageResource(Resource.Drawable.c8);
                b9.SetImageResource(Resource.Drawable.cm9);
                b0.SetImageResource(Resource.Drawable.caseVoid);
                game.SelectC = 8; };
            b9.Click += delegate 
            {
                b1.SetImageResource(Resource.Drawable.cm1);
                b2.SetImageResource(Resource.Drawable.cm2);
                b3.SetImageResource(Resource.Drawable.cm3);
                b4.SetImageResource(Resource.Drawable.cm4);
                b5.SetImageResource(Resource.Drawable.cm5);
                b6.SetImageResource(Resource.Drawable.cm6);
                b7.SetImageResource(Resource.Drawable.cm7);
                b8.SetImageResource(Resource.Drawable.cm8);
                b9.SetImageResource(Resource.Drawable.c9);
                b0.SetImageResource(Resource.Drawable.caseVoid);
                game.SelectC = 9;
            };
            b0.Click += delegate 
            {
                b1.SetImageResource(Resource.Drawable.cm1);
                b2.SetImageResource(Resource.Drawable.cm2);
                b3.SetImageResource(Resource.Drawable.cm3);
                b4.SetImageResource(Resource.Drawable.cm4);
                b5.SetImageResource(Resource.Drawable.cm5);
                b6.SetImageResource(Resource.Drawable.cm6);
                b7.SetImageResource(Resource.Drawable.cm7);
                b8.SetImageResource(Resource.Drawable.cm8);
                b9.SetImageResource(Resource.Drawable.cm9);
                b0.SetImageResource(Resource.Drawable.caseVoidR);
                game.SelectC = 0;
            };

            bV.Click += delegate
            {
                
                if (game.Valider())
                {
                    Toast.MakeText(this, "Win !", ToastLength.Long).Show();
                }
                else
                {
                    Toast.MakeText(this, "The grid is not correct", ToastLength.Long).Show();
                }
            };

            bS.Click += delegate
            {
                Serialiser("maSauvegarde.xml");
            };
        }

        /// <summary>
        /// Désérialiser
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public Sudokolor Deserialiser(string filepath)
        {
            Sudokolor newInstance;
            string RootPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            XmlSerializer serializer = new XmlSerializer(typeof(Sudokolor));// initialise le sérialiser
            Stream reader = new FileStream(RootPath + "/" + filepath, FileMode.Open); //initialise le reader           
            newInstance = (Sudokolor)serializer.Deserialize(reader); //on lit
            reader.Close(); //ferme le reader

            return newInstance;
        }

        /// <summary>
        /// Sérialiser
        /// </summary>
        /// <param name="filepath"></param>
        public void Serialiser(string filepath)
        {

            XmlSerializer serializer = new XmlSerializer(typeof(Sudokolor));//initialises the serialiser
            string RootPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            Stream writer = new FileStream(RootPath + "/" + filepath, FileMode.Create);//initialises the writer
            serializer.Serialize(writer, this.game);//Writes to the file
            writer.Close();//Closes the writer
            Toast.MakeText(this, "Saved game", ToastLength.Long).Show();
        }

        /// <summary>
        /// Gère le clique dans la grille
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Gridview_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            int x = e.Position / 9;
            int y = e.Position % 9;
            if (game.GetMatrice(x, y).Modifiable)
            {
                SetTabImage(e.Position, game.SelectC);
                this.gridview.Adapter = new ImageAdapter(this, this.tabImage, wScreen);
            }
        }

        /// <summary>
        /// Changement d'image
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="C"></param>
        private void SetTabImage(int pos, int C)
        {
            switch (C)
            {
                case 1:
                    {
                        this.tabImage[pos] = Resource.Drawable.cm1;
                        game.SetTabCases(pos, C);
                        break;
                    }
                case 2:
                    {
                        this.tabImage[pos] = Resource.Drawable.cm2;
                        game.SetTabCases(pos, C);
                        break;
                    }
                case 3:
                    {
                        this.tabImage[pos] = Resource.Drawable.cm3;
                        game.SetTabCases(pos, C);
                        break;
                    }
                case 4:
                    {
                        this.tabImage[pos] = Resource.Drawable.cm4;
                        game.SetTabCases(pos, C);
                        break;
                    }
                case 5:
                    {
                        this.tabImage[pos] = Resource.Drawable.cm5;
                        game.SetTabCases(pos, C);
                        break;
                    }
                case 6:
                    {
                        this.tabImage[pos] = Resource.Drawable.cm6;
                        game.SetTabCases(pos, C);
                        break;
                    }
                case 7:
                    {
                        this.tabImage[pos] = Resource.Drawable.cm7;
                        game.SetTabCases(pos, C);
                        break;
                    }
                case 8:
                    {
                        this.tabImage[pos] = Resource.Drawable.cm8;
                        game.SetTabCases(pos, C);
                        break;
                    }
                case 9:
                    {
                        this.tabImage[pos] = Resource.Drawable.cm9;
                        game.SetTabCases(pos, C);
                        break;
                    }
                case 0:
                    {
                        this.tabImage[pos] = Resource.Drawable.caseVoid;
                        game.SetTabCases(pos, C);
                        break;
                    }
                default:
                    {

                        break;
                    }
            }
        }
        public void MyGame(Sudokolor sudo)
        {
            this.game = sudo;
        }

        /// <summary>
        /// Remplis la grille
        /// </summary>
        private void RemplirGrid()
        {
            int k = 0;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (game.GetMatrice(i, j).Modifiable == false)
                    {
                        int val = game.GetMatrice(i, j).Valeur;
                        switch (val)
                        {
                            case 1:
                                {
                                    tabImage[k] = Resource.Drawable.c1;
                                    break;
                                }
                            case 2:
                                {
                                    tabImage[k] = Resource.Drawable.c2;
                                    break;
                                }
                            case 3:
                                {
                                    tabImage[k] = Resource.Drawable.c3;
                                    break;
                                }
                            case 4:
                                {
                                    tabImage[k] = Resource.Drawable.c4;
                                    break;
                                }
                            case 5:
                                {
                                    tabImage[k] = Resource.Drawable.c5;
                                    break;
                                }
                            case 6:
                                {
                                    tabImage[k] = Resource.Drawable.c6;
                                    break;
                                }
                            case 7:
                                {
                                    tabImage[k] = Resource.Drawable.c7;
                                    break;
                                }
                            case 8:
                                {
                                    tabImage[k] = Resource.Drawable.c8;
                                    break;
                                }
                            case 9:
                                {
                                    tabImage[k] = Resource.Drawable.c9;
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
                        int val = game.GetMatrice(i, j).Valeur;
                        switch (val)
                        {
                            case 0:
                                {
                                    tabImage[k] = Resource.Drawable.caseVoid;
                                    break;
                                }
                            case 1:
                                {
                                    tabImage[k] = Resource.Drawable.cm1;
                                    break;
                                }
                            case 2:
                                {
                                    tabImage[k] = Resource.Drawable.cm2;
                                    break;
                                }
                            case 3:
                                {
                                    tabImage[k] = Resource.Drawable.cm3;
                                    break;
                                }
                            case 4:
                                {
                                    tabImage[k] = Resource.Drawable.cm4;
                                    break;
                                }
                            case 5:
                                {
                                    tabImage[k] = Resource.Drawable.cm5;
                                    break;
                                }
                            case 6:
                                {
                                    tabImage[k] = Resource.Drawable.cm6;
                                    break;
                                }
                            case 7:
                                {
                                    tabImage[k] = Resource.Drawable.cm7;
                                    break;
                                }
                            case 8:
                                {
                                    tabImage[k] = Resource.Drawable.cm8;
                                    break;
                                }
                            case 9:
                                {
                                    tabImage[k] = Resource.Drawable.cm9;
                                    break;
                                }
                            default:
                                {
                                    break;
                                }

                        }
                    }
                    k++;
                }
            }
        }
    }

}