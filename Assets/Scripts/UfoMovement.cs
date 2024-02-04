using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoMovement : MonoBehaviour
{
    public float throttle => Input.GetAxis("Trigger");
    public float throttle2 => Input.GetAxis("Trigger2");

    private float pitchPower, rollPower, yawPower, enginePower;

    private float activeRoll, activePitch, activeYaw;

    public bool isSteamDeck;

    private void Update()
    {
        if (isSteamDeck)
        {
            pitchPower = 70;
            rollPower = 90;
            yawPower = 100;
            enginePower = 35;
        }
        else
        {
            pitchPower = 140;
            rollPower = 180;
            yawPower = 200;
            enginePower = 40;
        }
        
        
        if (throttle != 0)
        {
            transform.position += transform.forward * enginePower * Time.deltaTime;

            activePitch = Input.GetAxisRaw("Vertical") * (pitchPower/1.5f) * Time.deltaTime;
            activeRoll = Input.GetAxisRaw("Horizontal") * (rollPower / 1.5f) * Time.deltaTime;
            activeYaw = Input.GetAxisRaw("Yaw") * (yawPower/1.5f) * Time.deltaTime;

            transform.Rotate(activePitch * (pitchPower/1.5f) * Time.deltaTime,
                activeYaw * (yawPower/1.5f) * Time.deltaTime,
                -activeRoll * (rollPower / 1.5f) * Time.deltaTime,
                Space.Self);
        }
        else
        {
            activePitch = Input.GetAxisRaw("Vertical") * (pitchPower/2) * Time.deltaTime;
            activeRoll = Input.GetAxisRaw("Horizontal") * (rollPower/2) * Time.deltaTime;
            activeYaw = Input.GetAxisRaw("Yaw") * (yawPower/2) * Time.deltaTime;

            transform.Rotate(activePitch * pitchPower * Time.deltaTime,
                activeYaw * yawPower * Time.deltaTime,
                -activeRoll * rollPower * Time.deltaTime,
                Space.Self);
        }
        
        if (throttle2 != 0)
        {
            transform.position -= transform.forward * enginePower * Time.deltaTime;

            activePitch = Input.GetAxisRaw("Vertical") * (pitchPower/1.5f) * Time.deltaTime;
            activeRoll = Input.GetAxisRaw("Horizontal") * (rollPower / 1.5f) * Time.deltaTime;
            activeYaw = Input.GetAxisRaw("Yaw") * (yawPower/1.5f) * Time.deltaTime;

            transform.Rotate(activePitch * (pitchPower/1.5f) * Time.deltaTime,
                activeYaw * (yawPower/1.5f) * Time.deltaTime,
                -activeRoll * (rollPower / 1.5f) * Time.deltaTime,
                Space.Self);
        }
        
    }
}