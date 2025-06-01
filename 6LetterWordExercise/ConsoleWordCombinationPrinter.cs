public class ConsoleWordCombinationPrinter : ICombinationReporter
{
    public void Report(IEnumerable<WordCombination> combinations)
    {
        foreach (var combination in combinations)
        {
            Console.WriteLine(string.Join('+', combination.Words) + "=" + combination.Combination);
        }
    }
}