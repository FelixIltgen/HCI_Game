using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
   private float timer = 4;
   private float zPosition = 0;
   private float xPosition = 0;
   public GameObject cloudPrototype;

   bool isTimerFinished(){

    timer -= Time.deltaTime;
    //wird später kein timer mehr sein sonder wenn ein objekt bzw. aktion ausgeführt wird
    if(timer <= 0){

        timer = 4;
        return true;

    } else{
        return false;
    }
   }
    // Update is called once per frame
    void Update()
    {
        if (isTimerFinished()){
            Vector3 spwanPosition = new Vector3(getRandomXPosition(),2,getRandomZPosition());
            Instantiate(cloudPrototype, spwanPosition, cloudPrototype.transform.rotation);
            
        }
        
    }
    public float getRandomZPosition(){
        while(true){
            zPosition = Random.Range(-15,15);
            if(zPosition <= 15 && zPosition >= 13 || zPosition <= -13 && zPosition >= -15){ 
                return zPosition;
            }
        }
    }
    public float getRandomXPosition(){
        while(true){
            xPosition = Random.Range(-15,15);
            if (xPosition <= 15 && xPosition >= 13 || xPosition <= -13 && xPosition >= -15)
            { 
               return xPosition; 
            }
        } 
    } 
}
