using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BallController))]
public class DragLaunch : MonoBehaviour
{
    private Vector3 dragStart, dragEnd;
    private float timeStart, timeEnd;
    private BallController ballController;

    // Start is called before the first frame update
    void Start()
    {
        ballController = GetComponent<BallController>();
    }

    public void MoveStart(float amount)
    {
        if (ballController.IsBallLaunched())
        {
            return;
        }

        float ballX = ballController.transform.position.x + amount;
        float thisAmount = amount;

        if (ballX > 50 || ballX < -50)
        {
            thisAmount = 0;
        }

        ballController.transform.position += new Vector3(thisAmount, 0, 0);
    }

    public void DragStart()
    {
        dragStart = Input.mousePosition;
        timeStart = Time.time;
    }

    public void DragEnd()
    {
        dragEnd = Input.mousePosition;
        timeEnd = Time.time;

        float dragDuration = timeEnd - timeStart;

        float launchSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
        float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;

        Vector3 launchVelocity = new Vector3(launchSpeedX, 0, launchSpeedZ);

        ballController.Launch(launchVelocity);
    }
}
