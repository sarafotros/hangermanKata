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

        public HangerManGame(IWordProvider wordProvider)
        {
            _word = wordProvider.Word;
        }

        public int GetWordLength()
        {
            return _word.Length;
        }

        public Result GuessResult(char guessedChar)
        {
            var lowercaseGuessedChar = char.ToLowerInvariant(guessedChar);

            if (IsCorrectGuess(lowercaseGuessedChar)) return Result.CorrectGuess;

            if (!_incorrectGuesses.Contains(lowercaseGuessedChar))
            {
                _incorrectGuesses.Add(lowercaseGuessedChar);
                return Result.IncorrectGuess;
            }
            
            return Result.RepeatedGuess;
        }

        private bool IsCorrectGuess(char guessedChar)
        {
            foreach (var character in _word)
            {
                var lowercaseCharacter = char.ToLowerInvariant(character);
                bool doTheyMatch = lowercaseCharacter == guessedChar;

                if (doTheyMatch && !_correctGuesses.Contains(guessedChar))
                {
                    _correctGuesses.Add(guessedChar);
                    {
                        return true;
                    }
                }
            }

            return false;
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
            foreach (var character in _word)
            {
                if (!_correctGuesses.Contains(character))
                {
                    return HasLiveRemaining() ? GameStatus.InProgress : GameStatus.GameOver;
                }
            }
            return GameStatus.Won;
        }

        private bool HasLiveRemaining()
        {
            return _incorrectGuesses.Count < Lives;
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
    public enum Result
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