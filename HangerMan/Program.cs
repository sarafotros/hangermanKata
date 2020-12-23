using System;
using System.Collections.Generic;
using System.Text;

namespace HangerMan
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Hangman Game");
            Console.WriteLine("Choose a word to run the game:");
            var secretWord = Console.ReadLine();
            var hangerGame = new HangerManGame(secretWord);
            
            Console.WriteLine("word length: "+ hangerGame.GetWordLength());
            Console.WriteLine(hangerGame.RevealedGuess());
            Console.WriteLine("Type your guess");
            while (hangerGame.Status() == GameStatus.InProgress)
            {
                var guess = Console.ReadKey();
                var result = hangerGame.Guess(guess.KeyChar);
                
                if (result == GuessResult.IncorrectGuess)
                {
                    var incorrectGuesses = string.Join(",", hangerGame.IncorrectGuesses());
                    Console.WriteLine($"\nincorrect guesses: {incorrectGuesses}");
                }
               
                Console.WriteLine( hangerGame.RevealedGuess());
            }

            Console.WriteLine("Game Over!");
            
        }
        
    }
    
}