using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public static ColorManager instance;

    public static Dictionary<int,string> ColorPath
        = new Dictionary<int,string>{
            {0,"emission/default"},
            {1,"emission/blue"},
            {2,"emission/red"},
            {3,"emission/green"},
            {4,"emission/yellow"}
        };
    
    Dictionary<int, bool> colorState;


    public Dictionary<int,Color> ColorDic;
    

    public static Material LoadMaterial(int code)
    {
        return Resources.Load<Material>(ColorPath[code]);
    }

    void initiateColor()
    {
        colorState = new Dictionary<int, bool>();
        ColorDic = new Dictionary<int, Color>();
        for(int i=0;i<=4;i++)
        {
            ColorDic.Add(i, LoadMaterial(i).GetColor("_EmissiveColor"));
            colorState.Add(i, false);
        }
    }


    public event Action<int> onColorEvoke;
    public event Action<int> onColorDisable;

    public void colorEvoke(int id)
    {
        Debug.Log("color evoke " + id);
        if(colorState[id])
            return;
        colorState[id] = true;
        //LoadMaterial(id).SetColor("_EmissiveColor", ((Vector4)ColorDic[id])*2f);
        //Debug.Log(colorMats[id].GetColor("_EmissiveColor"));

        if(onColorEvoke != null)
        {
            onColorEvoke(id);
        }
    }

    public void colorDisable(int id)
    {
        Debug.Log("color disable "+id);
        if(!colorState[id])
            return;
        colorState[id] = false;
        //LoadMaterial(id).SetColor("_EmissiveColor", ColorDic[id]);
        if(onColorDisable != null)
        {
            onColorDisable(id);
        }
    }

    void Awake()
    {
        if(instance!= null)
            Destroy(gameObject);
        instance = this;
        initiateColor();
        DontDestroyOnLoad(gameObject);
    }


}
