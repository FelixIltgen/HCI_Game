using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
   private float timer = 2;
   private float zPosition = 0;
   public GameObject cloudPrototype;

   bool isTimerFinished(){

    timer -= Time.deltaTime;
    //wird später kein timer mehr sein sonder wenn ein objekt bzw. aktion ausgeführt wird
    if(timer <= 0){

        timer = 2;
        return true;

    } else{
        return false;
    }
   }
    // Update is called once per frame
    void Update()
    {
        if (isTimerFinished()){
            Vector3 spwanPosition = new Vector3(-3,2,getRandomZPosition());
            Instantiate(cloudPrototype, spwanPosition, cloudPrototype.transform.rotation);
            
        }
        
    }
    public float getRandomZPosition(){

        zPosition = Random.Range(-3,3);
        return zPosition;
    }
     
}
