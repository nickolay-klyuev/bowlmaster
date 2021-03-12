using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinController : MonoBehaviour
{
    public float standingThreshold;
    public float distToRaise = 40f;

    private Rigidbody thisRigidbody;

    public bool IsStanding()
    {
        if (Mathf.Abs(transform.rotation.x) < standingThreshold && 
            Mathf.Abs(transform.rotation.z) < standingThreshold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RaiseIfStanding()
    {
        if (IsStanding())
        {
            transform.Translate(new Vector3(0, distToRaise, 0), Space.World);
            thisRigidbody.useGravity = false;
        }
    }

    public void Lower()
    {
        transform.Translate(new Vector3(0, -distToRaise, 0), Space.World);
        thisRigidbody.useGravity = true;
        transform.eulerAngles = new Vector3(0, 0, 0);
    }
}
