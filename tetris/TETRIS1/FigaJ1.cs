using System;
using System.Collections.Generic;
using System.Text;

namespace TETRIS1
{
    public class FigaJ1 : Figa
    {
        public FigaJ1(int xc, int yc, Well aw)
        {
            w = aw;
            x = new int[N];
            y = new int[N];
            newX = new int[N];
            newY = new int[N];
            t = 5; // L1, Green  // jāpapildina krāsu masīvs klasē Cell
            p = 0;

            if (NewXY(xc, yc, p)) SetXY();
            else // Game Over! Nav kur izveidot jaunu figūru
            {
                throw new Exception("Game over (Figa konstr)");
            }
        }
        protected override bool NewXY(int newXC, int newYC, int newnewP)
        {
            if (newnewP > 3) newnewP = 0;
            newP = newnewP;

            if (newP > 3) newP = 0;
            newX[0] = newXC;
            newY[0] = newYC;
            if (newP == 0)
            {
                newX[1] = newXC + 1;
                newY[1] = newYC;
                newX[2] = newXC - 1;
                newY[2] = newYC;
                newX[3] = newXC - 1;
                newY[3] = newYC - 1;
            }
            else if (newP == 1)
            {
                newX[1] = newXC + 1;
                newY[1] = newYC;
                newX[2] = newXC;
                newY[2] = newYC + 1;
                newX[3] = newXC;
                newY[3] = newYC + 2;
            }
            else if (newP == 2)
            {
                newX[1] = newXC + 1;
                newY[1] = newYC;
                newX[2] = newXC + 2;
                newY[2] = newYC;
                newX[3] = newXC + 2;
                newY[3] = newYC + 1;
            }
            else if (newP == 3)
            {
                newX[1] = newXC;
                newY[1] = newYC + 1;
                newX[2] = newXC;
                newY[2] = newYC + 2;
                newX[3] = newXC - 1;
                newY[3] = newYC + 2;
            }

            for (int k = 0; k < N; k++)
                if (w.c[newX[k], newY[k]].V != 0 && w.c[newX[k], newY[k]].V != t)
                    return false;
            return true;
        }
    }
}

