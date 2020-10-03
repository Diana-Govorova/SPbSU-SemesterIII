using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

            var result = (textMass.AsParallel()
                .Select(line => new { Name = line, Count = textMass.Count(str => str == line) })
                .Where(line => line.Count > 1)
                .Distinct()
                .ToDictionary(line => line.Name, line => line.Count));

            int i = 0;
            foreach (var element in result.Where(element => element.Key.Length > 5))
            {
                string word = element.Key;
                word = word.Replace(",", "");
                words.Add(word);
                i++;
            }

            Console.WriteLine("10 наиболее встречающихся слов: ");
            string[] tenMostCommonWords = FindTenMostCommonWords();
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
        private string[] FindTenMostCommonWords()
        {
            var descendingOrder = (from word in words
                                   where word.Length > 5
                                   group word by word into g
                                   orderby g.Count() descending
                                   select g.Key);
            string[] mostCommonWords = (descendingOrder.AsParallel().Take(10)).ToArray();
            return mostCommonWords;
        }
    }
}