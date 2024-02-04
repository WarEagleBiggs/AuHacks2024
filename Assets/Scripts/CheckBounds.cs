using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBounds : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Bounds")
        {
            Debug.Log("OUT");
            this.transform.position = new Vector3(0, 0, 0);
        }
    }
}
