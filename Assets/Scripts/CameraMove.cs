using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject Camera;

    public Transform Position0;

    public Transform Position1;

    public bool isPos1;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Swap"))
        {
            //swap
            if (!isPos1)
            {
                Camera.transform.position = Position1.transform.position;
                Camera.transform.rotation = Position1.transform.rotation;
                isPos1 = true;
            } else if (isPos1)
            {
                Camera.transform.position = Position0.transform.position;
                Camera.transform.rotation = Position0.transform.rotation;
                isPos1 = false;
            }
        }
    }
}
