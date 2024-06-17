using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeHealthBar : MonoBehaviour{

    public Slider slider;

    public void SetHealth(float health){

        slider.value = health;

    }
    public void SetMaxHealth(float health){
        slider.maxValue = 60;
        slider.value = health;
    }

    public void ResetHealth(){
        slider.maxValue = 0;
    }

   
}
