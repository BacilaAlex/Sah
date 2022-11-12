using System;
using System.Windows.Forms;

namespace Sah
{
    public class Patrat : Panel
    {
        int marimePatrat;
        public Patrat(int marimePatrat = 0)
        {
            this.marimePatrat = marimePatrat;
        }

        public int MarimePatrat
        {
            get { return marimePatrat; }
        }

        static Piesa piesaApasata1;

        public void Patrat_Click(object sender, EventArgs e)
        {
            if (Piesa.PiesaApasata != null)
            {
                if (Piesa.StatePiesa == true)
                {
                    piesaApasata1 = Piesa.PiesaApasata;
                    Patrat patrat = (Patrat)sender;
                    piesaApasata1.Location = patrat.Location;
                    piesaApasata1.BackColor = patrat.BackColor;
                    Piesa.StatePiesa = false;
                }
            }
        }


    }
}
