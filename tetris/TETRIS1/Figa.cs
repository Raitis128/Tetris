using System;
using System.Collections.Generic;
using System.Text;

namespace TETRIS1
{
   public class Figa
    {
        protected int N = 4; // katra figūra iazņem 4 šūnas
        protected int[] x, newX;
        protected int[] y, newY;
        protected int p, newP; // pagrieziens
        protected int t; // figūras tips: 4 - kvadrāts, Red
        protected static Well w;
        public Figa()
        {

        }
        public Figa(int xc, int yc, Well aw)
        {
            w = aw;
            x = new int[N];
            y = new int[N];
            newX = new int[N];
            newY = new int[N];
            t = 4; // kvadrāts; Red
            p = 0;
            
            if (NewXY(xc, yc, p)) SetXY();
            else // Game Over! Nav kur izveidot jaunu figūru
            { 
                throw new Exception("Game over (Figa konstr)");
            }
        }
        public bool Down()
        {
            if (NewXY(x[0], y[0] + 1, p))
            { 
                SetXY();
                return true;
            }
            else return false;
        }

        public bool Left()
        {
            if (NewXY(x[0]-1, y[0], p))
            {
                SetXY(); return true; 
            }
            else return false;
        }

        public bool Rotate()
        {
            if (NewXY(x[0], y[0], p+1))
            {
                SetXY(); return true;
            }
            else return false;
        }

        public bool Right()
        {
            if (NewXY(x[0]+1, y[0], p))
            {
                SetXY(); return true;
            }
            else return false;
        }
        public void Falled()
        {
            for (int k = 0; k < 4; k++)
                try 
                { 
                    w.c[x[k], y[k]].V = 3;
                }
                catch { }
        }
        protected virtual bool NewXY(int newXC, int newYC,  int newnewP)
        {   if (newnewP > 3) newnewP = 0;
            newP = newnewP;

            newX[0] = newXC;        newY[0] = newYC;
            newX[1] = newXC+1;      newY[1] = newYC;
            newX[2] = newXC;        newY[2] = newYC+1;
            newX[3] = newXC+1;      newY[3] = newYC+1;
            
            for (int k = 0; k < N; k++)
                if (w.c[newX[k], newY[k]].V != 0 && w.c[newX[k], newY[k]].V != t) 
                return false;
            return true;
        }
        protected void SetXY()
        {
            Hide();
            for (int k = 0; k < N; k++)
            {
                x[k] = newX[k];
                y[k] = newY[k];
            }
            p = newP;
            Show();
        }
        private void Show()
        {
            for (int k = 0; k < 4; k++)
                try 
                { 
                    w.c[x[k], y[k]].V = t;
                }
                catch { }
        }
        private void Hide()
        {
             for (int k = 0; k < 4; k++)
                try 
                { 
                    if (w.c[x[k], y[k]].V == t)
                    w.c[x[k], y[k]].V = 0; 
                }
                catch { }
        }
    }
}
