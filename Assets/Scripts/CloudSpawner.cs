using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public static CloudSpawner Instance;
    private float timer = 3;
    private float zPosition = 0;
    private float xPosition = 0;
    public GameObject cloudPrototype;
    public GameObject currentCloud;
    public GameObject nextCloud;
    public bool isCloudActive = false;
  
    bool IsTimerFinished()
    {

        timer -= Time.deltaTime;
        //wird später kein timer mehr sein sonder wenn ein objekt bzw. aktion ausgeführt wird
        if (timer <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.Debug.Log("CloudSpawner");
        SpawnFirstCloud();
        
    }
    public float GetRandomZPosition()
    {
        while (true)
        {
            zPosition = Random.Range(-15, 15);
            if (zPosition <= 15 && zPosition >= 13 || zPosition <= -13 && zPosition >= -15)
            {
                return zPosition;
            }
        }
    }
    public float GetRandomXPosition()
    {
        while (true)
        {
            xPosition = Random.Range(-15, 15);
            if (xPosition <= 15 && xPosition >= 13 || xPosition <= -13 && xPosition >= -15)
            {
                return xPosition;
            }
        }
    }
    public void SpawnFirstCloud()
    {
        if (IsTimerFinished() && isCloudActive == false)
        {
            Vector3 spwanPosition = new Vector3(GetRandomXPosition(), 2, GetRandomZPosition());
            currentCloud = Instantiate(cloudPrototype, spwanPosition, cloudPrototype.transform.rotation);
            isCloudActive = true;
            UnityEngine.Debug.Log("First Cloud");
        }
    }

    public void SpwanNextCloud()
    {
       
        UnityEngine.Debug.Log("Hallo");
       /* if (movment.ReduceWater() && cloudTimer(4))
        {
            Vector3 spwanPosition = new Vector3(getRandomXPosition(), 2, getRandomZPosition());
            nextCloud = Instantiate(cloudPrototype, spwanPosition, cloudPrototype.transform.rotation);
            isCloudActive = true;
        }
        else
        {

            UnityEngine.Debug.Log("Cloud already active!!");
        }
*/
    }
    public bool CloudTimer(float time)
    {
        float count = time;
        count -= Time.deltaTime;

        if (count <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
