using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Slider slider;
    void Start(){
        slider.value = 50;
        PlayerPrefs.SetFloat("sens",slider.value);
    }
    
    public void OnSliderChanged(float value){
        text.text = value.ToString("0.0");
        PlayerPrefs.SetFloat("sens",value);
        Debug.Log("Sens: " + PlayerPrefs.GetFloat("sens"));
    }
}
