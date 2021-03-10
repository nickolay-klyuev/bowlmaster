using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetterController : MonoBehaviour
{
    public Text standingDisplay;

    private bool ballEnteredBox = false;

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
