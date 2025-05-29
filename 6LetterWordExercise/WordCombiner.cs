public class WordsCombiner(string[] words)
{
    public List<WordCombination> FindCombinations(int wordLength = 6)
    {
        if (words.Count() == 0)
            return [];

        Console.WriteLine($"Found {words.Count()} words");

        var result = new List<WordCombination>();
        for (int currentWordIndex = 0; currentWordIndex < words.Length; currentWordIndex++)
        {
            var wordToFind = words[currentWordIndex];
            if (wordToFind.Length != wordLength)
                continue;

            Console.WriteLine($"Currently searching word {wordToFind} at index {currentWordIndex}");

            var filteredList = words.Where(w => w.Length < wordLength).ToArray();
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

        return result;
    }
}

public record WordCombination(List<string> Words, string Combination)
{
}

//  Algorithm

//  Loop over all words
//       Check for each word if it is the required length and keep this in a variable, otherwise go to next one
//       Create list with only words smaller then word length
//       Start looping over this and select word at this index
//           Loop again but exclude the current selected word
//           Combine the two words and check if it matches the current word to find

// Performance improvements
//  Used arrays instead of linq and enumerables, much faster that way


