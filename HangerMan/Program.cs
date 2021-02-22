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
            Console.WriteLine("Would you like to choose your own word? [Y/N]");
            var chooseOwnWord = Console.ReadLine();

            IWordProvider wordProvider; 

            if (chooseOwnWord == "Y")
            {            
                Console.WriteLine("Choose a word to run the game:");
                string secretWord = Console.ReadLine();

                wordProvider = new WordProvider(secretWord);
            }

            else
            {
                wordProvider = new ApiWordProvider(new DateProvider());
            }

            wordProvider = new RandomWordProvider();
            var hangerGame = new HangerManGame(wordProvider);

            Console.WriteLine("word length: "+ hangerGame.GetWordLength());
            Console.WriteLine(hangerGame.RevealedGuess());
            Console.WriteLine("Type your guess");
            while (hangerGame.Status() == GameStatus.InProgress)
            {
                var guess = Console.ReadKey();
                Console.WriteLine();
                var result = hangerGame.GuessResult(guess.KeyChar);
                
                if (result == Result.IncorrectGuess)
                {
                    var incorrectGuesses = string.Join(",", hangerGame.IncorrectGuesses());
                    Console.WriteLine($"lives remaining: {hangerGame.LivesRemaining()}");
                    Console.WriteLine($"incorrect guesses: {incorrectGuesses}");
                }
                Console.WriteLine($"current guess: {hangerGame.RevealedGuess()}");
            }

            if (hangerGame.Status() == GameStatus.Won)
            {
                Console.WriteLine("Woohoo, you won!");
            }
            else
            { 
                Console.WriteLine("Game Over!");
                Console.WriteLine($"The secret word was {hangerGame.SecretWord()}");
            }
            
        }
        
    }
    
}