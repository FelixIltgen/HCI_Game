
using UnityEngine;
using TMPro;

public class UiHighScoreCloud : MonoBehaviour
{
    public TextMeshProUGUI cloudHighScore;

    // Start is called before the first frame update
    void Start()
    {
        cloudHighScore.text = PlayerPrefs.GetInt("cloudCount").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
