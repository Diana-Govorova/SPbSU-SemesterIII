using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Task4_WarAndPeaceAnalyzer_
{
    /// <summary>
    /// Calculating statistics for files using PLINQ.
    /// </summary>
    public class Plinq
    {
        private List<string> words = new List<string>();

        /// <summary>
        /// Text analysis.
        /// </summary>
        public Plinq()
        {
            string[] textMass;
            string text = File.ReadAllText(@"WarAndPeace.txt");
            int count = File.ReadAllLines(@"WarAndPeace.txt").Length;
            textMass = text.Split(' ');

            Console.Write("Количество слов: ");
            Console.WriteLine(textMass.Length);
            Console.Write("Количество строк: ");
            Console.WriteLine(count);

            Console.WriteLine("10 наиболее встречающихся слов: ");
            string[] tenMostCommonWords = FindTenMostCommonWords(textMass);
            int place = 1;
            foreach (var word in tenMostCommonWords)
            {
                Console.WriteLine($"{place} место - {word}");
                place++;
            }

        }

        /// <summary>
        /// Find 10 most common words in the text.
        /// </summary>
        /// <returns>Array of words.</returns>
        private string[] FindTenMostCommonWords(string[] textMass)
        {
            var descendingOrder = (from word in textMass.AsParallel()
                                   where word.Length > 5
                                   group word by word into g
                                   orderby g.Count() descending
                                   select g.Key);
            string[] mostCommonWords = (descendingOrder.AsParallel().Take(10)).ToArray();
            return mostCommonWords;
        }
    }
}