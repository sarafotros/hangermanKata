namespace HangerMan
{
    public interface IWordProvider
    {
        string Word { get; }
    }

    public class WordProvider : IWordProvider
    {
        public string Word { get; }

        public WordProvider( string word)
        {
            Word = word;
        }
    }
}