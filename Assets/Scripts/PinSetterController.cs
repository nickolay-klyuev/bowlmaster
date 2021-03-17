using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetterController : MonoBehaviour
{
    public Text standingDisplay;
    public GameObject pinsPrefab;
    
    private bool ballOutOfPlay = false;
    private int lastStandingCount = -1;
    private float lastChangeTime;
    private BallController ballController;
    private ActionMaster actionMaster = new ActionMaster();
    private Animator animator;
    private int lastSettledCount = 10;

    // Start is called before the first frame update
    void Start()
    {
        ballController = GameObject.FindObjectOfType<BallController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        standingDisplay.text = CountStanding().ToString();
        
        if (ballOutOfPlay)
        {
            CheckStanding();
            standingDisplay.color = Color.red;
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
        Instantiate(pinsPrefab, new Vector3(0, 50, 0), Quaternion.identity);
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
        int standing = CountStanding();
        int pinsFall = lastSettledCount - standing;
        lastSettledCount = standing;
        ActionMaster.Action action = actionMaster.Bowl(pinsFall);

        if (action == ActionMaster.Action.Tidy)
        {
            animator.SetTrigger("tidyTrigger");
        }
        else if (action == ActionMaster.Action.EndTurn)
        {
            ResetTrigger();
        }
        else if (action == ActionMaster.Action.Reset)
        {
            ResetTrigger();
        }
        else if (action == ActionMaster.Action.EndGame)
        {
            throw new UnityException("Don't exist yet");
        }

        ballController.Reset();
        lastStandingCount = -1;
        ballOutOfPlay = false;
        standingDisplay.color = Color.green;
    }

    private void ResetTrigger()
    {
        animator.SetTrigger("resetTrigger");
        lastSettledCount = 10;
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

    void OnTriggerExit(Collider collider)
    {
        GameObject that = collider.gameObject;

        if (that.GetComponentInParent<PinController>() != null)
        {
            Destroy(that.transform.parent.gameObject);
        }
    }

    public void SetBallOutOfPlay(bool isOut)
    {
        ballOutOfPlay = isOut;
    }
}
