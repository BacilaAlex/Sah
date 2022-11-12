﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sah
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.Width = 655;
            this.Height = 678;
            Creare_Tabla();
        }


        public void Creare_Tabla()
        {
            Patrat[,] patrat = new Patrat[8, 8];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    patrat[i, j] = new Patrat(80);

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

            Piesa[,] piesa = new Piesa[4, 8];


            for (int i = 0; i < 4; i++)
            {

                for (int j = 0; j < 8; j++)
                {
                    piesa[i, j] = new Piesa();
                    piesa[i, j].Size = new Size(80, 80);
                    piesa[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                    piesa[i, j].BackColor = patrat[i, j].BackColor;

                    if (i <= 1)
                        piesa[i, j].Location = new Point(80 * j, 80 * i);
                    else
                        piesa[i, j].Location = new Point(80 * j, 80 * (i + 4));


                    switch (i)
                    {
                        case 1:
                            piesa[i, j].Image = Image.FromFile(@"..\..\Piese\Pion_Alb.png");
                            piesa[i, j].CuloarePiesa = false;
                            break;

                        case 2:
                            piesa[i, j].Image = Image.FromFile(@"..\..\Piese\Pion_Negru.png");
                            piesa[i, j].CuloarePiesa = true;
                            break;
                    }


                    /*piesa[i, j].Click += Piesa_Click;*/

                    piesa[i, j].Click += piesa[i, j].Piesa_Click;

                    Controls.Add(piesa[i, j]);
                    piesa[i, j].BringToFront();

                }
            }

            int x = 3;
            for (int j = 0; j < 8; j++)
            {

                if (j > 4)
                {

                    piesa[0, j].Image = Image.FromFile(@"..\..\Piese\" + (j - x).ToString() + ".png");
                    x += 2;
                }
                else
                    piesa[0, j].Image = Image.FromFile(@"..\..\Piese\" + j.ToString() + ".png");
            }
            x = 3;
            for (int j = 5; j < 13; j++)
            {
                if (j > 9)
                {

                    piesa[3, j - 5].Image = Image.FromFile(@"..\..\Piese\" + (j - x).ToString() + ".png");
                    x += 2;
                }
                else
                    piesa[3, j - 5].Image = Image.FromFile(@"..\..\Piese\" + j.ToString() + ".png");
            }

        }

        int apasat = 0;
        Piesa piesaApasat;

        public void Patrat_Click(object sender, EventArgs e)
        {
            Patrat patrat = (Patrat)sender;
            if (apasat == 1)
            {
                piesaApasat.Location = patrat.Location;
                piesaApasat.BackColor = patrat.BackColor;
                apasat = 0;
            }
        }

        public void Piesa_Click(object sender, EventArgs e)
        {
            Piesa piesa = (Piesa)sender;
            piesa.BackColor = Color.AliceBlue;
            apasat++;
            if (apasat == 2)
            {
                piesaApasat.Location = piesa.Location;
                piesaApasat.BackColor = piesa.BackColor;
                piesa.Dispose();
                apasat = 0;
            }
            else
                piesaApasat = piesa;


        }
    }
}