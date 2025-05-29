
// Implement in FileReader class or something like that
// Read as stream
var lines = await File.ReadAllLinesAsync("Resources/input.txt");

var combiner = new WordsCombiner(lines);

var combinations = combiner.FindCombinations();

IWordCombinationPrinter printer = new ConsoleWordCombinationPrinter();
foreach (var combination in combinations)
    printer.Print(combination);