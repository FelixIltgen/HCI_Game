using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner2 : MonoBehaviour
{
    //public static CloudSpawner2 Instance;
    private float timer = 3f;
    public float lifeTimer = 23f;
    private float zPosition = 0;
    private float xPosition = 0;
    public GameObject cloudPrototype;
    public GameObject currentCloud;
    public GameObject nextCloud;
    public bool isCloudActive = false;
    private int cloudCount = 0;

    public bool CloudLifeTime()
    {
        Debug.Log("Current Life: " + lifeTimer);
        lifeTimer -= Time.deltaTime;

        if (lifeTimer <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    bool IsTimerFinished()
    {
        //Debug.Log("Timer"+timer);
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
        SpawnClouds();
        //SpawnFirstCloud();

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


    public void SpawnClouds()
    {

        if (IsTimerFinished() && isCloudActive == false && cloudCount == 0)
        {
            Vector3 spwanPosition = new Vector3(GetRandomXPosition(), 2, GetRandomZPosition());
            currentCloud = Instantiate(cloudPrototype, spwanPosition, cloudPrototype.transform.rotation);
            isCloudActive = true;
            cloudCount += 1;
            Debug.Log("First Cloud");
        }
        else if (isCloudActive == false && cloudCount >= 1)
        {
            Debug.Log("Nächste Wolke");
            Vector3 spwanPosition = new Vector3(GetRandomXPosition(), 2, GetRandomZPosition());
            currentCloud = Instantiate(cloudPrototype, spwanPosition, cloudPrototype.transform.rotation);
            isCloudActive = true;
        }
        else if (CloudLifeTime())
        {
            isCloudActive = false;
            Destroy(currentCloud);
            Debug.Log("Wolke ist tot");
            lifeTimer = 23f;
        }
        else
        {
            Debug.Log("Cloud is already active");
        }
    }


    /*public void SpawnFirstCloud()
    {
        if (IsTimerFinished() && isCloudActive == false)
        {
            Vector3 spwanPosition = new Vector3(GetRandomXPosition(), 2, GetRandomZPosition());
            currentCloud = Instantiate(cloudPrototype, spwanPosition, cloudPrototype.transform.rotation);
            isCloudActive = true;
            UnityEngine.Debug.Log("First Cloud");
        }
    }*/
    public bool TimerAfterCloud(float time)
    {
        //Debug.Log("Timer läuft");
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
