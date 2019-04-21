using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace Sudoku.iOS
{


    /**
     * Classe permettant permettant d'indiquer la source des données de notre grille (CollectionView)
     */
   public  class AdaptateurCelluleGrille : UICollectionViewDataSource
    {
        private List<string> listeImages = new List<string>();  // données à utiliser dans le remplissage de la grille


        public AdaptateurCelluleGrille(List<string> listCases)
        {

            this.listeImages = listCases;
        }
         

        /**
         * Permet de renvoyer un item dans la grille
         */

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = collectionView.DequeueReusableCell("Cell", indexPath) as Cellule;   //création d'un item
            cell.UpdateCell(this.listeImages[indexPath.Row]);                              //Habillage de cet item
            return cell;                                                                   //renvoie de cet item dans la grille(CollectionView)
        }
        /**
         * Indique le nombre de données affichées dans la grille (CollectionView)
         */
        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return this.listeImages.Count;
        }

        public override nint NumberOfSections(UICollectionView collectionView)
        {
            // We only have one section
            return 1;
        }

    }
}