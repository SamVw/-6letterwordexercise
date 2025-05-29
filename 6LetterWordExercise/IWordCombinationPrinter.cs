public interface IWordCombinationPrinter
{
    public void Print(WordCombination combination);
}


public class ConsoleWordCombinationPrinter : IWordCombinationPrinter
{
    public void Print(WordCombination combination)
    {
        Console.WriteLine(string.Join('+', combination.Words) + "=" + combination.Combination);
    }
}