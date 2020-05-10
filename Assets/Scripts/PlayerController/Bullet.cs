using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    float distance;
    Vector3 target;
    List<GameObject> dolls;
    public Vector3 t;

    public void setBullet(float distance, Vector3 target)
    {
        t=target;
        this.distance = distance;
        this.target = target;
        Vector3 heading = target - transform.position;
        heading = heading/(heading.magnitude);
        transform.rotation = Quaternion.LookRotation(heading);
        transform.DOMove(target, distance/speed);
        StartCoroutine(selfDestory(distance/speed));
    }


    IEnumerator selfDestory(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
