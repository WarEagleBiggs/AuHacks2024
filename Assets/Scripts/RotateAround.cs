using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class RotateAround : MonoBehaviour
{

    [SerializeField] private Transform Player;

    [SerializeField] private float MouseSpeed = 3;

    [SerializeField] private float orbitDampening = 10;

    private Vector3 localRot;
    

    void Update()
    {
        transform.position = Player.position;

        localRot.x += Input.GetAxis("Mouse X") * MouseSpeed;
        localRot.y -= Input.GetAxis("Mouse Y") * MouseSpeed;

        //localRot.y = math.clamp(localRot.y, 0f, 80f);

        Quaternion QT = Quaternion.Euler(localRot.x, localRot.y, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, QT,
            Time.deltaTime * orbitDampening);

    }
}
