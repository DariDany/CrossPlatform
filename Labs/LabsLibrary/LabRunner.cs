using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsLibrary
{
    public class LabRunner
    {
        public void RunLab1(string inputFile, string outputFile)
        {
            // Create an instance of the FindLength class
            FindLength findLength = new FindLength();

            // Call the Find method to execute the functionality
            findLength.Find(inputFile, outputFile);

        }
        public void RunLab2(string inputFile, string outputFile)
        {
            try
            {
                EntCounter counter = EntCounter.ReadInput(inputFile);
                long result = counter.CountEnts();
                counter.WriteOutput(result, outputFile);
            }
            catch (Exception ex)
            {
                // Лог помилки або виведення повідомлення
                Console.WriteLine("Помилка: " + ex.Message);
            }
        }
        public void RunLab3(string inputFile, string outputFile)
        {
            try
            {
                // Створення екземпляра класу RectangleAreaSolver
                RectangleAreaSolver solver = new RectangleAreaSolver();

                // Зчитування вхідних даних
                solver.ReadInput(inputFile);

                // Обчислення найбільшої площі фігури
                int maxArea = solver.FindMaxArea();

                // Виведення результату
                solver.WriteOutput(outputFile, maxArea);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка: " + ex.Message);
            }
        }
    }
}
