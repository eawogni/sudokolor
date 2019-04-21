using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using CoreGraphics;

namespace Sudoku.iOS
{
    /**
     * Classe permettant de définir une cellule
     */
    public class Cellule : UICollectionViewCell
    {
        private UIImageView caseImg ;                               //notre cellule ici contient une image
        public static NSString cellId = new NSString("Cell");       //indique l'id associer à cette cellule (le "Cell" fait référence à l'identifier qu'on a indiqué dans l'ihm sur la cellule exemple)

        [Export("initWithFrame:")]                                  //indique qu'il y a un lien entre cette classe et la fenetre qui contient la grille(la CollectionView)
        public Cellule(CGRect frame) : base(frame)
        {      
			caseImg = new UIImageView();
            UIView view= caseImg;
            ContentView.AddSubview(view);   //Ajout de l'objet à la cellule
           
        }
		

        /**
         * Permet d'ajoueter les paramètre de l'image
         */
		public void UpdateCell(string nomImage)
		{
            caseImg.Image = UIImage.FromBundle(nomImage);  //Ajout de l'image associée à la cellule 
            caseImg.Frame = new CGRect(2,2,26,26);
       
        }

    }
}