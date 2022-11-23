using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sah
{
    class Rege : Piesa
    {
        public Rege()
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

                /*Am facut chestia asta pt ca aveam un bug cand pion alb era in spate si pionul negru era in fata */
                if (PiesaApasata1.CuloarePiesa != piesaApasata2.CuloarePiesa && PiesaApasata1.Coloana + 1 == piesaApasata2.Coloana && PiesaApasata1.CuloarePiesa == false
                || PiesaApasata1.CuloarePiesa != piesaApasata2.CuloarePiesa && PiesaApasata1.Coloana - 1 == piesaApasata2.Coloana && PiesaApasata1.CuloarePiesa == true)
                {
                    PiesaApasata1.BackColor = piesaApasata2.BackColor;
                    PiesaApasata1.Location = piesaApasata2.Location;
                    PiesaApasata1.CuloarePiesaBackColor = piesaApasata2.CuloarePiesaBackColor;
                    PiesaApasata1.Coloana = piesaApasata2.Coloana;
                    PiesaApasata1 = null;
                    piesaApasata2.Dispose();
                }
                else if (PiesaApasata1.CuloarePiesa != piesaApasata2.CuloarePiesa && PiesaApasata1.Coloana + 1 != piesaApasata2.Coloana)
                {
                    PiesaApasata1.BackColor = PiesaApasata1.CuloarePiesaBackColor;
                    PiesaApasata1 = null;
                }
                else if (PiesaApasata1.CuloarePiesa == piesaApasata2.CuloarePiesa && PiesaApasata1.Coloana + 1 == piesaApasata2.Coloana)
                {
                    PiesaApasata1.BackColor = PiesaApasata1.CuloarePiesaBackColor;
                    PiesaApasata1 = null;
                }
                else if (PiesaApasata1.CuloarePiesa == piesaApasata2.CuloarePiesa && PiesaApasata1.Coloana + 1 != piesaApasata2.Coloana)
                {
                    PiesaApasata1.BackColor = PiesaApasata1.CuloarePiesaBackColor;
                    PiesaApasata1 = null;
                }
                StatePiesa = false;
            }
        }
    }
}

