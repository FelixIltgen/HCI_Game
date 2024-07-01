using UnityEngine;
using TMPro;

public class MainMenuUITimeCount : MonoBehaviour
{
    public TextMeshProUGUI timeCount;
    // Start is called before the first frame update
    void Start()
    {
       timeCount.text = PlayerPrefs.GetFloat("timeCount").ToString("0.0");
    }

   
}
