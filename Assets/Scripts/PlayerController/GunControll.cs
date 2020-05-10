﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControll : MonoBehaviour
{
    float slootInterval = .2f;
    float timing;
    Animator gunAnimator;
    public Camera FPSCam;
    public float range = 100f;
    public LayerMask shootableLayer;
    public Transform shootPos;

    void Awake()
    {
        gunAnimator = GetComponent<Animator>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.T))
        {
            if(tryShoot())
            {
                shootOnce();
            }   
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            resetAllDoll();
        }
    }
    void resetAllDoll()
    {
        DollControl[] dolls = FindObjectsOfType<DollControl>();
        foreach(var d in dolls)
        {
            Destroy(d.gameObject);
        }

    }

    bool tryShoot() 
    {
        return true;
    }

    void shootOnce()
    {
        gunAnimator.SetTrigger("shoot");
        RaycastHit hit;
        Physics.Raycast(FPSCam.transform.position, FPSCam.transform.forward, out hit, range, shootableLayer);
        shootBullet(hit);

    }

    void shootBullet(RaycastHit hit)
    {
        Vector3 target;
        float distance;
        if(hit.distance != 0f)
        {
            target = hit.point;
            distance = hit.distance;
        }
        else
        {
            distance = 100f;
            target = FPSCam.transform.position + distance * FPSCam.transform.forward;
        }
        Bullet temp = (Instantiate(Resources.Load("bullet"), shootPos.position, Quaternion.identity) as GameObject).GetComponent<Bullet>();
        temp.setBullet(distance, target);
        //if(hit.distance != 0f)
        //{
        //    Instantiate(Resources.Load("shadow"), hit.point, Quaternion.identity);
        //}
    }
}