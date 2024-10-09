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
            // Перевірка на відповідність умовам
            if (k <= 0 || k > 1000000)
            {
                throw new ArgumentOutOfRangeException(nameof(k), "K повинно бути в межах 1 ≤ K ≤ 10^6.");
            }

            if (p <= 0 || p > 1000000000)
            {
                throw new ArgumentOutOfRangeException(nameof(p), "P повинно бути в межах 1 ≤ P ≤ 10^9.");
            }

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
            if (input.Length != 2)
            {
                throw new FormatException("Вхідний файл повинен містити два натуральних числа.");
            }

            if (!int.TryParse(input[0], out int k))
            {
                throw new FormatException("Невірний формат числа K.");
            }

            if (!int.TryParse(input[1], out int p))
            {
                throw new FormatException("Невірний формат числа P.");
            }

            return new EntCounter(k, p);
        }
    }
}