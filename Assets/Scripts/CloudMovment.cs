using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovment : MonoBehaviour
{
   public float speed;
   public float blowSpeed;
   public AudioSource source;
   public Vector3 minTransform;
   public Vector3 maxTransform;
   public AudioDetection detector;
   public float sensibility = 100;
   public float threshold = 0.1f;
   public float timeToDestroy = 0;
 
    // Update is called once per frame
    void Update()
    {
      transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
      float loudness = detector.getAudioFromMicrophone() * sensibility;
      if (loudness < threshold){
         loudness = 0;
      }
      //transform.localPosition = Vector3.left*loudness;
      transform.Translate(Vector3.left*loudness*Time.deltaTime*blowSpeed, Space.World);
    }

   
}
