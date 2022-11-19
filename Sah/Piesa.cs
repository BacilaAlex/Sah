using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace Sah
{
    public class Piesa : PictureBox
    {
        private bool culoarePiesa;
        public bool CuloarePiesa
        {
            get { return culoarePiesa; }
            set { culoarePiesa = value; }
        }

        private Color culoarePiesaBackColor;
        public Color CuloarePiesaBackColor
        {
            get { return culoarePiesaBackColor; }
            set { culoarePiesaBackColor = value; }
        }

        private static bool statePiesa = false;
        public static bool StatePiesa
        {
            get { return statePiesa; }
            set { statePiesa = value; }
        }

        /// <summary>
        /// Am facut chestia asta cu static ca nu se repete piesaApasata1 de fiecare data cand creeam un obiect de tipul Piesa
        /// </summary>
        private static Piesa piesaApasata1 = null;
        public static Piesa PiesaApasata1
        {
            get { return piesaApasata1; }
        }

 
        public void Piesa_Click(object sender, EventArgs e)
        {

            if (statePiesa == false)
            {
                piesaApasata1 = this;
                piesaApasata1.BackColor = Color.DodgerBlue;
                statePiesa = true;
            }
            else if (statePiesa == true)
            {
                Piesa piesaApasata2 = this;
                if (piesaApasata1.culoarePiesa != piesaApasata2.culoarePiesa)
                {
                    piesaApasata1.BackColor = piesaApasata2.BackColor;
                    piesaApasata1.Location = piesaApasata2.Location;
                    piesaApasata1.CuloarePiesaBackColor = piesaApasata2.CuloarePiesaBackColor;
                    piesaApasata1 = null;
                    piesaApasata2.Dispose();
                }
                else if (piesaApasata1.culoarePiesa == piesaApasata2.culoarePiesa)
                {
                    piesaApasata1.BackColor = piesaApasata1.CuloarePiesaBackColor;
                    piesaApasata1 = null;
                }
                statePiesa = false;
            }
        }

    }
}
