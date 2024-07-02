using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinMenu : MonoBehaviour
{
    public void exitButton(){
        Application.Quit();
        Debug.Log("Game Closed");
    }

    public void startGame(){
        SceneManager.LoadScene("Game");

    }
    public void mainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}
