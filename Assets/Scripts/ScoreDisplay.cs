using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text[] rollTexts, frameTexts;

    public void FillRolls(List<int> rolls)
    {
        string scoreString = FormatRolls(rolls);
        for (int i = 0; i < scoreString.Length; i++)
        {
            rollTexts[i].text = scoreString[i].ToString();
        }
    }

    public void FillFrames(List<int> frames)
    {
        for (int i = 0; i < frames.Count; i++)
        {
            frameTexts[i].text = frames[i].ToString();
        }
    }

    public static string FormatRolls (List<int> rolls)
    {
        string output = "";

        for (int i = 0; i < rolls.Count; i++)
        {
            if (i + 1 >= 19 && rolls[i] == 10)
            {
                output += "X";
            }
            else if (rolls[i] == 10)
            {
                output += "X ";
            }
            else if ((i + 1) % 2 == 0 && rolls[i - 1] + rolls[i] == 10)
            {
                output += "/";
            }
            else if (rolls[i] == 0)
            {
                output += "-";
            }
            else 
            {
                output += rolls[i].ToString();
            }
        }

        return output;
    }
}
