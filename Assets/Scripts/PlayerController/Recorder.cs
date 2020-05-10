﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct posTape
{
    public Vector3 pos;
    public Quaternion rot;
    public float deltaTime;
}

public class Recorder : MonoBehaviour
{
    List<posTape> tape1;
    List<GameObject> shadows;
    bool recording = false;
    public float deltaTime = .3f;
    public float shadowDelta = 2f;
    float timer = 0f;
    float shadowTimer = 0f;
    //public PostProcessVolume ppv;
    GameObject shadow;

    LineRenderer lineRenderer;
    public Material lineMaterial;
    public float lineHeightY = 1.6f;
    

    public bool exist = false;

    void Awake()
    {
        shadow = Resources.Load("shadow") as GameObject;
    }

    void Update()
    {
        if(recording)
        {
            timer += Time.deltaTime;
            shadowTimer += Time.deltaTime;
            if(timer > deltaTime)
            {
                recordOnce(timer);
                timer = 0f;
            }
            if(shadowTimer > shadowDelta)
            {
                //shadows.Add(Instantiate(shadow, transform.position, transform.rotation) as GameObject);
                shadowTimer = 0f;
            }
        }
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            setRecord();
        }
    }

    void setRecord()
    {
        if(recording)               //end record
        {
            shadows.Add(Instantiate(shadow, transform.position, transform.rotation) as GameObject);
            recordOnce(timer);
            endRecord();
            recording = false;
        }
        else                       //start record
        {
            newLineRenderer();
            tape1 = new List<posTape>();
            shadows = new List<GameObject>();
            shadows.Add(Instantiate(shadow, transform.position, transform.rotation) as GameObject);
            recording = true;
        }
    }

    void endRecord()
    {
        GameObject doll = Instantiate(Resources.Load("Doll"), tape1[0].pos, tape1[0].rot) as GameObject;
        doll.GetComponent<DollControl>().tape1 = tape1;
        doll.GetComponent<DollControl>().shadows = shadows;
        doll.GetComponent<DollControl>().line = lineRenderer.gameObject;
        exist = true;
    }

    void newLineRenderer()
    {
        GameObject tmp = new GameObject();
        tmp.AddComponent<LineRenderer>();
        lineRenderer = tmp.GetComponent<LineRenderer>();
        lineRenderer.material = lineMaterial;
        lineRenderer.startWidth = .2f;;
        lineRenderer.positionCount = 0;
        lineRenderer.generateLightingData = true;
        lineRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
    }

    void recordOnce(float timer)
    {
        posTape tmp = new posTape();
        tmp.deltaTime = timer;
        tmp.pos = transform.position;
        tmp.rot = transform.rotation;
        tape1.Add(tmp);
        lineRenderer.positionCount+=1;
        lineRenderer.SetPosition(lineRenderer.positionCount-1, transform.position + Vector3.up*lineHeightY);
        //Debug.Log(transform.position + " " + Vector3.up*lineHeightY);
    }
}
