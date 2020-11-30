using System;
using System.Text;

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
            var builder = new StringBuilder();
            Console.WriteLine(builder.Append('_', hangerGame.GetWordLength()));
            

        }
    }
}