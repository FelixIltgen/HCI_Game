using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeHealthBar : MonoBehaviour{

    public Slider slider;

    public void setHealth(int health){

        slider.value = health;

    }
    public void setMaxHealth(int health){
        slider.maxValue = 100;
        slider.value = health; // Muss möglicherweiße weg weil bei null beginnend
    }

   
}
