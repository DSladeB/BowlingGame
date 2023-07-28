using BowlingGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BowlingGameTest
{
    [TestClass]
    public class TheFrame
    {
        [TestMethod]
        public void AllZeros()
        {
            //ARRANGE
            Frame[] frames = new Frame[10];
            for (int i = 0; i < frames.Length; i++) { frames[i] = new Frame(); }

            for (int i = 0; i < 9; i++)
            {
                frames[i].SetRolls(new int[] { 0, 0 });
                frames[i].NextFrame = frames[i + 1];
            }
            frames[9].SetRolls(new int[] { 0, 0 });

            //ACT
            int score = 0;
            for (int i = 0; i < frames.Length - 1; i++)
            {
                score = frames[i].CalculateFrameScore(score, frames[i + 1]);
            }

            //ASSERT
            Assert.AreEqual(score, 0);
        }

        [TestMethod]
        public void AllOnes()
        {
            //ARRANGE
            Frame[] frames = new Frame[10];
            for (int i = 0; i < frames.Length; i++) { frames[i] = new Frame(); }

            for (int i = 0; i < 9; i++)
            {
                frames[i].SetRolls(new int[] { 1, 1 });
                frames[i].NextFrame = frames[i + 1];
            }
            frames[9].SetRolls(new int[] { 1, 1 });

            //ACT
            int score = 0;
            for (int i = 0; i < frames.Length - 1; i++)
            {
                score = frames[i].CalculateFrameScore(score, frames[i + 1]);
            }
            score = frames[9].CalculateFrameScore(score);

            //ASSERT
            Assert.AreEqual(20, score);
        }

        [TestMethod]
        public void AllSparesFollowedByGutter()
        {
            //ARRANGE
            Frame[] frames = new Frame[10];
            for (int i = 0; i < frames.Length; i++) { frames[i] = new Frame(); }

            for (int i = 0; i < 9; i++)
            {
                frames[i].SetRolls(new int[] { 0, 10 });
                frames[i].NextFrame = frames[i + 1];
            }
            frames[9].SetRolls(new int[] { 0, 10, 0 });

            //ACT
            int score = 0;
            for (int i = 0; i < frames.Length - 1; i++)
            {
                score = frames[i].CalculateFrameScore(score, frames[i + 1]);
            }
            score = frames[9].CalculateFrameScore(score);

            //ASSERT
            Assert.AreEqual(100, score);
        }

        [TestMethod]
        public void AllSparesNoGutters()
        {
            //ARRANGE
            Frame[] frames = new Frame[10];
            for (int i = 0; i < frames.Length; i++) { frames[i] = new Frame(); }

            for (int i = 0; i < 9; i++)
            {
                frames[i].SetRolls(new int[] { 4, 6 });
                frames[i].NextFrame = frames[i + 1];
            }
            frames[9].SetRolls(new int[] { 4, 6, 4 });

            //ACT
            int score = 0;
            for (int i = 0; i < frames.Length - 1; i++)
            {
                score = frames[i].CalculateFrameScore(score, frames[i + 1]);
            }
            score = frames[9].CalculateFrameScore(score);

            //ASSERT
            Assert.AreEqual(140, score);
        }

        [TestMethod]
        public void AllStrikes()
        {
            //ARRANGE
            Frame[] frames = new Frame[10];
            for (int i = 0; i < frames.Length; i++) { frames[i] = new Frame(); }

            for (int i = 0; i < 9; i++)
            {
                frames[i].SetRolls(new int[] { 10 });
                frames[i].NextFrame = frames[i + 1];
            }
            frames[9].SetRolls(new int[] { 10, 10, 10 });

            //ACT
            int score = 0;
            for (int i = 0; i < frames.Length - 1; i++)
            {
                score = frames[i].CalculateFrameScore(score, frames[i + 1]);
            }
            score = frames[9].CalculateFrameScore(score);

            //ASSERT
            Assert.AreEqual(300, score);
        }

        [TestMethod]
        public void OneStrike()
        {
            //ARRANGE
            Frame[] frames = new Frame[10];
            for (int i = 0; i < frames.Length; i++) { frames[i] = new Frame(); }

            for (int i = 0; i < 9; i++)
            {
                frames[i].SetRolls(new int[] { 2, 2 });
                frames[i].NextFrame = frames[i + 1];
            }
            frames[4].SetRolls(new int[] { 10 });
            frames[9].SetRolls(new int[] { 2, 2 });

            //ACT
            int score = 0;
            for (int i = 0; i < frames.Length - 1; i++)
            {
                score = frames[i].CalculateFrameScore(score, frames[i + 1]);
            }
            score = frames[9].CalculateFrameScore(score);

            //ASSERT
            Assert.AreEqual(50, score);
        }

        [TestMethod]
        public void LastFrameStrike()
        {
            //ARRANGE
            Frame[] frames = new Frame[10];
            for (int i = 0; i < frames.Length; i++) { frames[i] = new Frame(); }

            for (int i = 0; i < 9; i++)
            {
                frames[i].SetRolls(new int[] { 10 });
                frames[i].NextFrame = frames[i + 1];
            }
            frames[9].SetRolls(new int[] { 2, 2 });

            //ACT
            int score = 0;
            for (int i = 0; i < frames.Length - 1; i++)
            {
                score = frames[i].CalculateFrameScore(score, frames[i + 1]);
            }
            score = frames[9].CalculateFrameScore(score);

            //ASSERT
            Assert.AreEqual(250, score);
        }

        [TestMethod]
        public void SampleGame()
        {
            //ARRANGE
            Frame[] frames = new Frame[10];
            for (int i = 0; i < frames.Length; i++) { frames[i] = new Frame(); }
            for (int i = 0; i < 9; i++)
            {
                frames[i].NextFrame = frames[i + 1];
            }

            frames[0].SetRolls(new int[] { 4, 3 });
            frames[1].SetRolls(new int[] { 7, 3 });
            frames[2].SetRolls(new int[] { 5, 2 });
            frames[3].SetRolls(new int[] { 8, 1 });
            frames[4].SetRolls(new int[] { 4, 6 });
            frames[5].SetRolls(new int[] { 2, 4 });
            frames[6].SetRolls(new int[] { 8 });
            frames[7].SetRolls(new int[] { 8 });
            frames[8].SetRolls(new int[] { 8, 2 });
            frames[9].SetRolls(new int[] { 10, 1, 7 });

            //ACT
            int score = 0;
            for (int i = 0; i < frames.Length - 1; i++)
            {
                score = frames[i].CalculateFrameScore(score, frames[i + 1]);
            }
            score = frames[9].CalculateFrameScore(score);

            //ASSERT
            Assert.AreEqual(110, score);
        }

        [TestMethod]
        public void TryToAddRollAfterStrike()
        {
            //ARRANGE
            Frame frame = new Frame();
            Frame nextFrame = new Frame();
            frame.NextFrame = nextFrame;
            frame.SetRolls(new int[] { 10, 2 });
            //ACT
            List<int> actualRolls = frame.GetFrameRolls();
            //ASSERT
            Assert.IsTrue(actualRolls.Count.Equals(1));
        }
        [TestMethod]
        public void TryToAddRollAfterLastFrameStrike()
        {
            //ARRANGE
            Frame frame = new Frame();
            frame.SetRolls(new int[] { 10, 2, 2 });
            //ACT
            List<int> actualRolls = frame.GetFrameRolls();
            //ASSERT
            Assert.IsTrue(actualRolls.Count.Equals(3));
        }

        [TestMethod]
        public void AddRollAfterNonStrike()
        {
            //ARRANGE
            Frame frame = new Frame();
            Frame nextFrame = new Frame();
            frame.NextFrame = nextFrame;
            frame.SetRolls(new int[] { 9, 1 });
            //ACT
            List<int> actualRolls = frame.GetFrameRolls();
            //ASSERT
            Assert.IsTrue(actualRolls.Count.Equals(2));
        }

        //[TestMethod]

    }
}