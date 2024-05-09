using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovment : MonoBehaviour
{
   public float speed;
   public float blowSpeed;
   public AudioDetection detector;
   public float sensibility = 100;
   public float threshold = 0.1f;
   public int sampelWindow = 64;
   private AudioClip microphoneClip;
   private float xPos = 0;
   private float zPos = 0;

   void Start()
    {
        getMicrophone();
        xPos = gameObject.transform.position.x;
        zPos = gameObject.transform.position.z;
    }
    // Update is called once per frame
    void Update()
    {
      Vector3 standardMovement = new Vector3(-xPos,0,-zPos);
      transform.Translate(standardMovement * speed * Time.deltaTime, Space.World);
      float loudness = getAudioFromMicrophone() * sensibility;
      if (loudness < threshold){
         loudness = 0;
      }
      Vector3 blowMovment = new Vector3(xPos,0,zPos);
      transform.Translate(blowMovment*loudness*Time.deltaTime*blowSpeed, Space.World);
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
