using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinController : MonoBehaviour
{
    public float standingThreshold;

    public bool IsStanding()
    {
        if (Mathf.Abs(transform.eulerAngles.x) > standingThreshold || 
            Mathf.Abs(transform.eulerAngles.z) > standingThreshold)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
