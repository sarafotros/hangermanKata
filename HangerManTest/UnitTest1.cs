using System;
using HangerMan;
using Moq;
using Xunit;

// 1. secret word entered by Player 1
// 2. player 2 finds out the length of the word, how many letters there are
// 3. player 2 guesses a letter
// 4. If the letter is already in the incorrect guesses list, inform player it's already been used
// 5. If the letter is in the word, the letter is correct and filled in and the player doesn't lose a life
// 6. If the letter isn't in the word, the letter is added to a list of incorrect guesses and the player loses a life
// 7. If all letters guessed correctly then player 2 wins
// 8. If player loses all lives before word is guessed then player 1 wins
// Alphanumeric characters 

namespace HangerManTest
{
    public class UnitTest1
    {
        private readonly HangerManGame _hangerManGame;
        private readonly Mock<IWordProvider> wordProvider;

        
        public UnitTest1()
        {
            wordProvider = new Mock<IWordProvider>();
            wordProvider.Setup(x => x.Word).Returns("cat");
            _hangerManGame = new HangerManGame(wordProvider.Object);
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
            var contains = _hangerManGame.GuessResult('c');

            Assert.Equal(Result.CorrectGuess,contains);
        }
        [Fact]
        public void ReturnsFalseIfTheWordDoesNotContainTheGuessedLetter()
        {
            var contains = _hangerManGame.GuessResult('y');
            
            Assert.Equal(Result.IncorrectGuess,contains);
        }

        [Fact]
        public void ReturnsTrueIfContainsTheLetter2()
        {
            var contains = _hangerManGame.GuessResult('a');
            
            Assert.Equal(Result.CorrectGuess,contains);
        }
        
        [Fact]
        public void IfGuessIsIncorrect_AddLetterToIncorrectGuessList()
        {
            
            _hangerManGame.GuessResult('y');

            var result = _hangerManGame.IncorrectGuesses();
            
            Assert.Contains('y', result);
        }
        [Fact]
        public void IfGuessIsCorrect_DoNotAddLetterToIncorrectGuessList()
        {
            _hangerManGame.GuessResult('a');

            var result = _hangerManGame.IncorrectGuesses();
            
            Assert.DoesNotContain('a', result);
        }

        [Fact]
        public void IfNumberOfIncorrectGuessesIsEleven_ReturnGameOver()
        {
            _hangerManGame.GuessResult('a');
            _hangerManGame.GuessResult('e');
            _hangerManGame.GuessResult('r');
            _hangerManGame.GuessResult('t');
            _hangerManGame.GuessResult('y');
            _hangerManGame.GuessResult('u');
            _hangerManGame.GuessResult('i');
            _hangerManGame.GuessResult('o');
            _hangerManGame.GuessResult('q');
            _hangerManGame.GuessResult('d');
            _hangerManGame.GuessResult('v');
            _hangerManGame.GuessResult('x');
            _hangerManGame.GuessResult('z');
            
            var status = _hangerManGame.Status();
            Assert.Equal(GameStatus.GameOver, status);
        }

        [Fact]
        public void IfGuessIncorrectGuessIsRepeated_DoNotAddToIncorrectGuess()
        {
            var firstGuess = _hangerManGame.GuessResult('z');
            Assert.Equal(firstGuess,Result.IncorrectGuess);
            
            var repeatedGuess = _hangerManGame.GuessResult('z');
            Assert.Equal(repeatedGuess,Result.RepeatedGuess);
            
            var incorrect = _hangerManGame.IncorrectGuesses();
            Assert.Equal(1, incorrect.Count);  
            Assert.Contains('z', incorrect);
        }

        [Fact]
        public void IfGuessCorrect_ReturnCorrectGuess()
        {
            var correctGuess = _hangerManGame.GuessResult('C');
            Assert.Equal(correctGuess, Result.CorrectGuess);
        }

        [Fact]
        public void IfNoGuess_RevealedGuessShouldBeAllUnderScore()
        {
            var revealedWord = _hangerManGame.RevealedGuess();
            Assert.Equal("___", revealedWord);
        }
        
        [Fact]
        public void IfGuessIsCorrect_RevealedGuessShouldRevealCorrectLetters()
        {
            _hangerManGame.GuessResult('c');
            var correctGuesse = _hangerManGame.CorrectGuesses();
            Assert.Contains('c', correctGuesse);
            
            var revealedWord = _hangerManGame.RevealedGuess();
            Assert.Equal("c__", revealedWord);
        }
        
        [Fact]
        public void IfGuessesIsCorrect_RevealedGuessShouldRevealCorrectLetters()
        {
            _hangerManGame.GuessResult('c');
            _hangerManGame.GuessResult('a');
            var correctGuesses = _hangerManGame.CorrectGuesses();
            Assert.Contains('c', correctGuesses);
            Assert.Contains('a', correctGuesses);
            
            var revealedWord = _hangerManGame.RevealedGuess();
            Assert.Equal("ca_", revealedWord);
        }
        
        [Fact]
        public void IfWordIsGuessed_GameStatusIsWon()
        {
            _hangerManGame.GuessResult('c');
            _hangerManGame.GuessResult('a');
            _hangerManGame.GuessResult('t');

            Assert.Equal( GameStatus.Won, _hangerManGame.Status());
        }

        [Fact]
        public void IfWordIsNotGuessed_GameStatusIsInProgress()
        {
            _hangerManGame.GuessResult('c');
            _hangerManGame.GuessResult('a');
            _hangerManGame.GuessResult('a');

            Assert.Equal(GameStatus.InProgress, _hangerManGame.Status());
        }

        [Fact]
        public void IgnoreLetterCasingForCorrectGuesses()
        {
            _hangerManGame.GuessResult('C');
            var correctGuesses = _hangerManGame.CorrectGuesses();

            Assert.Contains('c', correctGuesses);
        }

        [Fact]
        public void IgnoreLetterCasingForIncorrectGuesses()
        {
            _hangerManGame.GuessResult('D');
            var incorrectGuesses = _hangerManGame.IncorrectGuesses();

            Assert.Contains('d', incorrectGuesses);
        }

        [Fact]
        public void IgnoreLetterCasingForTwoIncorrectGuesses()
        {
            _hangerManGame.GuessResult('D');
            _hangerManGame.GuessResult('d');

            var incorrectGuesses = _hangerManGame.IncorrectGuesses();

            Assert.Contains('d', incorrectGuesses);
            Assert.Equal(1, incorrectGuesses.Count);
        }
        [Fact]
        public void LivesRemaining()
        {
            _hangerManGame.GuessResult('D');


            Assert.Equal(10, _hangerManGame.LivesRemaining());
        }

        [Fact]
        public void wordWithMultipleOfSameLetter()
        {
            wordProvider.Setup(x => x.Word).Returns("book");
            var hangermanGame = new HangerManGame(wordProvider.Object);
            hangermanGame.GuessResult('b');
            hangermanGame.GuessResult('o');
            hangermanGame.GuessResult('k');

            Assert.Equal(GameStatus.Won, hangermanGame.Status());
        }


    }
}