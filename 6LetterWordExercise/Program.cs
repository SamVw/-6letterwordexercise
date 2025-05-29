// Could easily be switched to a database implementation or other data source
IWordsProvider wordsProvider = new FileWordsProvider("Resources/input.txt");
var words = await wordsProvider.GetWords();

var wordsCombiner = new WordsCombiner();
var combinations = wordsCombiner.FindCombinations(words);

// Could easily be send to a reporting service or other source with another interface implementation
IWordCombinationPrinter printer = new ConsoleWordCombinationPrinter();
printer.Print(combinations);