using System;
public class GFG
{

    //NOTE THAT I TOOK EXISTING CODE AND ADAPTED IT TO FIT THE CHALLENGE QUESTION
    //I FOUND THAT THIS CODE NEEDS TO BE DEBUGGED SINCE THE ANSWERS DO NOT ALWAYS AGREE WITH MY TEST DATA
    //FOR EXAMPLE, IF N=5, A=1, B=3, THE ANSWER SHOULD BE 2 BUT THIS CODE GIVES 3


    // initializing the matrix.  
    //static int[,] dp = new int[8, 8];
    static int[,] dp = new int[30, 30];

    static int getsteps(int x, int y,
            int tx, int ty, int a, int b)
    {
        // if knight is on the target  
        // position return 0.  
        if (x == tx && y == ty)
        {
            return dp[0, 0];
        }
        else // if already calculated then return  
        // that value. Taking  Absolute difference.  
        if (dp[Math.Abs(x - tx), Math.Abs(y - ty)] != 0)
        {
            return dp[Math.Abs(x - tx), Math.Abs(y - ty)];
        }
        else
        {

            // there will be two distinct positions  
            // from the knight towards a target.  
            // if the target is in same row or column  
            // as of knight than there can be four  
            // positions towards the target but in that  
            // two would be the same and the other two  
            // would be the same.  
            int x1, y1, x2, y2;

            // (x1, y1) and (x2, y2) are two positions.  
            // these can be different according to situation.  
            // From position of knight, the chess board can be  
            // divided into four blocks i.e.. N-E, E-S, S-W, W-N .  

            //francine deacutis modification to remove hard wiring of traditional knight move pattern
            //replacing with variables a, b which will be passed in via getsteps call
            if (x <= tx)
            {
                if (y <= ty)
                {
                    //x1 = x + 2;
                    //y1 = y + 1;
                    //x2 = x + 1;
                    //y2 = y + 2;
                    x1 = x + b;
                    y1 = y + a;
                    x2 = x + a;
                    y2 = y + b;
                }
                else
                {
                    //x1 = x + 2;
                    //y1 = y - 1;
                    //x2 = x + 1;
                    //y2 = y - 2;
                    x1 = x + b;
                    y1 = y - a;
                    x2 = x + a;
                    y2 = y - b;
                }
            }
            else if (y <= ty)
            {
                //x1 = x - 2;
                //y1 = y + 1;
                //x2 = x - 1;
                //y2 = y + 2;
                x1 = x - b;
                y1 = y + a;
                x2 = x - a;
                y2 = y + b;
            }
            else
            {
                //x1 = x - 2;
                //y1 = y - 1;
                //x2 = x - 1;
                //y2 = y - 2;
                x1 = x - b;
                y1 = y - a;
                x2 = x - a;
                y2 = y - b;
            }

            // ans will be, 1 + minimum of steps  
            // required from (x1, y1) and (x2, y2).  
            dp[Math.Abs(x - tx), Math.Abs(y - ty)]
                    = Math.Min(getsteps(x1, y1, tx, ty, a, b),
                            getsteps(x2, y2, tx, ty, a, b)) + 1;

            // exchanging the coordinates x with y of both  
            // knight and target will result in same ans.  
            dp[Math.Abs(y - ty), Math.Abs(x - tx)]
                    = dp[Math.Abs(x - tx), Math.Abs(y - ty)];
            return dp[Math.Abs(x - tx), Math.Abs(y - ty)];
        }
    }

    // Driver Code  
    static public void Main()
    {
        int i, n, ndim, x, y, tx, ty, ans, a, b;

        // size of chess board n*n  
        ndim = 5;
        n = ndim*ndim;

        // (x, y) coordinate of the knight.  
        // (tx, ty) coordinate of the target position.  
        x = 1;
        y = 1;
        tx = 5;
        ty = 5;
        //make parameters a and b new variables
        a = 1;
        b = 3;

        // (Exception) these are the four corner points  
        // for which the minimum steps is 4.  
        if ((x == 1 && y == 1 && tx == 2 && ty == 2)
                || (x == 2 && y == 2 && tx == 1 && ty == 1))
        {
            //ans = 4;
            ans = ndim - 1;
        }
        else if ((x == 1 && y == n && tx == 2 && ty == n - 1)
              || (x == 2 && y == n - 1 && tx == 1 && ty == n))
        {
            //ans = 4;
            ans = ndim - 1;
        }
        else if ((x == n && y == 1 && tx == n - 1 && ty == 2)
              || (x == n - 1 && y == 2 && tx == n && ty == 1))
        {
            //ans = 4;
            ans = ndim - 1;
        }
        else if ((x == n && y == n && tx == n - 1 && ty == n - 1)
              || (x == n - 1 && y == n - 1 && tx == n && ty == n))
        {
            //ans = 4;
            ans = ndim - 1;
        }
        else
        {
            // dp[a , b], here a, b is the difference of  
            // x & tx and y & ty respectively.  

            //dp[1, 0] = 3; 
            //dp[0, 1] = 3;
            //dp[1, 1] = 2;
            //dp[2, 0] = 2;
            //dp[0, 2] = 2;
            //dp[2, 1] = 1;
            //dp[1, 2] = 1;

            dp[a, 0] = a + b;
            dp[0, a] = a + b;
            dp[a, a] = a + a;
            dp[b, 0] = b;
            dp[0, b] = b;
            dp[b, a] = Math.Abs(b-a);
            dp[a, b] = Math.Abs(a-b);

            ans = getsteps(x, y, tx, ty, a, b);
        }

        Console.WriteLine(ans);
    }
}

/*This (original) code is contributed by PrinciRaj1992*/
/* This code has been extended by Francine Deacutis */
