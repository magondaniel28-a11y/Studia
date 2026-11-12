using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace KolkoKrzyzyk
{
    public partial class Form1 : Form
    {
        Button[,] Przycisk = new Button[3,3];
        Button ZerujWyniki = new Button();
        string symbol = "O";

        int oWins = 0;
        int xWins = 0;
        int remis = 0;
        Label labelWyniki;
        public Form1()
        {
            InitializeComponent();


            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    this.Przycisk[i,j] = new Button();
                    this.Przycisk[i,j].Location = new System.Drawing.Point(17 + (100 * i), 100 + (100 * j));
                    this.Przycisk[i,j].Name = "Przycisk" + (i * 3 + j).ToString();
                    this.Przycisk[i,j].Size = new System.Drawing.Size(100, 100);
                    this.Przycisk[i,j].TabIndex = 2 + (i * 3 + j);
                    this.Przycisk[i,j].Text = "";
                    this.Przycisk[i,j].UseVisualStyleBackColor = true;

                    this.Przycisk[i,j].Click += new System.EventHandler(this.Przycisk_Click);
       
                    this.Controls.Add(Przycisk[i,j]);
                }
            }
            labelWyniki = new Label();
            labelWyniki.Location = new Point(17, 60);
            labelWyniki.Size = new Size(200, 25);
            labelWyniki.TextAlign = ContentAlignment.MiddleLeft;
            labelWyniki.Text = "O: 0    X: 0    Remis: 0";

            this.Controls.Add(labelWyniki);

            this.ZerujWyniki = new Button();
            this.ZerujWyniki.Location = new Point(220, 60);
            this.ZerujWyniki.Size = new Size(100, 25);
            this.ZerujWyniki.Text = "Zeruj wyniki";
            this.Controls.Add(ZerujWyniki);
            this.ZerujWyniki.Click += new System.EventHandler(this.ZerujWyniki_Click);

        }

        private bool wygrana(string symbol)
        {
            
            if (Przycisk[0, 0].Text.Equals(symbol) && 
                Przycisk[0, 1].Text.Equals(symbol) && 
                Przycisk[0, 2].Text.Equals(symbol)) return true;

            if (Przycisk[1, 0].Text.Equals(symbol) && 
                Przycisk[1, 1].Text.Equals(symbol) && 
                Przycisk[1, 2].Text.Equals(symbol)) return true;

            if (Przycisk[2, 0].Text.Equals(symbol) && 
                Przycisk[2, 1].Text.Equals(symbol) && 
                Przycisk[2, 2].Text.Equals(symbol)) return true;

            
            if (Przycisk[0, 0].Text.Equals(symbol) && 
                Przycisk[1, 0].Text.Equals(symbol) && 
                Przycisk[2, 0].Text.Equals(symbol)) return  true;
            
            if (Przycisk[0, 1].Text.Equals(symbol) && 
                Przycisk[1, 1].Text.Equals(symbol) && 
                Przycisk[2, 1].Text.Equals(symbol)) return  true;

            if (Przycisk[0, 2].Text.Equals(symbol) && 
                Przycisk[1, 2].Text.Equals(symbol) && 
                Przycisk[2, 2].Text.Equals(symbol)) return true;

            if (Przycisk[0, 0].Text.Equals(symbol) && 
                Przycisk[1, 1].Text.Equals(symbol) && 
                Przycisk[2, 2].Text.Equals(symbol)) return  true;
            
            if (Przycisk[0, 2].Text.Equals(symbol) && 
                Przycisk[1, 1].Text.Equals(symbol) && 
                Przycisk[2, 0].Text.Equals(symbol)) return true;
            
            return false;
        }

        private bool PelnaPlansza()
        {
            int licznik = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (!Przycisk[i, j].Text.Equals("")) licznik++;

                }
            }
            return (licznik == 9);
        }
        
        private void ZerujPlansze()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    this.Przycisk[i, j].Text = "";
             
                }
            }
            if (symbol.Equals("O")) symbol = "X";
            else
                symbol = "O";
            label1.Text = "Ruch gracza "+symbol;
        }
        
        private void buttonKoniec_Click(object sender, EventArgs e)
        {
            
                DialogResult result = MessageBox.Show("Czy jesteś pewien?", "Potwierdzenie", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Close();
                }
        }
        private void ZerujWyniki_Click(object sender, EventArgs e)
        {
            oWins = 0;
            xWins = 0;
            remis = 0;
            labelWyniki.Text = "O: " + oWins + "    X: " + xWins + "    Remis: " + remis;
        }
        private void Przycisk_Click(object sender, EventArgs e)
        {
            if (label1.Text.Contains("Wygral") || label1.Text.Contains("Remis"))
            {
                MessageBox.Show("Gra już się zakończyła!");
                return;
            }
            if (((Button)sender).Text.Equals(""))
            {
                ((Button)sender).Text = symbol;
                ((Button)sender).ForeColor = symbol.Equals("X") ? Color.Red : Color.Green;
            } 
            else
            {
                return;
            }

            if (wygrana(symbol))
            {
                label1.Text = "Wygral " + symbol;
                MessageBox.Show("Wygrał " + symbol + ". Gra zakończona!");
                if (symbol.Equals("O"))
                {
                    oWins++;
                }
                else
                {
                    
                    xWins++;
                
                }
                labelWyniki.Text = "O: " + oWins + "    X: " + xWins + "    Remis: " + remis;
            }
            else
            {
                if (PelnaPlansza())
                {
                    label1.Text = "Remis";
                    MessageBox.Show("Remis! Gra zakończona!");
                    remis++;
                    labelWyniki.Text = "O: " + oWins + "    X: " + xWins + "    Remis: " + remis;
                }
                else
                {
                    if (symbol.Equals("O")) symbol = "X";
                    else symbol = "O";
                    label1.Text = "Ruch gracza " + symbol;
                }
            }
        }
        
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ZerujPlansze();  
        }

        private void Form1_Load(object sender, EventArgs e)
        { 

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
