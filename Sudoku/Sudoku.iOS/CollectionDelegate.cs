using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace Sudoku.iOS
{
    /*
     * Classe permettant de gérer (les différents événements) la grille 
     */
    public class CollectionDelegate : UICollectionViewDelegate
    {
        private UICollectionView CollectionView { get; set; }  // la collectionView à gérer
        private Sudokolor Game;     //le jeu à gérer

        public CollectionDelegate(UICollectionView collectionView, Sudokolor game)
        {
            CollectionView = collectionView;
            CollectionView.AllowsMultipleSelection = false;  // on interdit une sélection multiple d'item à la fois
            this.Game = game;
 
        }
   
       /**
        * Methode appelé lorsque qu'un item est cliqué ou sélectionné
        */
        
        public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
        {
            
            this.MiseAjourIHMetGame(indexPath);

        }

        /**
         * Methode appelé lorsque qu'un item est désélectionné
         */
        public override void ItemDeselected(UICollectionView collectionView, NSIndexPath indexPath)
        {
            
        }


        /**
         * Indique qu'un item peut être sélectionné ou non
         */
        public override bool ShouldDeselectItem(UICollectionView collectionView, NSIndexPath indexPath)
        {
            return true;
        }

        /**
        * Indique qu'un item peut être désélectionné ou non
        */
        public override bool ShouldSelectItem(UICollectionView collectionView, NSIndexPath indexPath)
        {
            return true;
        }

        public override bool CanFocusItem(UICollectionView collectionView, NSIndexPath indexPath)
        {
            //return base.CanFocusItem(collectionView, indexPath);
            return true;
        }

        
        /**
         * Permet de mettre à jour l'état du jeu dans l'ihm ainsi que dans les données (SudoKolor)
         */
        public void MiseAjourIHMetGame(NSIndexPath i)
        {

                var cell = CollectionView.CellForItem(i) as Cellule;
                int x = i.Row / 9;                             // On recupère la ligne correspondante à cet item
                int y = i.Row % 9;                             // On recupère la colonne correspondante à cet item
            if (this.Game.MMatrice(x, y))                      //si cet item ou case est une case modifiable...
                {

                    int couleur = this.Game.SetMatrice(x, y);   //Application des changements dans le jeu(changement de la couleur associé à cet item)
            //Application des changements dans l'IHM
                switch (couleur)
                    {

                    case 0:
                        {

                            cell.UpdateCell("caseVoid");
                            break;
                        }

                    case 1:
                            {
                            
                                cell.UpdateCell("cm1");
                                break;
                            }
                        case 2:
                            {
                                cell.UpdateCell("cm2");
                                break;
                            }
                        case 3:
                            {
                                cell.UpdateCell("cm3");
                                break;
                            }
                        case 4:
                            {
                                cell.UpdateCell("cm4");
                                break;
                            }
                        case 5:
                            {
                                cell.UpdateCell("cm5");
                                break;
                            }
                        case 6:
                            {
                                cell.UpdateCell("cm6");
                                break;
                            }
                        case 7:
                            {
                                cell.UpdateCell("cm7");
                                break;
                            }
                        case 8:
                            {
                                cell.UpdateCell("cm8");
                                break;
                            }
                        case 9:
                            {
                                cell.UpdateCell("cm9");
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