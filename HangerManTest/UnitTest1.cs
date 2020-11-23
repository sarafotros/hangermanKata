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
        [Fact]
        public void ReturnsCorrectLength()
        {
            var hangerManGame = new HangerManGame("cat");
            var  wordLength = hangerManGame.GetWordLength();
            
            Assert.Equal(3, wordLength);
        }

        [Fact]
        public void ReturnsTrueIfContainsTheLetter()
        {
            var hangerManGame = new HangerManGame("cat");
            var isContain = hangerManGame.ContainsTheChar('c');
            
            Assert.True(isContain);
        }

        [Fact]
        public void ReturnsTrueIfContainsTheLetter2()
        {
            var hangerManGame = new HangerManGame("cat");
            var isContain = hangerManGame.ContainsTheChar('a');
            
            Assert.True(isContain);
        }
    }
}