using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the FindLength class
            FindLength findLength = new FindLength();

            // Call the Find method to execute the functionality
            findLength.Find();

            // Optionally, keep the console open until the user presses a key
            Console.WriteLine("Нажмите любую клавишу, чтобы закрыть программу.");
            Console.ReadKey();
        }
    }
}
