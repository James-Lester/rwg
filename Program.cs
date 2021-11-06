using System;
using System.Globalization;

namespace randomWordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var ti = new CultureInfo("en-US", false).TextInfo;

            string[] lines = System.IO.File.ReadAllLines(AppContext.BaseDirectory + "dictionary.txt");
            
            Console.WriteLine("Enter number of words 1-32.");
            bool proceed = int.TryParse(Console.ReadLine(), out int o);
            while (proceed)
            {
                try
                {
                    int wordCount = (o > 32) ? 32 : (o < 1) ? 1 : o;
                    var r = new Random();
                    string randWords = "";
                    int max = lines.Length;

                    for (int i = 0; i < wordCount; i++) randWords += ti.ToTitleCase(lines[r.Next(max)]);

                    Console.WriteLine($"{randWords.Length} - {randWords}");
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw;
                }
                finally
                {
                    Console.WriteLine("Enter another number to continue:");
                    proceed = int.TryParse(Console.ReadLine(), out o);
                }
            }
        }
    }
}
