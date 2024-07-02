using UnityEngine;
using TMPro;

public class UiHighScoreTime : MonoBehaviour
{
    public TextMeshProUGUI timeHighScore;
    // Start is called before the first frame update
    void Start()
    {
        timeHighScore.text = PlayerPrefs.GetFloat("timeCount").ToString("0.0");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
