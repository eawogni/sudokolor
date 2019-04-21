using SudoKolor;
using System;
namespace Sudoku
{

    public class Sudokolor
    {
        private int selectC; // la case selectionnée
        private Case[][] matrice = new Case[9][]; // initialisation de la matrice
        private bool[] tabV = new bool[10]; // tableau de valeur booléenne

        /// <summary>
        /// Constructeur de la case sudokolor
        /// </summary>
        public Sudokolor()
        {

            for (int i = 0; i < 9; i++)
            {
                // pour chaque i on crée un tableau de 9 indices
                matrice[i] = new Case[9];
                for (int j = 0; j < 9; j++)
                {
                    matrice[i][j] = new Case();
                }
            }

            Random rnd = new Random();
            int x, y, val;
            for (int depart = 0; depart < 25; depart++)
            {
                x = rnd.Next(0, 9);
                y = rnd.Next(0, 9);
                val = rnd.Next(0, 9);
                while (!notInColumn(val, x) || !notInRow(val, y) || !notInSquare(val, y, x))
                {
                    val = rnd.Next(0, 9);
                }
                matrice[x][y].Valeur = val;
                matrice[x][y].Modifiable = false;

            }

            //
            //initialisation de la couleur selectionnee a null
            selectC = 0;

        }

        //fonction pour verifier si 'value' n'est pas deja present dans la ligne
        private bool notInRow(int value, int indR)
        {
            bool p = true;
            for (int i = 0; i < 9; i++)
            {
                if (matrice[i][indR].Valeur == value) p = false;
            }
            return p;
        }

        //fonction pour verifier si 'value' n'est pas deja present dans la colonne
        private bool notInColumn(int value, int indC)
        {
            bool p = true;
            for (int i = 0; i < 9; i++)
            {
                if (matrice[indC][i].Valeur == value) p = false;
            }
            return p;
        }

        ////fonction pour verifier si 'value' n'est pas deja present dans le carré
        private bool notInSquare(int value, int indR, int indC)
        {
            int divC, divR;
            bool p = true;
            divC = indC / 3;
            divR = indR / 3;
            for (int i = divC * 3; i < divC * 3 + 3; i++)
            {
                for (int j = divR * 3; j < divR * 3 + 3; j++)
                {
                    if (matrice[i][j].Valeur == value) p = false;
                }
            }
            return p;
        }


    /// <summary>
    /// Modififie la case selectionnée
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="val"></param>
    internal void SetTabCases(int pos, int val)
        {
            int x = pos / 9;
            int y = pos % 9;
            matrice[x][y].Valeur = val;
        }
        /// <summary>
        /// Détermine si la case associée à ces cordonnées est modifiable ou pas
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool MMatrice(int x, int y)
        {
            bool res = false;
            if (matrice[x][y].Modifiable)
            {
                res = true;
            }
            return res;
        }
        /// <summary>
        /// permet de modifier la couleur de la casse associée au coordonnées x,y
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>

        public int SetMatrice(int x, int y)
        {
            matrice[x][y].Valeur = selectC;
            return selectC;
        }
        /// <summary>
        /// Renvoie la case associée à ces coordonnées 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>

        public Case GetMatrice(int x, int y)
        {
            return matrice[x][y];
        }
        /// <summary>
        /// Lecture et écriture de la coulur sélectionnée
        /// </summary>

        public int SelectC
        {
            set { selectC = value; }
            get { return selectC; }
        }
        /// <summary>
        /// Permet de vérifier la cohérence du jeu, vérifie si le joueur à gagné la partie
        /// </summary>
        /// <returns></returns>        
        public bool Valider()
        {
            bool res = true;
            int temp;

            for (int i = 0; i < 9; i++)
            {
                InitTabV();
                for (int j = 0; j < 9; j++)
                {
                    temp = matrice[i][j].Valeur;
                    if (tabV[temp] == false)
                    {
                        tabV[temp] = true;
                    }
                    else
                    {
                        res = false;
                    }
                }
            }

            for (int j = 0; j < 9; j++)
            {
                InitTabV();
                for (int i = 0; i < 9; i++)
                {
                    temp = matrice[i][j].Valeur;
                    if (tabV[temp] == false)
                    {
                        tabV[temp] = true;
                    }
                    else
                    {
                        res = false;
                    }
                }
            }
            InitTabV();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    temp = matrice[i][j].Valeur;
                    if (tabV[temp] == false)
                    {
                        tabV[temp] = true;
                    }
                    else
                    {
                        res = false;
                    }
                }
            }
            InitTabV();
            for (int i = 3; i < 6; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    temp = matrice[i][j].Valeur;
                    if (tabV[temp] == false)
                    {
                        tabV[temp] = true;
                    }
                    else
                    {
                        res = false;
                    }
                }
            }
            InitTabV();
            for (int i = 6; i < 9; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    temp = matrice[i][j].Valeur;
                    if (tabV[temp] == false)
                    {
                        tabV[temp] = true;
                    }
                    else
                    {
                        res = false;
                    }
                }
            }
            InitTabV();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 3; j < 6; j++)
                {
                    temp = matrice[i][j].Valeur;
                    if (tabV[temp] == false)
                    {
                        tabV[temp] = true;
                    }
                    else
                    {
                        res = false;
                    }
                }
            }
            InitTabV();
            for (int i = 3; i < 6; i++)
            {
                for (int j = 3; j < 6; j++)
                {
                    temp = matrice[i][j].Valeur;
                    if (tabV[temp] == false)
                    {
                        tabV[temp] = true;
                    }
                    else
                    {
                        res = false;
                    }
                }
            }
            InitTabV();
            for (int i = 6; i < 9; i++)
            {
                for (int j = 3; j < 6; j++)
                {
                    temp = matrice[i][j].Valeur;
                    if (tabV[temp] == false)
                    {
                        tabV[temp] = true;
                    }
                    else
                    {
                        res = false;
                    }
                }
            }
            InitTabV();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 6; j < 9; j++)
                {
                    temp = matrice[i][j].Valeur;
                    if (tabV[temp] == false)
                    {
                        tabV[temp] = true;
                    }
                    else
                    {
                        res = false;
                    }
                }
            }
            InitTabV();
            for (int i = 3; i < 6; i++)
            {
                for (int j = 6; j < 9; j++)
                {
                    temp = matrice[i][j].Valeur;
                    if (tabV[temp] == false)
                    {
                        tabV[temp] = true;
                    }
                    else
                    {
                        res = false;
                    }
                }
            }
            InitTabV();
            for (int i = 6; i < 9; i++)
            {
                for (int j = 6; j < 9; j++)
                {
                    temp = matrice[i][j].Valeur;
                    if (tabV[temp] == false)
                    {
                        tabV[temp] = true;
                    }
                    else
                    {
                        res = false;
                    }
                }
            }
            return res;
        }
        /// <summary>
        /// Return la matrice du jeu
        /// </summary>

        public Case[][] Matrice
        {
            get { return matrice; }
            set { matrice = value; }
        }
        /// <summary>
        /// On initialise le tabV
        /// </summary>

        public void InitTabV()
        {
            tabV[0] = true;
            for (int i = 1; i < 10; i++)
            {
                tabV[i] = false;
            }
        }
    }
}


