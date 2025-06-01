// Could easily be switched to a database implementation or other data source
IWordsProvider wordsProvider = new FileSystemWordsProvider("Resources/input.txt");
var words = await wordsProvider.GetWords();

var wordsCombiner = new WordCombinationFinder();
var combinations = wordsCombiner.Find(words);

// Could easily be send to a reporting service or other source with another interface implementation
ICombinationReporter reporter = new ConsoleWordCombinationPrinter();
reporter.Report(combinations);