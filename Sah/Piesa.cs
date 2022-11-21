using System;
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

        private static bool statePiesa = false;
        public static bool StatePiesa { get { return statePiesa; } set { statePiesa = value; } }

        /// <summary>
        /// Am facut chestia asta cu static ca nu se repete piesaApasata1 de fiecare data cand creeam un obiect de tipul Piesa
        /// </summary>
        private static Piesa piesaApasata1 = null;
        public static Piesa PiesaApasata1 { get { return piesaApasata1; } set { piesaApasata1 = value; } }

        protected abstract void Muta();
        public void Piesa_Click(object sender, EventArgs e)
        {
            Muta();
        }

    }
}
