using System;
using System.Collections.Generic;
using System.Text;

namespace HangerMan
{
    public class HangerManGame
    {
        private const int Lives = 11;
        private readonly string _word;
        private readonly List<char> _incorrectGuesses = new List<char>();
        private readonly List<char> _correctGuesses = new List<char>();

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
            var lowercaseGuessedChar = char.ToLowerInvariant(guessedChar);

            // guessedChar = "cat"
            foreach (var character in _word)

            {
                var lowercaseCharacter = char.ToLowerInvariant(character);
                // 1. character = c
                // 2. character = a
                // 3. character = t

                bool doTheyMatch = lowercaseCharacter == lowercaseGuessedChar;
                if (doTheyMatch && !_correctGuesses.Contains(lowercaseGuessedChar))
                {
                    _correctGuesses.Add(lowercaseGuessedChar);
                    return GuessResult.CorrectGuess;
                }
            }

            if (!_incorrectGuesses.Contains(lowercaseGuessedChar))
            {

                _incorrectGuesses.Add(lowercaseGuessedChar);
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
            //issue because words with repeated characters 
            if (_correctGuesses.Count == GetWordLength())
            {
                return GameStatus.Won;
            }
            return _incorrectGuesses.Count < Lives ? GameStatus.InProgress : GameStatus.GameOver;
        }

        public string RevealedGuess()
        {
            var builder = new StringBuilder();

            foreach (var letter in _word.ToLower())
            {
                builder.Append(_correctGuesses.Contains(letter) ? letter : '_');
            }
            return builder.ToString();
        }

        public int LivesRemaining()
        {
            
            return Lives - _incorrectGuesses.Count;
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
// How many Lives left...
// win message
// test progress status