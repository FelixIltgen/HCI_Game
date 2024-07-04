using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public Text levelText;
    public void GameOverSetUp(int level){

        gameObject.SetActive(true);
        levelText.text = "Du hast Level " + level.ToString() + " erreicht";
    }

    public void RestartButton(){
        SceneManager.LoadScene("Game");
    }
    
    public void MainMenuButton(){
        SceneManager.LoadScene("MainMenu");
    }
}
