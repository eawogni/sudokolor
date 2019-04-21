using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

using Foundation;
using UIKit;

namespace Sudoku.iOS
{
    /**
     * Permet de sauver un objet sudoKolor en xml
     */
    public class SudoKolorDataXml : ISauvableSudoKolor
    {
        private DataContractSerializer ser = new DataContractSerializer(typeof(Sudokolor));
        private Stream flux;

        public SudoKolorDataXml(string fichier)
        {
            this.flux = new FileStream(fichier, FileMode.OpenOrCreate);  //Création du fichier
        }
        public Sudokolor Charger()
        {
            Sudokolor jeu = null;
            if (flux.Length >0 )        //lorsque le fichier n'est pas vide
            {
                jeu = this.ser.ReadObject(flux) as Sudokolor;
            }
            return jeu;
            
        }

        public void Sauver(Sudokolor game)
        {
            this.ser.WriteObject(flux, game);
        }
    }
}