using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bullet : MonoBehaviour
{
    float speed = 10f;
    float distance;
    Vector3 target;
    List<GameObject> dolls;
    Vector3 t;
    public MeshRenderer mr;
    int color_code;

    public void setBullet(float distance, Vector3 target, int colorCode)
    {
        color_code = colorCode;
        resetMat();
        t=target;
        this.distance = distance;
        this.target = target;
        Vector3 heading = target - transform.position;
        heading = heading/(heading.magnitude);
        transform.rotation = Quaternion.LookRotation(heading);
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        //StartCoroutine(selfDestory(distance/speed));
    }


    IEnumerator selfDestory()
    {
        gameObject.SetActive(false);
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.GetComponent<dye>()!=null)
        {
            Debug.Log(other.gameObject.name);
            other.gameObject.GetComponent<dye>().EvokeDye(color_code);
        }
        StartCoroutine(selfDestory());
    }


    void resetMat()
    {
        Material[] mat = mr.materials;
        mat[0] = ColorManager.LoadMaterial(color_code);
        mr.materials = mat;
    }


}
