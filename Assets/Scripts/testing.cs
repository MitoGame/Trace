using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testing : MonoBehaviour
{
    public Camera maincamera;
    public Camera recordcamera;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            maincamera.enabled = ! maincamera.enabled;
            recordcamera.enabled = ! recordcamera.enabled;
        }
    }
}
