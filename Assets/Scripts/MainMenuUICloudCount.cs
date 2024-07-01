using UnityEngine;
using TMPro;

public class MainMenuUICloudCount : MonoBehaviour
{
    public TextMeshProUGUI cloudCount;
    // Start is called before the first frame update
    void Start()
    {
      cloudCount.text = PlayerPrefs.GetInt("cloudCount").ToString();  
    }

}
