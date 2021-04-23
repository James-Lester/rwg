using System;
using System.Globalization;

namespace randomWordGenerator
{
  class Program
  {
    static void Main(string[] args)
    {
      var ti = new CultureInfo("en-US", false).TextInfo;

      var dict = new System.Collections.Generic.Dictionary<int, Tuple<string, int>>() { };
      string[] lines = System.IO.File.ReadAllLines(AppContext.BaseDirectory + "dictionary.txt");
      for (int i = 0; i < lines.Length; i++) dict.Add(i, new Tuple<string, int>(lines[i], lines[i].Length));

      bool proceed = true;
      while (proceed)
      {
        try
        {
          Console.WriteLine("Enter number of words 1-32.");
          int wordCount = int.TryParse(Console.ReadLine(), out int o) ? ((o > 32) ? 32 : (o < 0) ? 1 : o) : 6;

          var r = new Random();
          string randWords = "";
          int max = dict.Keys.Count;

          for (int i = 0; i < wordCount; i++) randWords += ti.ToTitleCase(dict[r.Next(max)].Item1.ToString());

          Console.WriteLine($"{randWords.Length} - {randWords}");
        }
        catch (System.Exception ex)
        {
          Console.WriteLine(ex.ToString());
          throw;
        }
        finally
        {
          Console.WriteLine("Continue? y/n");
          var c = Console.ReadLine();
          if (c.ToLower() != "y") proceed = false;
        }
      }
    }
  }
}
