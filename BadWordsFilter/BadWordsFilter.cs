using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BadWords
{
    public class BadWordsFilter
    {
        private static readonly HashSet<string> words = new HashSet<string>();
        public static void AddBadwords(params string[] args)
        {
            foreach (string word in args)
            {
                words.Add(word.ToLower());
            }
        }
        private static IEnumerable<string> Tokenize(string text)
        {
            var words = Regex.Matches(text, @"\b[\w']+\b");
            foreach (Match match in words)
            {
                yield return match.Value;
            }
        }
        private static bool ContainsBadWords(string s)
        {
            return words.Contains(s.ToLower());
        }
        public static (bool, string) FilterWords(string s)
        {
            bool filted = false;
            var filteredText = new List<string>();
            foreach (var word in Tokenize(s))
            {
                bool contains = ContainsBadWords(word);
                filted = contains;
                filteredText.Add(contains ? new string('*', word.Length) : word);
            }
            return (filted, string.Join(" ", filteredText));
        }        
    }
}
