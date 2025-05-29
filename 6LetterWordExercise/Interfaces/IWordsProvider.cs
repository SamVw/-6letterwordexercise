public interface IWordsProvider
{
    public Task<IEnumerable<string>> GetWords();
}