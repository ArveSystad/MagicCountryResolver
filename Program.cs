using System;
using System.Collections;
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
            _countries = File.ReadAllLines("../countries.txt");
            if(args.Length < 2 ) { 
                Console.WriteLine("Give me a word and a mode ('none' or 'all')!");
                Environment.Exit(0);
            }
            List<string> foundCountries;

            if (args[0] == "none")
                foundCountries = GetCountriesNotContainingAnyLetters(args[1]).ToList();
            else if(args[0] == "all")
                foundCountries = GetCountriesContainingAllLetters(args[1]).ToList();
            else 
                throw new Exception("No mode given, give me one!");

            foreach (var country in foundCountries)
                Console.WriteLine(country);

            Console.WriteLine();

            Console.WriteLine("A total of {0} countries.", foundCountries.Count());
        }

        private static IEnumerable<string> GetCountriesContainingAllLetters(string inThisWord)
        {
            var input = inThisWord.ToLower();
            foreach (string country in _countries)
            {
                var countryToLower = country.ToLower();

                if (countryToLower.HasAllLetters(input))
                    yield return country;
            }
        }
        
        private static IEnumerable<string> GetCountriesNotContainingAnyLetters(string inThisWord)
        {
            var input = inThisWord.ToLower();
            foreach (string country in _countries)
            {               
                var countryToLower = country.ToLower();

                var hasAnyLetters = countryToLower.HasAnyLetters(inThisWord);

                if (!hasAnyLetters)
                    yield return country;
            }
        }
    }
}
