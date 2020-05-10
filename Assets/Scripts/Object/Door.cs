using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Door : MonoBehaviour
{
    Vector3 pos1 = new Vector3(15.63f,-2.45f,-10.72f);
    Vector3 pos2 = new Vector3(15.63f,-2.45f,-10.35f);
    Vector3 pos3 = new Vector3(13.82f,-2.45f,-10.35f);

    public bool is_opened = false;
    public bool moving = false;

    public GameObject childDoor;
    const float openTime = 1f;
    const float closeTime = 0.5f;

    public void setopen()
    {
        // Debug.Log("setopen");

        if(is_opened || moving)
            return;
        else{
            is_opened = true;
            moving = true;
        }
        StartCoroutine(openDoor());
    }

    public void setclose()
    {
        // Debug.Log("setclose");
        if(!is_opened || moving)
            return;
        else{
            is_opened = false;
            moving = true;
        }
        StartCoroutine(closeDoor());
    }

    IEnumerator openDoor()
    {
        // childDoor.transform.DOLocalMove(pos2, 1f);
        childDoor.transform.DOLocalMove(pos3, openTime);
        yield return new WaitForSeconds(openTime);
        moving = false;
    }

    IEnumerator closeDoor()
    {
        // childDoor.transform.DOLocalMove(pos2, .5f);
        childDoor.transform.DOLocalMove(pos1, closeTime);
        yield return new WaitForSeconds(closeTime);
        moving = false;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
            setopen();
        if(Input.GetKeyDown(KeyCode.K))
            setclose();
    }
}
