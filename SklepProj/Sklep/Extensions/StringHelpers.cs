using System.Linq;

namespace Sklep.Extensions
{
    public static class StringHelpers
    {
        /// <summary>
        ///     Sprawdza czy słowo posiada jakieś z słów z tablicy, ignoruje wielkość liter
        ///     W przypadku braku słowa zwraca fałsz
        ///     W przypadku pustej tablicy słów zwraca prawdę
        /// </summary>
        /// <param name="word"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public static bool ContainsAny(this string word, string[] words)
        {
            if (string.IsNullOrEmpty(word)) return false;
            if (words.Length == 0) return true;

            var loweredWords = words
                .Select(x => x.ToLower())
                .ToList();

            var loweredWord = word.ToLower();

            return loweredWords.Any(x => loweredWord.Contains(x));
        }
    }
}