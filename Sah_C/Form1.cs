using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace Sah
{
    public partial class Form1 : Form
    {
        public Patrat[,] patrat;
        public Piesa[,] piesa;
        public Form1()
        {
            InitializeComponent();
            InitClient();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 655;
            this.Height = 678;
            this.Text = "Sah_C";
            Creare_Tabla();
        }


        public void Creare_Tabla()
        {
            patrat = new Patrat[8, 8];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    patrat[i, j] = new Patrat(80, i, j);
                    patrat[i, j].Size = new Size(patrat[i, j].MarimePatrat, patrat[i, j].MarimePatrat);
                    patrat[i, j].Location = new Point(patrat[i, j].MarimePatrat * j, patrat[i, j].MarimePatrat * i);

                    if ((i + j) % 2 == 0)
                        patrat[i, j].BackColor = Color.Brown;
                    else
                        patrat[i, j].BackColor = Color.GreenYellow;

                    Controls.Add(patrat[i, j]);

                    patrat[i, j].Click += patrat[i, j].Patrat_Click;

                }
            }

            Creare_Piese(patrat);
        }

        public void Creare_Piese(Patrat[,] patrat)
        {

            piesa = new Piesa[4, 8];

            for (int i = 0; i < 4; i++)
            {

                for (int j = 0; j < 8; j++)
                {
                    if (i == 1 || i == 2)
                        piesa[i, j] = new Pion();
                    else if ((i == 0 || i == 3) && j == 4)
                        piesa[i, j] = new Rege();
                    else
                        piesa[i, j] = new RestulPieselor();

                    Creare_Proprietati_la_Piese(i, j);

                    Creare_Locatie_la_Piese(i, j);

                    piesa[i, j].Click += piesa[i, j].Piesa_Click;

                    Controls.Add(piesa[i, j]);
                    piesa[i, j].BringToFront();

                }
            }
            Creare_Img_la_Piese();

        }
        private void Creare_Locatie_la_Piese(int i, int j)
        {
            if (i <= 1)
            {
                piesa[i, j].Location = new Point(80 * j, 80 * i);
                piesa[i, j].Linie = patrat[i, j].Linie;
                piesa[i, j].Coloana = patrat[i, j].Coloana;
            }
            else
            {
                piesa[i, j].Location = new Point(80 * j, 80 * (i + 4));
                piesa[i, j].Linie = patrat[i + 4, j].Linie;
                piesa[i, j].Coloana = patrat[i + 4, j].Coloana;
            }
        }
        private void Creare_Img_la_Piese()
        {
            for (int j = 0; j < 8; j++)
            {
                piesa[1, j].Image = Image.FromFile(@"..\..\Piese\Pion_Alb.png");
                piesa[1, j].CuloarePiesa = false;
                piesa[2, j].Image = Image.FromFile(@"..\..\Piese\Pion_Negru.png");
                piesa[2, j].CuloarePiesa = true;
            }
            int x = 3;
            for (int j = 0; j < 8; j++)
            {

                if (j > 4)
                {

                    piesa[0, j].Image = Image.FromFile(@"..\..\Piese\" + (j - x).ToString() + ".png");
                    piesa[0, j].CuloarePiesa = false;
                    x += 2;
                }
                else
                {
                    piesa[0, j].Image = Image.FromFile(@"..\..\Piese\" + j.ToString() + ".png");
                    piesa[0, j].CuloarePiesa = false;
                }
            }
            x = 3;
            for (int j = 5; j < 13; j++)
            {
                if (j > 9)
                {

                    piesa[3, j - 5].Image = Image.FromFile(@"..\..\Piese\" + (j - x).ToString() + ".png");
                    piesa[3, j - 5].CuloarePiesa = true;
                    x += 2;
                }
                else
                {
                    piesa[3, j - 5].Image = Image.FromFile(@"..\..\Piese\" + j.ToString() + ".png");
                    piesa[3, j - 5].CuloarePiesa = true;
                }
            }
        }
        private void Creare_Proprietati_la_Piese(int i, int j)
        {
            piesa[i, j].Size = new Size(80, 80);
            piesa[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
            piesa[i, j].BackColor = patrat[i, j].BackColor;
            piesa[i, j].CuloarePiesaBackColor = patrat[i, j].BackColor;
        }


        public TcpClient client;
        public static NetworkStream clientStream;
        public bool ascult;
        public Thread t;

        public static string DateClient { get; set; }

        public void InitClient()
        {
            client = new TcpClient("127.0.0.1", 3000);
            ascult = true;
            t = new Thread(new ThreadStart(Asculta_client));
            t.Start();
            clientStream = client.GetStream();
        }

        public void Asculta_client()
        {
            StreamReader citire = new StreamReader(clientStream);
            String dateClient;
            while (ascult)
            {
                dateClient = citire.ReadLine();
                if (dateClient != null)
                {
                    string[] words = dateClient.Split(' ');
                    int iPiesaMuta = Int32.Parse(words[1]);
                    int jPiesaMuta = Int32.Parse(words[2]);
                    int iPiesaUndeMuta = Int32.Parse(words[4]);
                    int jPiesaUndeMuta = Int32.Parse(words[5]);

                    for (int i = 0; i < 4; i++)
                        for (int j = 0; j < 8; j++)
                        {
                            if (piesa[i, j].Linie == iPiesaMuta && piesa[i, j].Coloana == jPiesaMuta)
                            {
                                if (string.Compare(words[3], "Sah.Patrat") == 0)
                                {
                                    //Cross-thread exception
                                    this.Invoke(new Action(() =>
                                    {
                                        piesa[i, j].Location = patrat[jPiesaUndeMuta, iPiesaUndeMuta].Location;
                                        piesa[i, j].BackColor = patrat[jPiesaUndeMuta, iPiesaUndeMuta].BackColor;
                                        piesa[i, j].CuloarePiesaBackColor = patrat[jPiesaUndeMuta, iPiesaUndeMuta].BackColor;
                                        piesa[i, j].Linie = patrat[jPiesaUndeMuta, iPiesaUndeMuta].Linie;
                                        piesa[i, j].Coloana = patrat[jPiesaUndeMuta, iPiesaUndeMuta].Coloana;
                                    }));
                                }
                                else
                                {
                                    bool ok = false;
                                    for (int k = 0; k < 4; k++)
                                        for (int l = 0; l < 8; l++)
                                        {//trebie sa pun la move la l si c -1
                                            if (piesa[k, l].Linie == iPiesaUndeMuta && piesa[k, l].Coloana == jPiesaUndeMuta && ok == false)
                                            {
                                                this.Invoke(new Action(() =>
                                                {
                                                    piesa[i, j].Location = piesa[k, l].Location;
                                                    piesa[i, j].BackColor = piesa[k, l].BackColor;
                                                    piesa[i, j].CuloarePiesaBackColor = piesa[k, l].CuloarePiesaBackColor;
                                                    piesa[i, j].Linie = piesa[k, l].Linie;
                                                    piesa[i, j].Coloana = piesa[k, l].Coloana;
                                                    Console.WriteLine(piesa[i, j].GetType() + " " + piesa[k, l].GetType());
                                                    piesa[k, l].Dispose();
                                                    piesa[k,l] = piesa[i, j];
                                                    ok = true;
                                                }));
                                                break;
                                            }
                                        }

                                }
                            }

                        }
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            ascult = false;
            t.Abort();
            clientStream.Close();
            client.Close();
        }

    }
}