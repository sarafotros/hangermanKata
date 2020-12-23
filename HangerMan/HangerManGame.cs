using System;
using System.Collections.Generic;
using System.Text;

namespace HangerMan
{
    public class HangerManGame
    {
        private string _word;
        private List<char> _incorrectGuesses = new List<char>();
        private List<char> _correctGuesses = new List<char>();

        public HangerManGame(string word)
        {
            _word = word;
        }

        public int GetWordLength()
        {
            return _word.Length;
        }

        public GuessResult Guess(char guessedChar)
        {
            // guessedChar = "cat"
            foreach (var character in _word)
            {
                // 1. character = c
                // 2. character = a
                // 3. character = t
                
                bool doTheyMatch = character == guessedChar;
                if (doTheyMatch)
                {
                    _correctGuesses.Add(guessedChar);
                    return GuessResult.CorrectGuess;
                }
            }

            if (!_incorrectGuesses.Contains(guessedChar))
            {
                _incorrectGuesses.Add(guessedChar);
                return GuessResult.IncorrectGuess;
            }
            
            return GuessResult.RepeatedGuess;
        }

        public List<char> IncorrectGuesses()
        {
            return _incorrectGuesses;
        }
        
        public List<char> CorrectGuesses()
        {
            return _correctGuesses;
        }

        public GameStatus Status()
        {
            return _incorrectGuesses.Count < 11 ? GameStatus.InProgress : GameStatus.GameOver;
        }

        public string RevealedGuess()
        {
            var builder = new StringBuilder();

            foreach (var letter in _word)
            {
                builder.Append(_correctGuesses.Contains(letter) ? letter : '_');
            }
            return builder.ToString();
        }
        
    }

    public enum GameStatus
    {
        InProgress,
        GameOver,
        Won
    }
    public enum GuessResult
    {
        CorrectGuess,
        IncorrectGuess,
        RepeatedGuess
    }
}


// Scores
// How many lives left...
// win message
// test progress status