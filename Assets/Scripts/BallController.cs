using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector3 velocity;

    private Rigidbody thisRigidbody;
    private AudioSource thisAudio;

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

    public void Launch(Vector3 velocity)
    {
        thisRigidbody.useGravity = true;
        thisRigidbody.velocity = velocity;
        thisAudio.Play();
    }
}
