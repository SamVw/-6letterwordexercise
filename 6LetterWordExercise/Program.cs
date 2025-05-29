
IWordsProvider wordsProvider = new FileWordsProvider("Resources/input.txt");
var words = await wordsProvider.GetWords();

var wordsCombiner = new WordsCombiner();

var combinations = wordsCombiner.FindCombinations(words);

IWordCombinationPrinter printer = new ConsoleWordCombinationPrinter();
printer.Print(combinations);