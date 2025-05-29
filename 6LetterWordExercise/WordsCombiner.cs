public class WordsCombiner()
{
    public List<WordCombination> FindCombinations(IEnumerable<string> words, int wordLength = 6)
    {
        // Check if any input provided
        if (words.Count() == 0)
            return [];

        var distinctWords = words.Distinct().ToArray();

        Console.WriteLine($"Found {distinctWords.Count()} words");

        var result = new List<WordCombination>();

        // Loop over all words of specified length
        for (int currentWordIndex = 0; currentWordIndex < distinctWords.Length; currentWordIndex++)
        {
            var wordToFind = distinctWords[currentWordIndex];
            if (wordToFind.Length != wordLength)
                continue;

            Console.WriteLine($"Currently searching word {wordToFind} at index {currentWordIndex}");

            // Only use words shorter than the length that should be found
            var filteredList = words.Where(w => w.Length < wordLength).ToArray();

            // Make combinations and match with current word to find
            for (int i = 0; i < filteredList.Length; i++)
            {
                for (int j = 0; j < filteredList.Length; j++)
                {
                    if (i == j)
                        continue;

                    string word1 = filteredList[i];
                    string word2 = filteredList[j];
                    var combination = word1 + word2;
                    if (combination == wordToFind)
                        result.Add(new WordCombination([word1, word2], combination));
                }
            }
        }

        return result.DistinctBy(r => r.Combination).ToList();
    }
}

public record WordCombination(List<string> Words, string Combination)
{
}

//  Algorithm

//  Loop over all words
//       Filter out duplicates
//       Check for each word if it is the required length and keep this in a variable, otherwise go to next one
//       Create list with only words smaller then word length
//       Start looping over this and select word at this index
//           Loop again but exclude the current selected word
//           Combine the two words and check if it matches the current word to find

// Performance improvements
//  Used arrays instead of linq and enumerables, much faster that way
//  Use distinct to make list of words smaller


