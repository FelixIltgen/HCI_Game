using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovment : MonoBehaviour
{
   public float speed;
   public AudioSource source;
   public Vector3 minTranslate;
   public Vector3 maxTranslate;
   public AudioDetection detector;
   public float sensibillity = 100;
   public float threshold = 0.1f;
    // Update is called once per frame
    void Update()
    {
       transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
    }
}
