using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MagicCountryResolver
{
    class Program
    {
        private static string[] _countries;
                    
        static void Main(string[] args)
        {
            if (args.Length < 2 )
                Quit();
            
            Func<string, string, bool> validatorFunction = null;

            if (args[0].ToLower() == "none")
                validatorFunction = (word, wordToCompareTo) => !word.HasAnyLetters(wordToCompareTo);
            else if (args[0].ToLower() == "all")
                validatorFunction = (word, wordToCompareTo) => word.HasAllLetters(wordToCompareTo);
            else
                Quit();

            _countries = File.ReadAllLines("../countries.txt");

            List<string> foundCountries = GetCountries(args[1], validatorFunction).ToList();

            foreach (var country in foundCountries)
                Console.WriteLine(country);
            
            Console.WriteLine();
            Console.WriteLine("A total of {0} countries.", foundCountries.Count());
        }

        private static void Quit()
        {
            Console.WriteLine("Give me a mode ('none' or 'all') and a word to compare against!");
            Environment.Exit(0);
        }

        private static IEnumerable<string> GetCountries(string input, Func<string, string, bool> validatorFunction)
        {
            input = input.ToLower();
            return _countries.Where(country => validatorFunction(country.ToLower(), input));
        }
    }
}