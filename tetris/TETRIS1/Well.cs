using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TETRIS1
{
   public class Well
    {
        private Graphics g;
        public int W
        {
            get;
            set; 
        }
        public int H 
        { 
            get; 
            set; 
        }
        public int L 
        {
            get;
            set;
        }

        public Cell[,] c;
        public Well(Graphics ag, int aW, int aH, int aL)
        {
            g = ag;
            W = aW;
            H = aH;
            L = aL;                      
            CreateEmpty();
        }

        public void CreateEmpty()
        {
            Cell.InitCells(L, g);
            c = new Cell[W,H]; 
            for (int x=0; x<W; x++)
                for(int y=0; y<H; y++)
                {
                    if (x > 0 && x < W - 1 && y < H - 1)
                        c[x, y] = new Cell(x, y, 0); // tukšs
                    else if (y < H - 2)
                        c[x, y] = new Cell(x, y, 1); // siena
                    else
                        c[x, y] = new Cell(x, y, 2); // apakšā

                }
        }

        public int DelFull() // dze6 iazpilditas rindas un atgriez to skaitu
        {
            int DelCount = 0;
            int y = H - 2;
            while (y > 0) 
                {
                    bool full = true;
                    for (int x = 1; x < W - 1; x++)
                        if (c[x, y].V == 0) { full = false; break; }
                if (full)
                {
                    DelCount++;
                    for (int yy = y - 1; yy >= 0; yy--)
                        for (int x = 1; x < W - 1; x++)
                            c[x, yy + 1].V = c[x, yy].V;
                }
                else y--;
                }
             return DelCount;
        }

    }
}
