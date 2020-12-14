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
            var builder = new StringBuilder();
            Console.WriteLine(builder.Append('-', hangerGame.GetWordLength()));
            Console.WriteLine("Type your guess");
            while (hangerGame.Status() == GameStatus.InProgress)
            {
                var guess = Console.ReadKey();
                hangerGame.Guess(guess.KeyChar);
                var incorrectGuesses = string.Join(",", hangerGame.IncorrectGuesses());
                Console.WriteLine($"\nincorrect guesses: {incorrectGuesses}");  
            }

            Console.WriteLine("Game Over!");
            
        }
        
    }
    
}