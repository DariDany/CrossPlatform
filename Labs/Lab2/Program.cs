namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                EntCounter counter = EntCounter.ReadInput("input.txt");
                long result = counter.CountEnts();
                counter.WriteOutput(result);
            }
            catch (Exception ex)
            {
                // Лог помилки або виведення повідомлення
                Console.WriteLine("Помилка: " + ex.Message);
            }
        }
    }
}