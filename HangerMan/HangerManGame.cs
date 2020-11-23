namespace HangerMan
{
    public class HangerManGame
    {
        private string _word;
        
        public HangerManGame(string word)
        {
            _word = word;
        }

        public int GetWordLength()
        {
            return _word.Length;
        }

        public bool ContainsTheChar(char guessedChar)
        {
            // guessedChar = "cat"
            foreach (var character in _word)
            {
                // 1. character = c
                // 2. character = a
                // 3. character = t
                
                bool doTheyMatch = character == guessedChar;
                if (doTheyMatch) return true;
            }

            return false;
        }
    }
}