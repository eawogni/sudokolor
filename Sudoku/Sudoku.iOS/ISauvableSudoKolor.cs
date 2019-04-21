using System;
using System.Collections.Generic;

using System.Text;

namespace Sudoku.iOS
{
    /**
     * Interface permettant une sauvegarde
     */
   public  interface ISauvableSudoKolor
    {
        Sudokolor Charger();
        void Sauver(Sudokolor game);
        
    }
}
