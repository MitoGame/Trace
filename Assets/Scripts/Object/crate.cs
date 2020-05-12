using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crate : MonoBehaviour
{
    public MeshRenderer dyeMesh;
    GameObject currentTap;

    public void setColor(int code)
    {
        Material[] tmp = dyeMesh.materials;
        tmp[1] = ColorManager.LoadMaterial(code);
        dyeMesh.materials = tmp;
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject != currentTap && other.gameObject.tag == "tap")
        {
            currentTap = other.gameObject;
            setColor(currentTap.GetComponent<tap>().colorCode);
            currentTap.GetComponent<dye>().onDyeEvoke += setColor;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if(other.gameObject == currentTap)
        {
            currentTap.GetComponent<dye>().onDyeEvoke -= setColor;
            currentTap = null;
            setColor(0);
        }
    }

}
