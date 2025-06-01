public class WordCombinationFinder
{
    static string GetCombination(IEnumerable<string> words) => string.Join(string.Empty, words);

    public IReadOnlyList<WordCombination> Find(IEnumerable<string> words, int wordLength = 6)
    {
        var wordsArray = words.ToArray();

        // Check if any input provided
        if (wordsArray.Length == 0)
            return [];

        var result = new List<WordCombination>();

        // Loop over all words of specified length and filter out duplicates
        var wordsToFind = wordsArray.Where(w => w.Length == wordLength).Distinct().ToArray();
        foreach (var wordToFind in wordsToFind)
        {
            // Only use words shorter than the length that should be found
            var filteredList = wordsArray.Where(w => w.Length < wordLength).ToArray();

            // Make combinations and match with current word to find
            for (int i = 0; i < filteredList.Length; i++)
            {
                List<string> temporaryCombinationList = [filteredList[i]];
                var startPosition = 0;
                for (int j = startPosition; j < filteredList.Length; j++)
                {
                    if (i == j)
                        continue;

                    temporaryCombinationList.Add(filteredList[j]);

                    string temporaryCombination = GetCombination(temporaryCombinationList);
                    bool isCombinationLongerThanSpecifiedLength = temporaryCombination.Length > wordLength;
                    if (temporaryCombination == wordToFind)
                    {
                        var combinationExists = DoesCombinationAlreadyExist(result, wordToFind, temporaryCombinationList);
                        if (!combinationExists)
                        {
                            result.Add(new WordCombination([.. temporaryCombinationList], temporaryCombination));
                            Console.WriteLine($"Found {result.Count()} combinations");
                        }
                        continue;
                    }
                    else if (isCombinationLongerThanSpecifiedLength)
                    {
                        // reset used words array
                        temporaryCombinationList = [filteredList[i]];

                        // start adding words again from the last start position + 1
                        j = ++startPosition;
                    }
                }
            }
        }

        // Make sure we only return a distinct result set
        return result;
    }

    private static bool DoesCombinationAlreadyExist(List<WordCombination> result, string wordToFind, List<string> usedWords)
    {
        foreach (var foundCombinationsWords in result.Where(r => r.Combination == wordToFind))
        {
            if (usedWords.SequenceEqual(foundCombinationsWords.Words))
                return true;
        }

        return false;
    }
}

//  Algorithm

//  Loop over all words
//       Filter out duplicates
//       Check for each word if it is the required length and keep this in a variable, otherwise go to next one
//       Create list with only words smaller then word length
//       Start looping over this and add word at this index in a temporary list
//           Loop again but exclude the current selected word
//           Add this word also to the temporary list and compare to the word to find
//           If not the same and shorter than word length, continue adding words to list
//           If longer than word length, start again at first selected word and start one index further in the list
//           If same, check if the combination already exists in the result set and otherwise add to results

// Performance improvements
//  Used arrays instead of linq and enumerables, much faster that way
//  Use distinct to make list of words to find smaller


