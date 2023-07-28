namespace BowlingGame
{
    public class Frame
    {
        private List<int> frameRolls = new List<int>();
        public Frame? NextFrame { get; set; }


        public List<int> GetFrameRolls()
        {
            return frameRolls;
        }
        public void SetRolls(int[] rolls)
        {
            //Don't add second roll for non-last frame Strike
            if (rolls[0] == 10 && NextFrame != null)
            {
                frameRolls.Add(rolls[0]);
            }    
             else
            {
                foreach (int roll in rolls)
                {
                    frameRolls.Add(roll);
                }
            }
        }

        public int CalculateFrameScore(int previousScore, Frame? nextFrame = null)
        {
            foreach(var roll in frameRolls)
            {
                Console.Write($" {roll} ");
            }
            int frameScore = frameRolls.Sum();

            if (frameRolls[0] == 10 && nextFrame != null)
            {
                frameScore += nextFrame.GetNextRolls(2);
            }
            else if (frameScore == 10 && nextFrame != null)
            {
                frameScore += nextFrame.GetNextRolls(1);
            }

            return frameScore + previousScore;
        }

        public int GetNextRolls(int count)
        {
            int score = 0;

            for(int i = 0; i< count && i<= frameRolls.Count; i++)
            {
                score += frameRolls[i];
                if (count > frameRolls.Count)
                {
                    score += NextFrame.GetNextRolls(count - frameRolls.Count);
                    break;
                }
            }
            return score;
        }

    }
}
