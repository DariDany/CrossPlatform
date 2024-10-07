using System;
using System.IO;

namespace Lab2
{
    public class EntCounter 
    {
        private int K; 
        private int P; 

        public EntCounter(int k, int p)
        {
            K = k;
            P = p;
        }

        public long CountEnts()
        {
            long[] dp = new long[K + 1];

            if (K >= 2) dp[2] = 1;

            for (int i = 2; i <= K; i++)
            {
                if (dp[i] > 0)
                {
                    if (i + 1 <= K)
                    {
                        dp[i + 1] = (dp[i + 1] + dp[i]) % P;
                    }

                    if (i * 2 <= K)
                    {
                        dp[i * 2] = (dp[i * 2] + dp[i]) % P;
                    }
                }
            }

            return dp[K] % P;
        }

        public void WriteOutput(long result)
        {
            File.WriteAllText("output.txt", result.ToString());
        }

        public static EntCounter ReadInput(string fileName)
        {
            string[] input = File.ReadAllText(fileName).Split();
            int k = int.Parse(input[0]);
            int p = int.Parse(input[1]);
            return new EntCounter(k, p);
        }
    }
}
