using System;

namespace HangerMan
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hangreman Game");
            Console.WriteLine("Choose a word to run the game:");
            var secretWord = Console.ReadLine();
            var hangerGame = new HangerManGame(secretWord);
            
            Console.WriteLine("word length: "+ hangerGame.GetWordLength());
            
        }
    }
}