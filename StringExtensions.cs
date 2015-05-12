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
    }
}