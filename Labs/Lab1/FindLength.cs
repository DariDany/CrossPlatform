using System;
using System.IO;

namespace Lab1
{
    public class FindLength
    {
        public string _alphabet = "abcdefghijklmnopqrstuvwxyz";

        public void Find()
        {
            try
            {
                string filePathInput = GetInputFilePath();
                string filePathOutput = GetOutputFilePath();

                string[] lines = ReadInputFile(filePathInput);

                // Перевірка, чи було прочитано два рядки
                if (lines.Length < 2)
                {
                    throw new ArgumentException("Необхідно ввести два рядки.");
                }

                string a = lines[0];
                string b = lines[1];

                // Перевірка, чи рядки однакової довжини
                if (a.Length != b.Length)
                {
                    throw new ArgumentException("Рядки повинні бути однакової довжини.");
                }

                // Перевірка довжини рядків (макс. 105 символів)
                if (a.Length > 105 || b.Length > 105)
                {
                    throw new ArgumentException("Довжина рядків не повинна перевищувати 105 символів.");
                }

                // Перевірка, чи містять рядки тільки маленькі букви англійського алфавіту
                if (!IsValidString(a) || !IsValidString(b))
                {
                    throw new ArgumentException("Рядки повинні містити лише маленькі букви англійського алфавіту.");
                }

                int sum = CalculateMinRotations(a, b);

                WriteOutputFile(filePathOutput, sum);
                Console.WriteLine("Файли успішно записані");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Сталася помилка: " + ex.Message);
            }
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
            // Перевірка, чи рядки однакової довжини
            if (a.Length != b.Length)
            {
                throw new ArgumentException("Рядки повинні бути однакової довжини.");
            }

            // Перевірка довжини рядків (макс. 105 символів)
            if (a.Length > 105 || b.Length > 105)
            {
                throw new ArgumentException("Довжина рядків не повинна перевищувати 105 символів.");
            }

            // Перевірка, чи містять рядки тільки маленькі букви англійського алфавіту
            if (!IsValidString(a) || !IsValidString(b))
            {
                throw new ArgumentException("Рядки повинні містити лише маленькі букви англійського алфавіту.");
            }

            int sum = 0;

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
        
        public bool IsValidString(string s)
        {
            foreach (char c in s)
            {
                if (c < 'a' || c > 'z')
                {
                    return false;
                }
            }
            return true;
        }
    }
}
