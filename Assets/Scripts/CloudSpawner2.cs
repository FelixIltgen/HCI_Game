using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner2 : MonoBehaviour
{
    private float timer = 3f;
    public float lifeTimer = 23f;
    private float zPosition = 0;
    private float xPosition = 0;
    public GameObject cloudPrototype;
    public GameObject currentCloud;
    public bool isCloudActive = false;
    public int cloudCount = 0;
    public int maxClouds = 0;
    private int treeLevel = 0;
    public GameObject[] trees;
    public GameOverScript GameOverScript;
    public TreeManager treeManager;
    public TreeColider treeColider;
    
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
        //Debug.Log("Leben: "+ treeColider.GetHealth()+"Leben: "+cloudCount);
        
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
            Vector3 spwanPosition = new Vector3(GetRandomXPosition(), 7, GetRandomZPosition());
            currentCloud = Instantiate(cloudPrototype, spwanPosition, cloudPrototype.transform.rotation);
            cloudCount += 1;
            GameManager.instance.cloudScore += 1;
            isCloudActive = true;
        }
        else if (isCloudActive == false && cloudCount >= 1 && CloudLifeTime())
        {
            
            CheckGameProgress();

            lifeTimer = 23f;
            yield return new WaitForSeconds(2);
            Vector3 spwanPosition = new Vector3(GetRandomXPosition(), 7, GetRandomZPosition());
            currentCloud = Instantiate(cloudPrototype, spwanPosition, cloudPrototype.transform.rotation);
            isCloudActive = true;
            cloudCount += 1;
            GameManager.instance.cloudScore += 1;
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
    public void CheckGameProgress()
    {
        Debug.Log("Checke das Spiel");
        if (cloudCount < 3 && treeColider.GetHealth() < 60){

            Debug.Log("Spiel geht weiter");
        }
        else if (cloudCount <= 3 && treeColider.GetHealth() >= 60){

            Debug.Log("Naechstes Level erreicht!");
            trees = treeManager.GetTrees();
            trees[treeLevel].SetActive(false);
            treeLevel += 1;
            trees[treeLevel].SetActive(true);

            maxClouds = cloudCount;
            cloudCount = 0;
        }
        else{
            Debug.Log("GameOver");
            GameOverScript.GameOverSetUp(GameManager.instance.cloudScore);
            gameObject.SetActive(false);
            
        }
    }
}
