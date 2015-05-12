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
            if(args.Length < 1 ) { 
                Console.WriteLine("Give me a word, damnit!");
                Environment.Exit(0);
            }

            var input = args[0].ToLower();

            var foundCountries = GetCountriesNotContainingAnyLetters(_countries, input).ToList();

            foreach(var country in foundCountries)
                Console.WriteLine(country);

            Console.WriteLine();

            Console.WriteLine("A total of {0} countries.", foundCountries.Count());
        }

        private static IEnumerable<string> GetCountriesNotContainingAnyLetters(string[] countries, string inThisWord)
        {
            foreach (string country in countries)
            {
                bool found = false;
                var countryToLower = country.ToLower();

                foreach (char character in countryToLower)
                {
                    if (found)
                        continue;

                    foreach (char inputChar in inThisWord)
                    {
                        if (found)
                            continue;

                        if (inputChar == character)
                            found = true;
                    }
                }

                if (!found)
                    yield return country;
            }
        }
    }
}
