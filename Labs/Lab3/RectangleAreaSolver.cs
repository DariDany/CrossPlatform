using System;
using System.Collections.Generic;
using System.IO;

namespace Lab3
{
    public class RectangleAreaSolver
    {
        private int[,] grid = new int[101, 101];  // Сітка для позначення зайнятих клітин
        private bool[,] visited = new bool[101, 101];  // Відвідані клітини
        private int[] dx = { 1, -1, 0, 0 };  // Зміни по x для DFS
        private int[] dy = { 0, 0, 1, -1 };  // Зміни по y для DFS
        private int N;

        // Метод для зчитування вхідних даних
        public void ReadInput(string inputFile)
        {
            string[] input = File.ReadAllLines(inputFile);

            // Перевірка кількості прямокутників
            if (!int.TryParse(input[0], out N) || N < 1 || N > 25)
            {
                throw new ArgumentException("Неправильна кількість прямокутників. Має бути від 1 до 25.");
            }

            // Заповнюємо сітку прямокутниками
            for (int i = 1; i <= N; i++)
            {
                string[] coords = input[i].Split(' ');

                if (coords.Length != 4)
                {
                    throw new ArgumentException("Неправильний формат введення для координат прямокутника.");
                }

                // Перевірка чи всі координати є цілими числами і знаходяться в межах [0, 100]
                if (!int.TryParse(coords[0], out int x1) || x1 < 0 || x1 > 100 ||
                    !int.TryParse(coords[1], out int y1) || y1 < 0 || y1 > 100 ||
                    !int.TryParse(coords[2], out int x2) || x2 < 0 || x2 > 100 ||
                    !int.TryParse(coords[3], out int y2) || y2 < 0 || y2 > 100)
                {
                    throw new ArgumentException("Координати мають бути цілими числами в діапазоні від 0 до 100.");
                }

                // Перевірка правильності координат (X1 < X2 і Y1 < Y2)
                if (x1 >= x2 || y1 >= y2)
                {
                    throw new ArgumentException("Неправильні координати прямокутника. Повинно бути X1 < X2 і Y1 < Y2.");
                }

                // Позначаємо область, зайняту прямокутником
                for (int x = x1; x < x2; x++)
                {
                    for (int y = y1; y < y2; y++)
                    {
                        grid[x, y] = 1; // Позначаємо клітки
                    }
                }
            }
        }

        // Метод для обчислення найбільшої площі фігури
        public int FindMaxArea()
        {
            int maxArea = 0;

            // Шукаємо найбільшу область за допомогою DFS
            for (int i = 0; i <= 100; i++)
            {
                for (int j = 0; j <= 100; j++)
                {
                    if (grid[i, j] == 1 && !visited[i, j])
                    {
                        maxArea = Math.Max(maxArea, DFS(i, j));
                    }
                }
            }

            return maxArea;
        }

        // DFS для обчислення площі однієї області
        private int DFS(int x, int y)
        {
            Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();
            stack.Push(new Tuple<int, int>(x, y));
            visited[x, y] = true;
            int area = 0;

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                int cx = current.Item1;
                int cy = current.Item2;
                area++; // Обчислюємо площу

                for (int dir = 0; dir < 4; dir++)
                {
                    int nx = cx + dx[dir];
                    int ny = cy + dy[dir];

                    // Перевіряємо, чи в межах сітки і чи не було відвідано раніше
                    if (nx >= 0 && nx <= 100 && ny >= 0 && ny <= 100 && grid[nx, ny] == 1 && !visited[nx, ny])
                    {
                        stack.Push(new Tuple<int, int>(nx, ny));
                        visited[nx, ny] = true;
                    }
                }
            }

            return area; // Повертаємо площу знайденої області
        }

        // Метод для запису результату у файл
        public void WriteOutput(string outputFile, int result)
        {
            File.WriteAllText(outputFile, result.ToString());
        }
    }
}
