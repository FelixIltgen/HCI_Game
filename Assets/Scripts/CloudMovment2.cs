using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovment2 : MonoBehaviour
{
    public float speed;
    public float blowSpeed;
    public float sensibility = 100;
    public float threshold = 0.1f;
    public int sampelWindow = 64;
    private AudioClip microphoneClip;
    private float xPos;
    private float zPos;
    public float maxWater = 5;
    public float currentWater;
    public WaterBar waterBar;
    public static CloudMovment2 Instance;
    void Awake()
    {
        if (Instance == null)
        {
             Instance = this;
             Debug.Log("Instance da");
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {

        GetMicrophone();
        xPos = gameObject.transform.position.x;
        zPos = gameObject.transform.position.z;

        currentWater = maxWater;
        waterBar.SetMaxWater(maxWater);
    }
    // Update is called once per frame
    void Update()
    {
        // Hier If für Wolke zerstört
        Vector3 standardMovement = new Vector3(-xPos, 0, -zPos);
        transform.Translate(standardMovement * speed * Time.deltaTime, Space.World);
        float loudness = GetAudioFromMicrophone() * sensibility;

        if (loudness < threshold)
        {
            loudness = 0;
        }
        Vector3 blowMovment = new Vector3(xPos, 0, zPos);
        transform.Translate(blowMovment * loudness * Time.deltaTime * blowSpeed, Space.World);
        ReduceWater(); 
    }

    public void GetMicrophone()
    {
        string microphoneName = Microphone.devices[0];
        microphoneClip = Microphone.Start(microphoneName, true, 20, AudioSettings.outputSampleRate);
    }
    public float GetAudioFromMicrophone()
    {
        return GetAudio(Microphone.GetPosition(Microphone.devices[0]), microphoneClip);
    }
    public float GetAudio(int position, AudioClip clip)
    {

        int startPosition = position - sampelWindow;

        if (startPosition < 0)
        {
            return 0;
        }
        float[] waveData = new float[sampelWindow];
        clip.GetData(waveData, startPosition);

        float totalLoudness = 0;
        for (int i = 0; i < sampelWindow; i++)
        {
            totalLoudness += Mathf.Abs(waveData[i]);
        }
        return totalLoudness / sampelWindow;
    }

    public void ReduceWater()
    {
        currentWater -= Time.deltaTime;
        waterBar.SetWaterBar(currentWater);  
    }
}
