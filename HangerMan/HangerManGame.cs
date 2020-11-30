using System.Collections.Generic;

namespace HangerMan
{
    public class HangerManGame
    {
        private string _word;
        private List<char> _incorrectGuesses = new List<char>();
        
        public HangerManGame(string word)
        {
            _word = word;
        }

        public int GetWordLength()
        {
            return _word.Length;
        }

        public bool Guess(char guessedChar)
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
            _incorrectGuesses.Add(guessedChar);
            return false;
        }

        public List<char> IncorrectGuesses()
        {
            return _incorrectGuesses;
        }
    }
}