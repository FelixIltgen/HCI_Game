using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterBar : MonoBehaviour{

    public Slider slider;

    public void SetWaterBar(float water){
        slider.value = water;
    }

    public void SetMaxWater(float water){
        slider.maxValue = water;
        slider.value = water;
    }
    
}
