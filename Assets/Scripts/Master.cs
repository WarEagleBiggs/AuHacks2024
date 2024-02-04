using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master : MonoBehaviour
{
    public GameObject WholeSequence;
    public GameObject HUD;
    public GameObject Page1;
    public GameObject Page2;
    public int currPage;

    public GameObject ControlsUI;

    public UfoMovement UFO_Script;
    public CameraMove Cam_Script;
    void Start()
    {
        
        //mouse
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        //intro page
        currPage = 1;
        WholeSequence.SetActive(true);
        HUD.SetActive(false);
        Page1.SetActive(true);
        Page2.SetActive(false);
        UFO_Script.enabled = false;
        Cam_Script.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("PressX") )
        {
            ControlsUI.SetActive(!ControlsUI.activeSelf);
        } 
        
        if (Input.GetButtonDown("PressA") && currPage == 1)
        {
            currPage++;
            Page1.SetActive(false);
            Page2.SetActive(true);
        } else if (Input.GetButtonDown("PressA") && currPage == 2)
        {
            
            Page2.SetActive(false);
            WholeSequence.SetActive(false);
            HUD.SetActive(true);
            UFO_Script.enabled = true;
            Cam_Script.enabled = true;
        }
    }
}
