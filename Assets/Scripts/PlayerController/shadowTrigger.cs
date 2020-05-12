using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shadowTrigger : MonoBehaviour
{
    public bool startPoint;
    public DollControl parentDoll;
    Material dollMaterial;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Bullet>()!=null)
        {
            parentDoll.Replay(startPoint);
        }
    }

    void OnDestroy()
    {
        Vector3 gunPos = FindObjectOfType<GunControll>().shootPos.position;
        Bullet temp = (Instantiate(Resources.Load("bullet"), transform.position, Quaternion.identity) as GameObject).GetComponent<Bullet>();
        //temp.speed = 70f;
        float distance = (gunPos - transform.position).magnitude;
        temp.setBullet(distance, gunPos, 1);
    }
}
