using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List<int> bowls = new List<int>();
    private PinSetterController pinSetterController;
    private BallController ballController;

    // Start is called before the first frame update
    void Start()
    {
        pinSetterController = GameObject.FindObjectOfType<PinSetterController>();
        ballController = GameObject.FindObjectOfType<BallController>();
    }

    public void Bowl(int pinsFall)
    {
        bowls.Add(pinsFall);

        ActionMaster.Action nextAction = ActionMaster.NextAction(bowls);
        pinSetterController.PerformAction(nextAction);
        ballController.Reset();
    }
}
