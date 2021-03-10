using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector3 velocity;

    private Rigidbody thisRigidbody;
    private AudioSource thisAudio;
    private bool isBallLaunched = false;
    private Vector3 startBallPosition;

    // Start is called before the first frame update
    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();
        thisAudio = GetComponent<AudioSource>();
        
        thisRigidbody.useGravity = false;

        startBallPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsBallLaunched()
    {
        return isBallLaunched;
    }

    public void Launch(Vector3 velocity)
    {
        isBallLaunched = true;
        thisRigidbody.useGravity = true;
        thisRigidbody.velocity = velocity;
        thisAudio.Play();
    }

    public void Reset()
    {
        isBallLaunched = false;
        Rigidbody rb = GetComponent<Rigidbody>();

        transform.position = startBallPosition;

        rb.velocity = new Vector3(0, 0, 0);
        rb.angularVelocity = new Vector3(0, 0, 0);
    }
}
