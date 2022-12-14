using System;
using System.IO;
using System.Windows.Forms;

namespace Sah
{
    public class Patrat : Panel
    {
        public Patrat(int marimePatrat = 0, int coloana = 0, int linie = 0)
        {
            this.marimePatrat = marimePatrat;
            this.coloana = coloana;
            this.linie = linie;
        }


        private int marimePatrat;
        public int MarimePatrat { get { return marimePatrat; } }


        private int coloana;
        public int Coloana { get { return coloana; } set { coloana = value; } }


        private int linie;
        public int Linie { get { return linie; } set { linie = value; } }


        private static Piesa piesaApasata1;

        public void Patrat_Click(object sender, EventArgs e)
        {
            if (Piesa.PiesaApasata1 != null)
            {
                if (Piesa.StatePiesa == true)
                {
                    piesaApasata1 = Piesa.PiesaApasata1;

                    Patrat patrat = this;

                    Form1.DateClient = piesaApasata1.ToString() + " " + patrat.ToString();

                    piesaApasata1.Location = patrat.Location;
                    piesaApasata1.BackColor = patrat.BackColor;
                    piesaApasata1.CuloarePiesaBackColor = patrat.BackColor;
                    piesaApasata1.Linie = patrat.Linie;
                    piesaApasata1.Coloana = patrat.Coloana;

                    Console.WriteLine(Form1.DateClient);

                    ScriereClient();

                    Piesa.StatePiesa = false;
                    Piesa.PiesaApasata1 = null;
                }
            }
        }

        public void ScriereClient()
        {

            StreamWriter scriere = new StreamWriter(Form1.clientStream);
            scriere.AutoFlush = true; // enable automatic flushing
            scriere.WriteLine(Form1.DateClient);
        }

        public override string ToString()
        {
            return
                this.GetType() + " " +
                this.Linie + " " +
                this.Coloana;
        }
    }
}
