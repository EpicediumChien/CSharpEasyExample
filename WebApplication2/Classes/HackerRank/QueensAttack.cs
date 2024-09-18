using System.Collections.Generic;
using System;
using System.Linq;

class QueensAttack
{

    /*
     * Complete the 'queensAttack' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER k
     *  3. INTEGER r_q
     *  4. INTEGER c_q
     *  5. 2D_INTEGER_ARRAY obstacles
     */

    public static int queensAttack(int n, int k, int r_q, int c_q, List<List<int>> obstacles)
    {
        int upCount = n - r_q;
        int downCount = r_q - 1;
        int leftCount = c_q - 1;
        int rightCount = n - c_q;
        int ltDiaCount = Math.Min(upCount, leftCount);
        int rtDiaCount = Math.Min(upCount, rightCount);
        int rbDiaCount = Math.Min(downCount, rightCount);
        int lbDiaCount = Math.Min(downCount, leftCount);

        for (int i = 0; i < k; i++)
        {
            int r_o = obstacles[i][0];
            int c_o = obstacles[i][1];
            if (r_o == r_q)
            {
                //right left
                if (c_o > c_q)
                {
                    rightCount = Math.Min(c_o - c_q - 1, rightCount);
                }
                else
                {
                    leftCount = Math.Min(c_q - c_o - 1, leftCount);
                }
            }
            else if (c_o == c_q)
            {
                //up down
                if (r_o > r_q)
                {
                    upCount = Math.Min(r_o - r_q - 1, upCount);
                }
                else
                {
                    downCount = Math.Min(r_q - r_o - 1, downCount);
                }
            }
            else if (Math.Abs(r_o - r_q) == Math.Abs(c_o - c_q))
            {
                if (r_o > r_q && c_o < c_q)
                {
                    ltDiaCount = Math.Min(r_o - r_q - 1, ltDiaCount);
                }
                else if (r_o > r_q && c_o > c_q)
                {
                    rtDiaCount = Math.Min(r_o - r_q - 1, rtDiaCount);
                }
                else if (r_o < r_q && c_o > c_q)
                {
                    rbDiaCount = Math.Min(r_q - r_o - 1, rbDiaCount);
                }
                else if (r_o < r_q && c_o < c_q)
                {
                    lbDiaCount = Math.Min(r_q - r_o - 1, lbDiaCount);
                }
            }
        }

        Console.Write($"{upCount}\n");
        Console.Write($"{downCount}\n");
        Console.Write($"{leftCount}\n");
        Console.Write($"{rightCount}\n");
        Console.Write($"{ltDiaCount}\n");
        Console.Write($"{rtDiaCount}\n");
        Console.Write($"{rbDiaCount}\n");
        Console.Write($"{lbDiaCount}\n");
        return upCount + downCount + leftCount + rightCount + ltDiaCount + rtDiaCount + rbDiaCount + lbDiaCount;
    }
}