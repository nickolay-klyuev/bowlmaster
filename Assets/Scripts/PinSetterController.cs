using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetterController : MonoBehaviour
{
    public int lastStandingCount = -1;
    public Text standingDisplay;

    private bool ballEnteredBox = false;
    private float lastChangeTime;
    private BallController ballController;

    // Start is called before the first frame update
    void Start()
    {
        ballController = GameObject.FindObjectOfType<BallController>();
    }

    // Update is called once per frame
    void Update()
    {
        standingDisplay.text = CountStanding().ToString();
        
        if (ballEnteredBox)
        {
            CheckStanding();
        }
    }

    public void RaisePins()
    {
        foreach(PinController pinController in GameObject.FindObjectsOfType<PinController>())
        {
            pinController.RaiseIfStanding();
        }
    }

    public void LowerPins()
    {
        foreach(PinController pinController in GameObject.FindObjectsOfType<PinController>())
        {
            pinController.Lower();
        }
    }

    public void RenewPins()
    {

    }

    void CheckStanding()
    {
        int currentStanding = CountStanding();

        if (currentStanding != lastStandingCount)
        {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }

        float settleTime = 3f;
        if ((Time.time - lastChangeTime) > settleTime)
        {
            PinsHaveSettled();
        }
    }

    void PinsHaveSettled()
    {
        ballController.Reset();
        lastStandingCount = -1;
        ballEnteredBox = false;
        standingDisplay.color = Color.green;
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

    void OnTriggerEnter(Collider collider)
    {
        GameObject that = collider.gameObject;

        if (that.GetComponent<BallController>() != null)
        {
            ballEnteredBox = true;
            standingDisplay.color = Color.red;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        GameObject that = collider.gameObject;

        if (that.GetComponentInParent<PinController>() != null)
        {
            Destroy(that.transform.parent.gameObject);
        }
    }
}
