using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private List<int> bowls = new List<int>();
    private PinSetterController pinSetterController;
    private BallController ballController;
    private ScoreDisplay scoreDisplay;

    // Start is called before the first frame update
    void Start()
    {
        pinSetterController = GameObject.FindObjectOfType<PinSetterController>();
        ballController = GameObject.FindObjectOfType<BallController>();
        scoreDisplay = GameManager.FindObjectOfType<ScoreDisplay>();
    }

    public void Bowl(int pinsFall)
    {
        bowls.Add(pinsFall);

        ActionMaster.Action nextAction = ActionMaster.NextAction(bowls);
        pinSetterController.PerformAction(nextAction);
        ballController.Reset();

        scoreDisplay.FillRolls(bowls);
        scoreDisplay.FillFrames(ScoreMaster.ScoreCumulative(bowls));
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
