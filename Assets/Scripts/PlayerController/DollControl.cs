using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DollControl : MonoBehaviour
{
    public List<GameObject> shadows;
    public List<posTape> tape1;
    public GameObject model;
    bool replaying;
    bool replayFromStart;

    int index = 0;
    float timer = 0;
    Material dollMaterial;
    public GameObject line;

    void reset(bool startPoint)
    {
        dollMaterial.DOFloat(0.6f, "_TRANS", .7f);
        replayFromStart = startPoint;
        if(replayFromStart)
            index = 0;
        else
            index = tape1.Count-1;
        timer = 0;
        transform.position = tape1[index].pos;
        transform.rotation = tape1[index].rot;
        model.SetActive(true);
        replaying = true;
    }

    void endReplay()
    {
        dollMaterial.DOFloat(0.1f, "_TRANS", .7f);
        model.SetActive(false);
        replaying = false;
    }

    void OnDestroy()
    {
        Destroy(line);
        foreach(var a in shadows)
        {
            Destroy(a);
        }
    }

    void Start()
    {
        dollMaterial = (Material)Resources.Load("DollMat", typeof(Material));
        bool startPoint = true;
        foreach (var a in shadows)
        {
            a.AddComponent<shadowTrigger>();
            a.GetComponent<shadowTrigger>().parentDoll = this;
            a.GetComponent<shadowTrigger>().startPoint = startPoint;
            startPoint = false;
        }
        endReplay();
    }

    void FixedUpdate()
    {
        if(!replaying)
            return;
        if(timer > tape1[index].deltaTime)
        {
            timer -= tape1[index].deltaTime;
            index  += (int)MathTool.BoolToOne(replayFromStart);
            if(index == tape1.Count -1 || index == 0)
            {
                endReplay();
                return;
            }
        }
        transform.position += Time.deltaTime * (tape1[index+(int)MathTool.BoolToOne(replayFromStart)].pos - transform.position)/(tape1[index+(int)MathTool.BoolToOne(replayFromStart)].deltaTime-timer);
        Vector3 r = Time.deltaTime * (MathTool.angelDistance(tape1[index+(int)MathTool.BoolToOne(replayFromStart)].rot, transform.rotation))/(tape1[index+(int)MathTool.BoolToOne(replayFromStart)].deltaTime-timer);
        r += transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(r);
        timer += Time.deltaTime;
    }

    public void Replay(bool startPoint)
    {
        reset(startPoint);
    }
}
