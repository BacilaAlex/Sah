using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sah
{
    class RestulPieselor : Piesa
    {
        public RestulPieselor()
        { }
        override protected void Muta(Piesa sender)
        {
            if (StatePiesa == false)
            {
                PiesaApasata1 = this;
                PiesaApasata1.BackColor = System.Drawing.Color.Blue;
                StatePiesa = true;
            }
            else if (StatePiesa == true)
            {
                Piesa piesaApasata2 = sender;
                if (PiesaApasata1.CuloarePiesa != piesaApasata2.CuloarePiesa)
                {
                    Form1.DateServer = PiesaApasata1.ToString() + " " + piesaApasata2.ToString();

                    PiesaApasata1.BackColor = piesaApasata2.BackColor;
                    PiesaApasata1.Location = piesaApasata2.Location;
                    PiesaApasata1.Location = piesaApasata2.Location;
                    PiesaApasata1.CuloarePiesaBackColor = piesaApasata2.CuloarePiesaBackColor;
                    PiesaApasata1.Linie = piesaApasata2.Linie;
                    PiesaApasata1.Coloana = piesaApasata2.Coloana;

                    Console.WriteLine(Form1.DateServer);

                    ScriereServer();

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

    }
}
