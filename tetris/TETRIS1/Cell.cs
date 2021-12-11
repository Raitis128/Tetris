 using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TETRIS1
{
    public class Cell
    {
        private int x;  // koordinātes: numurs laukumā
        private int y;  
        static int L;
        static Graphics g;

        private int v; // vērtība: tukšs, siena, figūra...
        // 0 - tukšs
        // 1,2 - robežas; 1 - siena, 2 - apakšā,
        // 3 - nokritušā figūra 
        // 4, 5, 6 - dažādas figūras

        static Brush[] br = { Brushes.LightGray, Brushes.DarkGray, Brushes.DarkGray, Brushes.Black, Brushes.Red, Brushes.Green, Brushes.Cyan};
        public int V
        {
            get { return v; }
            set { 
                v = value;
                g.FillRectangle(br[v], x * (L + 2), y * (L + 2), L, L);
                }
        }
        public int Y
        {
            get { return y; }
            set
            {
              //  g.FillRectangle(br[0], x * (L + 2), y * (L + 2), L, L);
                y = value;
             //   g.FillRectangle(br[v], x * (L + 2), y * (L + 2), L, L);
            }
        }

        public static void InitCells(int aL, Graphics aG)
        {
            g = aG;
            L = aL;
        }
        public Cell(int ax, int ay,  int aV)
            {  
                x = ax;
                y = ay;
                V = aV; 
            }
    }
}
