using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int cloudScore = 0;
    public float timeScore = 0.0f;
    public float sysTime = 0.0f;
    public bool gameOver = false;
    public bool gameWin = false;
    public CloudSpawner2 cloudSpawner2;

    void Awake() {
        instance = this;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update(){

        if(gameOver || gameWin){
            timeScore = sysTime;
            CheckAndSaveHighScore();

        }else{
            sysTime += Time.deltaTime;
            timeScore = sysTime;
        }
    }
    private void CheckAndSaveHighScore(){
        if(cloudSpawner2.maxClouds < PlayerPrefs.GetInt("cloudCount")){

            PlayerPrefs.SetInt("cloudCount",cloudScore);
        }
        if(sysTime < PlayerPrefs.GetFloat("timeCount")){
            PlayerPrefs.SetFloat("timeCount", timeScore); 
        }
    }
}
