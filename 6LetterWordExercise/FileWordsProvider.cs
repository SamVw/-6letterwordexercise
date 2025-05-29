
class FileWordsProvider(string path) : IWordsProvider
{
    public async Task<IEnumerable<string>> GetWords()
    {
        return await File.ReadAllLinesAsync(path);
    }
}