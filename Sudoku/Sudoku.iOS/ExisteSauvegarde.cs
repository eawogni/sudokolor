using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.iOS
{
    public sealed class ExisteSauvegarde
    {
        private static ExisteSauvegarde instance = null;
        private Sudokolor lejeu = null;
        private bool clickedsaved = false;
        public bool Clickedsaved
        {
            get {  return this.clickedsaved ;}
            set { this.clickedsaved = value; }
        }
        public Sudokolor LeJeu
        {
            get { return this.lejeu; }
            set { this.lejeu = value; }
        }

        private ExisteSauvegarde() { }
        public static ExisteSauvegarde get()
        {
            if (instance == null)
            {
                instance = new ExisteSauvegarde();
            }
            return instance;
        }
    }
}
