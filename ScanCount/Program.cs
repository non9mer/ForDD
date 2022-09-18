using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Counter
{
    internal class Program
    {
        const string UnwantedSigns = ".,?!-/*”“\"";

        static void Main(string[] args)
        {
            string fileContents = File.ReadAllText("file.txt");

            foreach (char c in UnwantedSigns)
            {
                fileContents = fileContents.Replace(c, ' ');
                GC.Collect();
            }

            fileContents = fileContents.Replace(Environment.NewLine, " ");

            string[] words = fileContents.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            fileContents = string.Empty;
            GC.Collect();

            Dictionary<string, int> wordCounts = new Dictionary<string, int>();

            foreach (string w in words.Select(x => x.ToLower()))

                if (wordCounts.TryGetValue(w, out int c))
                    wordCounts[w] = c + 1;
                else
                    wordCounts.Add(w, 1);

            words = new string[1];
            GC.Collect();

            List<Tuple<int, string>> wordStats = wordCounts.Select(x => new Tuple<int, string>(x.Value, x.Key)).ToList();
            wordStats.Sort((x, y) => y.Item1.CompareTo(x.Item1));

            foreach (Tuple<int, string> t in wordStats)
                File.AppendAllText(".stats.txt", t.Item2 + " " + t.Item1 + Environment.NewLine);
            Console.WriteLine("The process was successfully completed. Press any key.");
            Console.ReadLine();
        }
    }
}

