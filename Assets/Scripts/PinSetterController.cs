using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetterController : MonoBehaviour
{
    public GameObject pinsPrefab;
    
    private ActionMaster actionMaster = new ActionMaster();
    private Animator animator;
    private PinCounter pinCounter;
    private GameObject endScreen;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        pinCounter = GameObject.FindObjectOfType<PinCounter>();
        endScreen = GameObject.Find("End Screen");
        endScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LaunchAvailable()
    {
        pinCounter.SetAvailableColor();
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

    void OnTriggerExit(Collider collider)
    {
        GameObject that = collider.gameObject;

        if (that.GetComponentInParent<PinController>() != null)
        {
            Destroy(that.transform.parent.gameObject);
        }
    }

    public void PerformAction(ActionMaster.Action action)
    {
        if (action == ActionMaster.Action.Tidy)
        {
            animator.SetTrigger("tidyTrigger");
        }
        else if (action == ActionMaster.Action.EndTurn)
        {
            animator.SetTrigger("resetTrigger");
            pinCounter.Reset();
        }
        else if (action == ActionMaster.Action.Reset)
        {
            animator.SetTrigger("resetTrigger");
            pinCounter.Reset();
        }
        else if (action == ActionMaster.Action.EndGame)
        {
            endScreen.SetActive(true);
        }
    }
}
