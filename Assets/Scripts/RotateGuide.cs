using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGuide : MonoBehaviour
{
    public Transform playerTransform; // Assign this to the player's transform in the inspector
    

    void Update()
    {
        if (playerTransform != null)
        {
            transform.LookAt(playerTransform);
        }
    }
}
