using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialOnPlay : MonoBehaviour
{
    // Start is called before the first frame update

    void Awake()
    {
        GetComponent<MeshRenderer>().material = ColorManager.LoadMaterial(0,false);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
