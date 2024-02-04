using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckBounds : MonoBehaviour
{
    public int crystalCount;
    public TextMeshProUGUI crystalTxt;

    public int alienCount;
    public TextMeshProUGUI alienTxt;

    public TextMeshProUGUI objectiveTxt;

    public RotateGuide rGuide;
    public Transform Ambulance;

    private void Update()
    {
        crystalTxt.SetText(crystalCount.ToString() + "/30");
        alienTxt.SetText(alienCount.ToString() + "/5");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Bounds")
        {
            Debug.Log("OUT");
            this.transform.position = new Vector3(0, 0, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Crystal")
        {
            crystalCount++;
            Destroy(other.gameObject);
        } else if (other.tag == "Alien")
        {
            //pick up
            objectiveTxt.SetText("[ ] Find Help");
            rGuide.playerTransform = Ambulance;
        }
    }
}
