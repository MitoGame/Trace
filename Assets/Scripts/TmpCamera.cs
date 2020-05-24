using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TmpCamera : MonoBehaviour
{
    public GameObject a;
    public GameObject b;
    // Start is called 0before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            b.SetActive(false);
            a.SetActive(true);
        }
        if(Input.GetKeyUp(KeyCode.P))
        {
            b.SetActive(true);
            a.SetActive(false);
        }
    }
}
