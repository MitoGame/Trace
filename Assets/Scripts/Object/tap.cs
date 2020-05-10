using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tap : MonoBehaviour
{
    public GameObject targetbox;
    public Door targetdoor;

    void Start()
    {
        
    }

    void Update()
    {
        
        bool to_open = false;
        Vector3 player = FindObjectOfType<FPController>().gameObject.transform.position;
        if(near(player)){
            to_open = true;
        }
        if(!to_open && near(targetbox.transform.position)){
            to_open = true;
        }
        if(!to_open && FindObjectOfType<Recorder>().exist){
            DollControl[] dolls = FindObjectsOfType<DollControl>();
            foreach(DollControl doll in  dolls){
                Vector3 doll_pos = doll.gameObject.transform.position;
                if(near(doll_pos)){
                    to_open = true;
                    break;
                }
            } 
        }
        if(to_open){
            targetdoor.setopen();
            
        }else{
            targetdoor.setclose();
        }
    }


    bool near(Vector3 a)
    {
        Vector3 b = transform.position;
        return (a - b).magnitude < 4;
    }
}
