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

        private static bool statePiesa = false;

        public static bool StatePiesa
        {
            get { return statePiesa; }
            set { statePiesa = value; }
        }


        private static Piesa piesaApasata1 = null;
        public void Piesa_Click(object sender, EventArgs e)
        {

            if (statePiesa == false)
            {
                piesaApasata1 = this;
                piesaApasata1.BackColor = Color.AliceBlue;
                statePiesa = true;
            }
            else if (statePiesa == true)
            {
                Piesa piesaApasata2 = this;
                if (piesaApasata1.culoarePiesa != piesaApasata2.culoarePiesa)
                {
                    piesaApasata1.BackColor = piesaApasata2.BackColor;
                    piesaApasata1.Location = piesaApasata2.Location;
                    piesaApasata1 = null;
                    piesaApasata2.Dispose();
                }
                else if(piesaApasata1.culoarePiesa == piesaApasata2.culoarePiesa)
                {
                    piesaApasata1.BackColor = Color.WhiteSmoke;
                    piesaApasata1 = null;
                }
                statePiesa = false;
            }
        }

        public static Piesa PiesaApasata
        {
            get { return piesaApasata1; }
        }

    }
}
