using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector3 velocity;

    private Rigidbody thisRigidbody;
    private AudioSource thisAudio;
    private bool isBallLaunched = false;

    // Start is called before the first frame update
    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();
        thisAudio = GetComponent<AudioSource>();
        
        thisRigidbody.useGravity = false;
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
}
