public class ConsoleWordCombinationPrinter : IWordCombinationPrinter
{
    public void Print(IEnumerable<WordCombination> combinations)
    {
        foreach (var combination in combinations)
        {
            Console.WriteLine(string.Join('+', combination.Words) + "=" + combination.Combination);
        }
    }
}