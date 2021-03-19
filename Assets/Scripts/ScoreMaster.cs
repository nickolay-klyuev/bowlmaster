using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMaster
{
    public static List<int> ScoreCumulative(List<int> rolls)
    {
        List<int> cumulativeScores = new List<int>();
        int runningTotal = 0;

        foreach(int frameScore in ScoreFrames(rolls))
        {
            runningTotal += frameScore;
            cumulativeScores.Add(runningTotal);
        }

        return cumulativeScores;
    }

    public static List<int> ScoreFrames(List<int> rolls)
    {
        List<int> frameList = new List<int>();

        for (int i = 1; i < rolls.Count; i += 2)
        {
            int frame = rolls[i - 1] + rolls[i];
            
            if (frame >= 10 && rolls.Count > i + 1)
            {
                frame += rolls[i + 1];
            }
            else if (frame >= 10)
            {
                continue;
            }

            frameList.Add(frame);
        }

        return frameList;
    }
}
