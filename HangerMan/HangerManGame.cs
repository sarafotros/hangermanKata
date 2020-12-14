using System;
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

        public GuessResult Guess(char guessedChar)
        {
            // guessedChar = "cat"
            foreach (var character in _word)
            {
                // 1. character = c
                // 2. character = a
                // 3. character = t
                
                bool doTheyMatch = character == guessedChar;
                if (doTheyMatch) return GuessResult.CorrectGuess;
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

        public GameStatus Status()
        {
            return _incorrectGuesses.Count < 11 ? GameStatus.InProgress : GameStatus.GameOver;
        }
        
    }

    public enum GameStatus
    {
        InProgress,
        GameOver,
    }
    public enum GuessResult
    {
        CorrectGuess,
        IncorrectGuess,
        RepeatedGuess
    }
}