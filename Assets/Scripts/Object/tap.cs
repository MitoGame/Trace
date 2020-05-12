using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tap : MonoBehaviour
{

    public GameObject coreTap;
    Vector3 boxPos = new Vector3(1f,.2f,-1f);
    Vector3 halfEx = new Vector3(.7f, .045f, .7f);
    public int colorCode;
    public MeshRenderer dyeMesh;
    public bool state = false;

    List<Collision> touchingObject = new List<Collision>();

    void Awake()
    {
        GetComponent<dye>().onDyeEvoke += setColor;
    }

    public void evokeTap()
    {
        if(state)
            return;
        state = true;
        if(colorCode == 0)
            return;
        ColorManager.instance.colorEvoke(colorCode);
    }

    public void disableTap()
    {
        if(!state)
            return;
        state = false;
        if(colorCode == 0)
            return;
        ColorManager.instance.colorDisable(colorCode);
    }

    public void setColor(int code)
    {
        
        if(state)
        {
            if(colorCode != 0)
                ColorManager.instance.colorDisable(colorCode);
            ColorManager.instance.colorEvoke(code);
        }
        dyeMesh.material = ColorManager.LoadMaterial(code);
        colorCode = code;
            
    }

    void Update()
    {
        if(touchingObject.Count > 0 || FindObjectOfType<FPController>().currentObject == gameObject)
            evokeTap();
        else
            disableTap();
    }

    private void OnCollisionEnter(Collision Other)
    {
        //Debug.Log(Other.gameObject.name);

        if(Other.gameObject.tag == "bullet" || Other.gameObject.tag == "Ground")
            return;
        foreach(var a in touchingObject)
        {
            if(Other == a)
                return;
        }
        touchingObject.Add(Other);
    }

    private void OnCollisionExit(Collision Other)
    {
        touchingObject.Remove(Other);
    }


}
