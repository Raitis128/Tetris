using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TETRIS1
{
    public partial class Form1 : Form
    {

        System.Media.SoundPlayer player = new System.Media.SoundPlayer();

        public Form1()
        {
            InitializeComponent();

            player.SoundLocation = "8bit.wav";
        }
        Well w1;
        Figa f;
        int DelCount;
        Random R = new Random();
        private Figa NewFigaRnd(int FigaCount, int x, int y, Well w)
        {
            Figa f;
            int r = R.Next(0,7);
            if (r == 1) f= new FigaL1(x,y,w);
            else if (r == 2) f = new FigaT1(x, y, w);
            else if (r == 3) f = new FigaJ1(x, y, w);
            else if (r == 4) f = new FigaI1(x, y, w);
            else if (r == 5) f = new FigaS1(x, y, w);
            else if (r == 6) f = new FigaZ1(x, y, w);
            else f= new Figa(x, y, w); // x=0
            return f;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            w1 = new Well(panel1.CreateGraphics(), 12, 22, 35);
            // f = new FigaL1(4,1,w1); // konkrētā Figa - lāgošanai
            f = NewFigaRnd(2, 4, 1, w1); // nejaušā spēlei
            timer1.Enabled = true;
            button1.Enabled = false;
            DelCount = 0;
            player.Play();
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == (Keys.Escape))
            {
                Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (f.Down()) //ok
            { }
            else // falled - vēlāk cits
            {
                f.Falled();
                DelCount += w1.DelFull();
                label1.Text = "Score:" + DelCount*100;
                try
                { // f = new FigaL1(4,1,w1); // konkrētā Figa - lāgošanai
                    f = NewFigaRnd(2, 4, 1, w1); // nejaušā spēlei
                }
                catch 
                { 
                    timer1.Enabled = false;
                    label1.Text = "Game over!";
                }
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData==Keys.Left)
            {
                f.Left();
            }
            else if (e.KeyData == Keys.Right)
            {
                f.Right();
            }
            else if (e.KeyData == Keys.Space)
            {
                while (f.Down()) { }
            }
            else if (e.KeyData == Keys.Up)
            {
                f.Rotate();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Space)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
