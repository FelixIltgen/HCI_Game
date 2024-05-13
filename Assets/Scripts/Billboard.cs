using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Billboard : MonoBehaviour{

    public Transform cam;
    void Start()
    {
       cam = Camera.current.transform; 
    }

    // Update is called once per frame
    void LateUpdate() {
        
        transform.LookAt(transform.position + cam.forward);
    }
}
