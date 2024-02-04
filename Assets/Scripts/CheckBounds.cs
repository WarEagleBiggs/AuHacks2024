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

    public GameObject winScreen;
    public GameObject HUD;

    public RotateGuide rGuide;
    public Transform Ambulance;

    public List<GameObject> Aliens;
    public bool hasAlien;

    private void Update()
    {
        crystalTxt.SetText(crystalCount.ToString() + "/30");
        alienTxt.SetText(alienCount.ToString() + "/5");

        if (alienCount >= 5 && crystalCount >= 30)
        {
            //win
            HUD.SetActive(false);
            winScreen.SetActive(true);
        }
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
        } else if (other.tag == "Alien" && hasAlien == false)
        {
            //pick up
            hasAlien = true;
            objectiveTxt.SetText("[ ] Find Help");
            //remove THIS alien from Aliens list
            Aliens.Remove(other.gameObject);
            Destroy(other.gameObject);
            rGuide.playerTransform = Ambulance;
            
        } else if (other.tag == "Ambulance" && hasAlien)
        {
            //pick up
            hasAlien = false;
            objectiveTxt.SetText("[ ] Rescue Aliens");
            alienCount++;
            rGuide.playerTransform = Aliens[0].transform;
            
        }
    }
}
