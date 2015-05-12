using System.Linq;

namespace MagicCountryResolver
{
    public static class StringExtensions
    {
        public static bool HasAllLetters(this string word, string wordToCompareTo)
        {
            bool isCandidate = true;
            foreach (char character in wordToCompareTo)
            {
                isCandidate = word.Contains(character);

                if (!isCandidate)
                    break;
            }

            return isCandidate;
        }

        public static bool HasAnyLetters(this string word, string wordToCompareTo)
        {
            bool found = false;
            foreach (char character in word)
            {
                if (found)
                    continue;

                foreach (char inputChar in wordToCompareTo)
                {
                    if (found)
                        continue;

                    if (inputChar == character)
                        found = true;
                }
            }

            return found;
        } 
    }
}