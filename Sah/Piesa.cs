﻿using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace Sah
{
    public abstract class Piesa : PictureBox
    {
        public Piesa()
        {

        }

        private bool culoarePiesa;
        public bool CuloarePiesa { get { return culoarePiesa; } set { culoarePiesa = value; } }

        private Color culoarePiesaBackColor;
        public Color CuloarePiesaBackColor { get { return culoarePiesaBackColor; } set { culoarePiesaBackColor = value; } }


        private int linie;
        public int Linie { get { return linie; } set { linie = value; } }

        private int coloana;
        public int Coloana { get { return coloana; } set { coloana = value; } }

        /// <summary>
        /// Am facut chestia asta cu static ca nu se repete piesaApasata1 de fiecare data cand creeam un obiect de tipul Piesa
        /// </summary>
        private static Piesa piesaApasata1 = null;
        public static Piesa PiesaApasata1 { get { return piesaApasata1; } set { piesaApasata1 = value; } }


        static bool statePiesa = false;
        public static bool StatePiesa { get { return statePiesa; } set { statePiesa = value; } }



        protected abstract void Muta();
        public void Piesa_Click(object sender, EventArgs e)
        {
            /*Am facut if-ul acesta ca metoda abstracta ca sa fie luata de prima piesa apasata si nu de a doua*/
            /*if (PiesaApasata1 == null)
                Muta();
            else
                PiesaApasata1.Muta();*/
            Muta();
        }

    }
}
