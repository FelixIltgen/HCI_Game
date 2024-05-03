using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
   private float timer = 2;
   public GameObject cloudPrefab;

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
            Vector3 spwanPosition = new Vector3(-2,3,0);
            Instantiate(cloudPrefab, spwanPosition, cloudPrefab.transform.rotation);
        }
    }
}
