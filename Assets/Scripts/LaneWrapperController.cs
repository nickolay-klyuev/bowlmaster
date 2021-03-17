using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneWrapperController : MonoBehaviour
{
    private PinSetterController pinSetterController;

    // Start is called before the first frame update
    void Start()
    {
        pinSetterController = GameObject.FindObjectOfType<PinSetterController>();
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name == "Ball")
        {
            pinSetterController.SetBallOutOfPlay(true);
        }
    }
}
