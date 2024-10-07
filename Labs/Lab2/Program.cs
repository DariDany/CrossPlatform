namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EntCounter counter = EntCounter.ReadInput("input.txt");

            long result = counter.CountEnts();

            counter.WriteOutput(result);
        }
    }
}