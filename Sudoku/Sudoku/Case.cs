using System;
using System.Collections.Generic;
using System.Text;

namespace SudoKolor
{
    public class Case
    {
        private int valeur; // la valeur de la case 
        private bool modifiable; // la case est-elle modifiable ? 
        /// <summary>
        /// retourne le la valeur de la case
        /// </summary>
        public int Valeur
        {
            get { return valeur; }
            set { valeur = value; }
        }
        /// <summary>
        /// retourne la valeur  booleanne de la case
        /// </summary>
        public bool Modifiable
        {
            get { return modifiable; }
            set { modifiable = value; }
        }
        /// <summary>
        /// Gère une vase
        /// </summary>
        /// <param name="m"></param>
        /// <param name="val"></param>
        public Case(bool m, int val)
        {
            modifiable = m;
            valeur = val;
        }
        /// <summary>
        ///  gère une case
        /// </summary>
        public Case()
        {
            modifiable = true;
            valeur = 0;
        }


    }
}
