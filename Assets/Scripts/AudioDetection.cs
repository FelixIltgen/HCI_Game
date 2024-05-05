using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioDetection : MonoBehaviour
{
    public int sampelWindow = 64;
    private AudioClip microphoneClip;
    // Start is called before the first frame update
    void Start()
    {
        getMicrophone();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void getMicrophone(){
        string microphoneName = Microphone.devices[0];
        microphoneClip = Microphone.Start(microphoneName,true,20,AudioSettings.outputSampleRate);
    }
    
    public float getAudioFromMicrophone(){
        return getAudio(Microphone.GetPosition(Microphone.devices[0]),microphoneClip);
    }

    public float getAudio(int position, AudioClip clip){

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
}
