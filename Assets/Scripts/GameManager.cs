using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int cloudScore = 0;
    public float timeScore = 0f;
    public float sysTime = 0f;

    void Awake() {
        instance = this;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update(){
        sysTime += Time.deltaTime;
        timeScore = sysTime;
    }
}
