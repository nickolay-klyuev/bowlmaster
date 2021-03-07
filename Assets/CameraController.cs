using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject ball;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float z = transform.position.z;

        if (z < 1500f)
        {
            transform.position = ball.transform.position + offset;
        }
    }
}
