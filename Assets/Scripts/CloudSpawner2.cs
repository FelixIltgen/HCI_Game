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
        timer -= Time.deltaTime;
        
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
        StartCoroutine(SpawnClouds());
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


    public IEnumerator SpawnClouds()
    {

        if (IsTimerFinished() && isCloudActive == false && cloudCount == 0)
        {
            Vector3 spwanPosition = new Vector3(GetRandomXPosition(), 2, GetRandomZPosition());
            currentCloud = Instantiate(cloudPrototype, spwanPosition, cloudPrototype.transform.rotation);
            cloudCount += 1;
            isCloudActive = true;
        }
        else if (isCloudActive == false && cloudCount >= 1 && CloudLifeTime())
        {
            lifeTimer = 23f;
            yield return new WaitForSeconds(2);
            Vector3 spwanPosition = new Vector3(GetRandomXPosition(), 2, GetRandomZPosition());
            currentCloud = Instantiate(cloudPrototype, spwanPosition, cloudPrototype.transform.rotation);
            isCloudActive = true;
        }
        else if (CloudLifeTime())
        {
            Destroy(currentCloud);
            isCloudActive = false;
        }
        else
        {
            Debug.Log("Cloud is already active");
        }
    }
}
