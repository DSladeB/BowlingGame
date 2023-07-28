using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame
{
    public class Game
    {
        private Frame[] frames;

        public Game()
        {
            frames = new Frame[10];
            frames[9] = new Frame();
            for (int i = 8; i >= 0; i--) 
            { 
                frames[i] = new Frame();

                frames[i].NextFrame = frames[i + 1];
            }
        }

        public void SetRolls(int[] rolls)
        {
            if (rolls.Length == 21)
            {
                for (int i = 0; i < frames.Length - 1; i++)
                {
                    frames[i].SetRolls(new int[] { rolls[i*2], rolls[i*2+1] });
                }
                frames[9].SetRolls(new int[] { rolls[18], rolls[19], rolls[20] });
            }
        }

        public int CalculateGame()
        {
            int score = 0;
            for (int i = 0; i < frames.Length - 1; i++)
            {
                score = frames[i].CalculateFrameScore(score, frames[i + 1]);
            }
            score = frames[9].CalculateFrameScore(score);

            return score;
        }
    }
}
