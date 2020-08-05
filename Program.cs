using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace word_frequency
{
    class Program
    {
        private const int DefaultValue = 1;
        private const string Text = "Nuclear reactors are are the heart of a nuclear power plant";
        static void Main(string[] args)
        {
            string[] words = Text.Split(' ');
            var dictionary = Frequency(words);

            Debug.Assert(dictionary["nuclear"] == 2);
            Debug.Assert(dictionary.Count == 10);

            Show(dictionary);
        }

        private static Dictionary<string, int> Frequency(string[] words) 
        {
            var comparer = StringComparer.OrdinalIgnoreCase;
            Dictionary<string, int> dictionary = new Dictionary<string, int>(comparer);
            foreach(string word in words)
            {
                if(!dictionary.ContainsKey(word))
                {
                    dictionary.Add(word, DefaultValue);
                } else {
                    dictionary[word]++;
                }
            }
            return dictionary;
        }

        private static void Show<Tkey, TValue>(Dictionary<Tkey, TValue> dictionary) 
        {
            foreach (KeyValuePair<Tkey, TValue> value in dictionary)
            {
                Console.WriteLine("Word: {0}; frequency: {1}", value.Key, value.Value);
            }
        }
    }
}
