﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sah
{
    class Pion: Piesa
    {
        public Pion()
        {

        }
        override protected void Muta()
        {
            if (StatePiesa == false)
            {
                PiesaApasata1 = this;
                PiesaApasata1.BackColor = System.Drawing.Color.Blue;
                StatePiesa = true;
            }
            else if (StatePiesa == true)
            {
                Piesa piesaApasata2 = this;
                if (PiesaApasata1.CuloarePiesa != piesaApasata2.CuloarePiesa)
                {
                    PiesaApasata1.BackColor = piesaApasata2.BackColor;
                    PiesaApasata1.Location = piesaApasata2.Location;
                    PiesaApasata1.CuloarePiesaBackColor = piesaApasata2.CuloarePiesaBackColor;
                    PiesaApasata1 = null;
                    piesaApasata2.Dispose();
                }
                else if (PiesaApasata1.CuloarePiesa == piesaApasata2.CuloarePiesa)
                {
                    PiesaApasata1.BackColor = PiesaApasata1.CuloarePiesaBackColor;
                    PiesaApasata1 = null;
                }
                StatePiesa = false;
            }
        }
        public void Patrat_Click(object sender, EventArgs e)
        {
            Muta();
        }

    }
}