namespace Lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Створення екземпляра класу RectangleAreaSolver
                RectangleAreaSolver solver = new RectangleAreaSolver();

                // Зчитування вхідних даних
                solver.ReadInput("input.txt");

                // Обчислення найбільшої площі фігури
                int maxArea = solver.FindMaxArea();

                // Виведення результату
                solver.WriteOutput("output.txt", maxArea);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка: " + ex.Message);
            }
        }
    }
}
