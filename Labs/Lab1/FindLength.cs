using System;
using System.IO;

namespace Lab1
{
    public class FindLength
    {
        public string _alphabet = "abcdefghijklmnopqrstuvwxyz";

        public void Find()
        {
            string filePathInput = GetInputFilePath();
            string filePathOutput = GetOutputFilePath();

            string[] lines = ReadInputFile(filePathInput);
            string a = lines[0];
            string b = lines[1];

            int sum = CalculateMinRotations(a, b);

            WriteOutputFile(filePathOutput, sum);
            Console.WriteLine("Файли успішно записані");
        }

        public string GetInputFilePath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..", @"..", @"..", "input.txt");
        }

        public string GetOutputFilePath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..", @"..", @"..", "output.txt");
        }

        public string[] ReadInputFile(string filePath)
        {
            return File.ReadAllLines(filePath);
        }

        public int CalculateMinRotations(string a, string b)
        {
            int sum = 0;

            a = a.ToLower();  
            b = b.ToLower();

            for (int i = 0; i < a.Length; i++)
            {
                int ind_a = _alphabet.IndexOf(a[i]);
                int ind_b = _alphabet.IndexOf(b[i]);

                int forwardDistance = (ind_b - ind_a + 26) % 26;
                int backwardDistance = (ind_a - ind_b + 26) % 26;

                sum += Math.Min(forwardDistance, backwardDistance);
            }

            return sum;
        }

        private void WriteOutputFile(string filePath, int sum)
        {
            File.WriteAllText(filePath, sum.ToString());
        }
    }
}
