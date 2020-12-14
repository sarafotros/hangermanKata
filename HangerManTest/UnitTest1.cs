using System;
using HangerMan;
using Xunit;

// 1. secret word entered by Player 1
// 2. player 2 finds out the length of the word, how many letters there are
// 3. player 2 guesses a letter
// 4. If the letter is already in the incorrect guesses list, inform player it's already been used
// 5. If the letter is in the word, the letter is correct and filled in and the player doesn't lose a life
// 6. If the letter isn't in the word, the letter is added to a list of incorrect guesses and the player loses a life
// 7. If all letters guessed correctly then player 2 wins
// 8. If player loses all lives before word is guessed then player 1 wins

namespace HangerManTest
{
    public class UnitTest1
    {
        private readonly HangerManGame _hangerManGame;

        public UnitTest1()
        {
            _hangerManGame = new HangerManGame("cat");
        }
        [Fact]
        public void ReturnsCorrectLength()
        {
            var  wordLength = _hangerManGame.GetWordLength();
            
            Assert.Equal(3, wordLength);
        }

        [Fact]
        public void ReturnsTrueIfContainsTheLetter()
        {
            var contains = _hangerManGame.Guess('c');

            Assert.Equal(GuessResult.CorrectGuess,contains);
        }
        [Fact]
        public void ReturnsFalseIfTheWordDoesNotContainTheGuessedLetter()
        {
            var contains = _hangerManGame.Guess('y');
            
            Assert.Equal(GuessResult.IncorrectGuess,contains);
        }
        

        [Fact]
        public void ReturnsTrueIfContainsTheLetter2()
        {
            var contains = _hangerManGame.Guess('a');
            
            Assert.Equal(GuessResult.CorrectGuess,contains);
        }
        
        [Fact]
        public void IfGuessIsIncorrect_AddLetterToIncorrectGuessList()
        {
            
            _hangerManGame.Guess('y');

            var result = _hangerManGame.IncorrectGuesses();
            
            Assert.Contains('y', result);
        }
        [Fact]
        public void IfGuessIsCorrect_DoNotAddLetterToIncorrectGuessList()
        {
            _hangerManGame.Guess('a');

            var result = _hangerManGame.IncorrectGuesses();
            
            Assert.DoesNotContain('a', result);
        }

        [Fact]
        public void IfNumberOfIncorrectGuessesIsEleven_ReturnGameOver()
        {
            _hangerManGame.Guess('a');
            _hangerManGame.Guess('e');
            _hangerManGame.Guess('r');
            _hangerManGame.Guess('t');
            _hangerManGame.Guess('y');
            _hangerManGame.Guess('u');
            _hangerManGame.Guess('i');
            _hangerManGame.Guess('o');
            _hangerManGame.Guess('q');
            _hangerManGame.Guess('d');
            _hangerManGame.Guess('v');
            _hangerManGame.Guess('x');
            _hangerManGame.Guess('z');
            
            var status = _hangerManGame.Status();
            Assert.Equal(GameStatus.GameOver, status);
        }

        [Fact]
        public void IfGuessIncorrectGuessIsRepeated_DoNotAddToIncorrectGuess()
        {
            _hangerManGame.Guess('z');
            _hangerManGame.Guess('z');
            var incorrect = _hangerManGame.IncorrectGuesses();
            Assert.Equal(1, incorrect.Count);  
            Assert.Contains('z', incorrect);  
        }
    }
}