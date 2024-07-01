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

    void Awake() {
        instance = this;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update(){

        if(gameOver){
            timeScore = sysTime;
            //Daten in playerPrefs speichern.

        }else{

            sysTime += Time.deltaTime;
            timeScore = sysTime;
        }
        
    }
}
