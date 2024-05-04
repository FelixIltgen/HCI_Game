using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDetection : MonoBehaviour
{
    public int sampleWindow = 64;
    private AudioClip microphoneClip;
    // Start is called before the first frame update
    void Start()
    {
        microphoneToAudioClip();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void microphoneToAudioClip(){

        string microphoneName = Microphone.devices[0];
        microphoneClip = Microphone.Start(microphoneName, true, 20, AudioSettings.outputSampleRate);
    }

    public float getAduioFromMicrophone(){
        return getAudio(Microphone.GetPosition(Microphone.devices[0]), microphoneClip);
    }

    public float getAudio(int position, AudioClip clip){

        int startPosition = position - sampleWindow;

        if (startPosition < 0)
        {
            return 0;
        }

        float[] waveData = new float[sampleWindow];
        clip.GetData(waveData, startPosition);

        //get loudness
        float totalLoudness = 0;

        for (int i = 0; i < sampleWindow; i++)
        {
            totalLoudness += Mathf.Abs(waveData[i]);
        }

        return totalLoudness /sampleWindow;
    }
}
