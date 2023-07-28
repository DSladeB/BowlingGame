using BowlingGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BowlingGameTest
{
    [TestClass]
    public class TheGame
    {
        [TestMethod]
        public void CalculateAllOnes()
        {
            //ARRANGE
            Game game = new Game();
            game.SetRolls(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 });

            //ACT
            int score = game.CalculateGame();

            //ASSERT
            Assert.AreEqual(20, score);
        }

        [TestMethod]
        public void AllStrikes()
        {
            //ARRANGE
            Game game = new Game();
            game.SetRolls(new int[] 
            {   10, 0, 
                10, 0, 
                10, 0, 
                10, 0, 
                10, 0, 
                10, 0, 
                10, 0, 
                10, 0, 
                10, 0, 
                10, 10, 10 });

            //ACT
            int score = game.CalculateGame();

            //ASSERT
            Assert.AreEqual(300, score);
        }

        [TestMethod]
        public void AllSparesFollowedByGutter()
        {
            //ARRANGE
            Game game = new Game();
            game.SetRolls(new int[]
            {   0, 10,
                0, 10,
                0, 10,
                0, 10,
                0, 10,
                0, 10,
                0, 10,
                0, 10,
                0, 10,
                0, 10, 0 });

            //ACT
            int score = game.CalculateGame();

            //ASSERT
            Assert.AreEqual(100, score);
        }

        [TestMethod]
        public void SampleGame()
        {
            //ARRANGE
            Game game = new Game();
            game.SetRolls(new int[]
            {   4, 3,
                7, 3,
                5, 2,
                8, 1,
                4, 6,
                2, 4,
                8, 0,
                8, 0,
                8, 2,
                10, 1, 7 });

            //ACT
            int score = game.CalculateGame();

            //ASSERT
            Assert.AreEqual(110, score);
        }
    }
}
