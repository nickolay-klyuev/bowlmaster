using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetterController : MonoBehaviour
{
    public Text standingDisplay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        standingDisplay.text = CountStanding().ToString();
    }

    public int CountStanding()
    {
        int count = 0;

        PinController[] pinControllers = GameObject.FindObjectsOfType<PinController>();

        foreach(PinController pinController in pinControllers)
        {
            if (pinController.IsStanding())
            {
                count++;
            }
        }

        return count;
    }
}
