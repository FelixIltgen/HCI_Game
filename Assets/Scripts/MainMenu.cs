using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource clickAudio;
    public void StartButton(){
        SceneManager.LoadScene("Game");
    }

    public void ExitButton(){
        Debug.Log("Spiel geschlossen!");
        Application.Quit();
    }

 
}
