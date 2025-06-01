# -6letterwordexercise
Solution for Peripass case


# Things that could be improved, in case of more time

There could be more test scenario's written

The ConsoleWordCombinationPrinter uses string interpolation to print all combinations on screen but it is better to use named parameters for performance

The algorithm could be rewritten where I just start combining words from the list and see if it matches any of the words that can be formed, this might be faster?

The method DoesCombinationAlreadyExist might not be really fast because it uses linq for filtering and comparing sequences

The WordCombinationFinder class could report some progress while searching because it takes some time